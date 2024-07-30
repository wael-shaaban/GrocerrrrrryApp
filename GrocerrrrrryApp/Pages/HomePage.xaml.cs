using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
		this.BindingContext = homePageViewModel;
	}
}
