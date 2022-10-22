using System.Windows.Input;
using MovieRankingApplication.Model.Context;

namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IMainWindowViewModel
{
    public MovieEntry SelectedModel { get; set; }
    public string CurrentPageUri { get; }
    public ICommand ChangeToEditView { get; }
    public ICommand ChangeToAddView { get; }
    public ICommand ChangetoListView { get; }
    public bool EditMode { get;}
}