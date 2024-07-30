namespace GrocerrrrrryApp.Controls;

public partial class Spacer : ContentView
{
	public static readonly BindableProperty 
					SpaceProperty =  BindableProperty.Create(nameof(Space), typeof(double), typeof(Spacer), defaultValue: 10d);
	public double Space
	{
		get => (double)GetValue(SpaceProperty);
		set => SetValue(SpaceProperty, value);
	}
	public Spacer()
	{
		InitializeComponent();
	}
}