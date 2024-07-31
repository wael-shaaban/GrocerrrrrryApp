using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel homePageViewModel;

    public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
		this.BindingContext = homePageViewModel;
        this.homePageViewModel = homePageViewModel;
    }

    private void ProductListControl_ProductAddRemoveClick(object sender, Controls.ProductEventArgs e)
    {
		if(e.Count>0)
            homePageViewModel.AddToCartCommand.Execute(e.PorductId);
        else homePageViewModel.RemoveFromCartCommand.Execute(e.PorductId);
    }
}
