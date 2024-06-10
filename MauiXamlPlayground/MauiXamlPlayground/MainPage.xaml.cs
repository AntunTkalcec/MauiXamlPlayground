using System.ComponentModel;

namespace MauiXamlPlayground;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;
    private double _buttonSize;

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        SizeChanged += OnSizeChanged;
        BindingContext = _viewModel = vm;

        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnSizeChanged(object? sender, EventArgs e)
    {
        _buttonSize = Math.Min(Width, Height) / 5;

        More0.WidthRequest = _buttonSize;
        More0.HeightRequest = _buttonSize;

        More1.WidthRequest = _buttonSize;
        More1.HeightRequest = _buttonSize;

        More2.WidthRequest = _buttonSize;
        More2.HeightRequest = _buttonSize;

        More3.WidthRequest = _buttonSize;
        More3.HeightRequest = _buttonSize;
    }

    private async void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(MainPageViewModel.MoreButtonsVisible))
        {
            double translateDistance = _buttonSize * 1.2;

            if (_viewModel.MoreButtonsVisible)
            {
                More1.IsVisible = true;
                More2.IsVisible = true;
                More3.IsVisible = true;

                More1.TranslateTo(0, -translateDistance, 250, Easing.SinOut);
                More2.TranslateTo(0, -translateDistance * 2, 250, Easing.SinOut);
                More3.TranslateTo(0, -translateDistance * 3, 250, Easing.SinOut);
            }
            else
            {
                More1.TranslateTo(0, 0, 250, Easing.SinOut);
                More2.TranslateTo(0, 0, 250, Easing.SinOut);
                await More3.TranslateTo(0, 0, 250, Easing.SinOut);

                More1.IsVisible = false;
                More2.IsVisible = false;
                More3.IsVisible = false;
            }
        }
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        _viewModel.OnCollectionViewScrolled();
    }

    private void More1_Clicked(object sender, EventArgs e)
    {
        _viewModel.ToggleButtons();
    }

    private void More2_Clicked(object sender, EventArgs e)
    {
        _viewModel.ToggleButtons();
    }

    private void More3_Clicked(object sender, EventArgs e)
    {
        _viewModel.ToggleButtons();
    }
}
