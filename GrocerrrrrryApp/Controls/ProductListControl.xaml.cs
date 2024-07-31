using CommunityToolkit.Mvvm.Input;
using DLL.DTOs;

namespace GrocerrrrrryApp.Controls;

public class ProductEventArgs : EventArgs
{
    public ProductEventArgs(int porductId, int count)
    {
        PorductId = porductId;
        Count = count;
    }

    public int PorductId { get; set; }
	public int Count { get; set; }	
}
public partial class ProductListControl : ContentView
{
    public static readonly BindableProperty ProductsProperty =
        BindableProperty.Create(nameof(Products), typeof(IEnumerable<ProductDto>), typeof(ProductListControl),defaultValue:Enumerable.Empty<ProductDto>());


	public IEnumerable<ProductDto> Products
    {
		get => (IEnumerable<ProductDto>)base.GetValue(ProductsProperty);
		set => base.SetValue(ProductsProperty, value);
	}

	public event EventHandler<ProductEventArgs> ProductAddRemoveClick;
	[RelayCommand]
	private void AddToCart(int productId) => ProductAddRemoveClick?.Invoke(this, new ProductEventArgs(productId, 1));
	[RelayCommand]	
	private void RemoveFromCart(int productId) => ProductAddRemoveClick?.Invoke(this, new ProductEventArgs(productId, -1));

	public ProductListControl()
	{
		InitializeComponent();
	}

}