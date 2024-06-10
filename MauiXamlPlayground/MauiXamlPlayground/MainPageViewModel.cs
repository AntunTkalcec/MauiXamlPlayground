using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiXamlPlayground;

public class MainPageViewModel : ObservableObject
{
    private bool _moreButtonsVisible = false;

    public ObservableCollection<Item> Items { get; set; } =
    [
        new Item { Name = "Item 1", Description = "Description 1" },
        new Item { Name = "Item 2", Description = "Description 2" },
        new Item { Name = "Item 3", Description = "Description 3" },
        new Item { Name = "Item 4", Description = "Description 4" },
        new Item { Name = "Item 5", Description = "Description 5" },
        new Item { Name = "Item 6", Description = "Description 6" },
        new Item { Name = "Item 7", Description = "Description 7" },
        new Item { Name = "Item 8", Description = "Description 8" },
        new Item { Name = "Item 9", Description = "Description 9" },
        new Item { Name = "Item 10", Description = "Description 10" },
        new Item { Name = "Item 11", Description = "Description 11" },
        new Item { Name = "Item 12", Description = "Description 12" },
        new Item { Name = "Item 13", Description = "Description 13" },
        new Item { Name = "Item 14", Description = "Description 14" },
        new Item { Name = "Item 15", Description = "Description 15" },
        new Item { Name = "Item 16", Description = "Description 16" },
        new Item { Name = "Item 17", Description = "Description 17" },
        new Item { Name = "Item 18", Description = "Description 18" },
    ];

    public bool MoreButtonsVisible
    {
        get => _moreButtonsVisible;
        set => SetProperty(ref _moreButtonsVisible, value);
    }

    public IRelayCommand ToggleMoreButtons { get; }

    public MainPageViewModel()
    {
        ToggleMoreButtons = new RelayCommand(ToggleButtons);
    }

    public void ToggleButtons()
    {
        MoreButtonsVisible = !MoreButtonsVisible;
    }

    public void OnCollectionViewScrolled()
    {
        if (MoreButtonsVisible)
        {
            MoreButtonsVisible = false;
        }
    }
}
