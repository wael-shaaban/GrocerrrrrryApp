using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.Pages;
using GrocerrrrrryApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.ViewModels
{
    public partial class CategoryPageViewModel : ObservableObject
    {


        private readonly CategoryService categoryService;
        [ObservableProperty]
        CategoryModel selectedCategory;
        [ObservableProperty]
        ObservableCollection<CategoryModel> categories;
        public CategoryPageViewModel(CategoryService categoryService)
        {
            Categories = new ObservableCollection<CategoryModel>();
            this.categoryService = categoryService;
        }
        bool isInitialized = false;
        [RelayCommand]
        async Task Initialize()
        {
            if (isInitialized) return;
                foreach (var category in await categoryService.GetCategoriesAsync())
                    Categories.Add(category); 
                isInitialized = true;   
        }
        [RelayCommand]
       async Task GotoCategoryProductPage()
        {
            if (SelectedCategory is not null)
                await Shell.Current.GoToAsync(nameof(CategoryProductPage));
        }
    }
}