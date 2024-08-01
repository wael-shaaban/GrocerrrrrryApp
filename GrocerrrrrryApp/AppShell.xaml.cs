using GrocerrrrrryApp.Pages;

namespace GrocerrrrrryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CartPage),typeof(CartPage));   
        }
    }
}
