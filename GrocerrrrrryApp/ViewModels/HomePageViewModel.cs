using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.Services;
using System.Collections.ObjectModel;

namespace GrocerrrrrryApp.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly CategoryService categoryService;
        private readonly OfferService offerService;
        [ObservableProperty]
        ObservableCollection<CategoryModel> categories;

        [ObservableProperty]
        ObservableCollection<OfferModel> offers;

        [ObservableProperty]
        bool isBusy = true;
        public HomePageViewModel(CategoryService categoryService, OfferService offerService)
        {
            this.categoryService = categoryService;
            this.offerService = offerService;
            Categories = new ObservableCollection<CategoryModel>();
            Offers = new ObservableCollection<OfferModel>();
        }
        [RelayCommand]
        public async Task InitializeAsync()
        {
            IsBusy = true;
            try
            {
                var offerTask = offerService.GetOffersAsync();
                foreach (var category in await categoryService.GetCategoriesAsync())
                    Categories.Add(category);
                foreach (var offer in await offerTask)
                    Offers.Add(offer);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}