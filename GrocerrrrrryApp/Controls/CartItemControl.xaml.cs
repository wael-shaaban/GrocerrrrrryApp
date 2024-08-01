using GrocerrrrrryApp.Pages;
using System.Runtime.CompilerServices;

namespace GrocerrrrrryApp.Controls;

public partial class CartItemControl : ContentView
{
	public static readonly BindableProperty CountProperty =
		BindableProperty.Create(nameof(Count), typeof(int), typeof(CartItemControl), 0,propertyChanged:CartCountChanged);

   

    public int Count
	{
		get => (int)GetValue(CountProperty);
		set => SetValue(CountProperty, value);
	}
	private async Task Pulse()
	{
      await Bordercontainer.ScaleTo(1,180);
      await Bordercontainer.ScaleTo(1.2,180);
      await Bordercontainer.ScaleTo(1,180);
      await Bordercontainer.ScaleTo(1.2,180);
      await Bordercontainer.ScaleTo(1,180);
    }
	private async Task Animate(AnimationTypes animationType)
	{
	switch (animationType)
        {
            case AnimationTypes.In:
			await Task.WhenAll(Bordercontainer.ScaleTo(1),Bordercontainer.RotateTo(360,500));
				await Pulse();
                break;
            case AnimationTypes.Out:
                await Task.WhenAll(Bordercontainer.ScaleTo(0), Bordercontainer.RotateTo(-360, 500)); break;
            default:
				await Pulse();
                break;
        }
    }
    enum AnimationTypes
	{
		In,
		Out,
		Pulse
	}
  //  protected override void OnSizeAllocated(double width, double height)
  //  {
  //      base.OnSizeAllocated(width, height);
		//Bordercontainer.Scale = 0;	
  //  }
    private async static void CartCountChanged(BindableObject bindable, object oldValue, object newValue)//for animate the bordercontainter only
    {
        var  container = (CartItemControl)bindable;
		var myOldValue = (int)oldValue;
		var myNewValue = (int)newValue;	
		if (myNewValue != myOldValue)
		{
			if (myNewValue < 1)
			{
				//there is no item here
				//hide this
				await container.Animate(AnimationTypes.Out);
			}
			else if (myOldValue < 1 && myNewValue > 0)
			{
				//this is the first itme added here
				//show this
				await container.Animate(AnimationTypes.In);
			}
			else
			{
				//increase//decrase quantiy
				await container.Animate(AnimationTypes.Pulse);
			}
		}
    }

	public CartItemControl()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(CartPage));
    }
}