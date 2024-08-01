using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp.Pages;

public partial class CategoryProductPage : ContentPage
{
	public CategoryProductPage(CategoryProductPageViewModel categoryProductPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = categoryProductPageViewModel;	
	}
}