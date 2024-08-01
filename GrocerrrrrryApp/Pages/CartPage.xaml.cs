using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp.Pages;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel cartViewModel;

    public CartPage(CartViewModel cartViewModel)
	{
		InitializeComponent();
        this.cartViewModel = cartViewModel;
        this.BindingContext = cartViewModel;
    }
}