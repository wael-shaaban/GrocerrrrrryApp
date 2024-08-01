using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp.Pages;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage(CategoryPageViewModel categoryPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = categoryPageViewModel;
	}
}