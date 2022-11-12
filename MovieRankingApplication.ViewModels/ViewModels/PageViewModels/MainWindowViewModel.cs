using System.Windows.Input;
using MovieRankingApplication.ViewModels.Interfaces;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.DataObjectViewModels;

namespace MovieRankingApplication.ViewModels.PageViewModels;

public class MainWindowViewModel : BindableBase, IMainWindowViewModel
{

    public MainWindowViewModel()
    {
        _selectedModel = new MovieEntryViewModel();
        _currentPageUri = "PlaceHolder";
        _editMode = true;
    }

    #region Properties and fields
    private string[] _userNames = {"kieran", "Mia"};
    public string[] UserNames
    {
        get => _userNames;
    }

    private MovieEntryViewModel _selectedModel;
    public MovieEntryViewModel SelectedModel
    {
        get => _selectedModel;
        set
        {
            if (_selectedModel != value)
                _selectedModel = value;
        }
    }

    private string _currentPageUri;
    public string CurrentPageUri => _currentPageUri;


    public ICommand ChangeToEditView => new DelegateCommand(DoChangeToEditView);

    public ICommand ChangeToAddView => new DelegateCommand(DoChangeToAddView);

    public ICommand ChangetoListView => new DelegateCommand(DoChangeToListView);

    private bool _editMode;
    public bool EditMode => _editMode;

    #endregion

    #region Private helper methods
    private void DoChangeToAddView()
    {
        if (_editMode == true)
            _editMode = false;
        _currentPageUri = "PlaceHolderStringForAddView";
    }
    private void DoChangeToEditView()
    {
        if (_editMode == false)
            _editMode = true;
        _currentPageUri = "PlaceHolderStringForEditView";
    }
    private void DoChangeToListView()
    {
        _currentPageUri = "PlaceHolderStringForListView";
    }

    #endregion
}