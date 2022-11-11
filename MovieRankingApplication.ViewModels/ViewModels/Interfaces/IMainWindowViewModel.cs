using System.Windows.Input;
using MovieRankingApplication.ViewModels.DataObjectViewModels;

namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IMainWindowViewModel
{
    public string[] UserNames { get; }
    public MovieEntryViewModel SelectedModel { get; set; }
    public string CurrentPageUri { get; }
    public ICommand ChangeToEditView { get; }
    public ICommand ChangeToAddView { get; }
    public ICommand ChangetoListView { get; }
    public bool EditMode { get;}
}