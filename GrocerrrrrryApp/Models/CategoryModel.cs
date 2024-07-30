using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Models
{
    public class CategoryModel
    {
        public CategoryModel(short id, string name, short parentId,string image ,string Credit)
        {
            Id = id;
            Name = name;
            Image = image;
            ParentId = parentId;
        }
        public CategoryModel()
        {
            
        }
        public string Credit { get; set; }
        public short Id { get; set; }
        public string Name { get; set; }
        private string image;
        
        public short ParentId { get; set; }
        public bool IsMainCategory => ParentId == 0;

        public string Image
        {
            get => image; 
            set
            {
               if(image != value)
                {
                    image = $"https://github.com/Abhayprince/FruitVegBasketMAUI/blob/master/FruitVegBasket.Api/wwwroot/images/categories/{value}";
                }   
            } 
        }
    }
}