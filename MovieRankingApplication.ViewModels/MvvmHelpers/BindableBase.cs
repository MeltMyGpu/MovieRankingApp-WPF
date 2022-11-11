using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieRankingApplication.MvvmHelpers;

public class BindableBase : INotifyPropertyChanged
{
    // Requires testing
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
