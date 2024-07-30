using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Models
{
    public class OfferModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        //private static readonly string[] _lightColors = new string[]
        //{
        //            "#e1f1e7", "#dad1f9", "#ffff00", "#d0f200", "#e28083", "#7fbdc7", "#ea978d"
        //};
        //private static Color RandomColor => Color.FromHex(_lightColors.OrderBy(x => Guid.NewGuid()).First());

        //public OfferModel(string title, string description, Color color, string code)
        //{
        //    Title = title;
        //    Description = description;
        //    Color = color;
        //    Code = code;
        //}

        //public static IEnumerable<OfferModel> GetOffers()
        //{
        //    yield return new("Upto 30% off", "Enjoy upto 30% off on all fruits", RandomColor, "FRT30");
        //    yield return new("Green Veg Big Sale 50% OFF", "Enjoy our big offer of 50% off on all green vegetables", RandomColor, "500FF");
        //    yield return new("Flat 100 OFF", "Flat Rs. 100 off on all exotic fruits and vegetables", RandomColor, "EXT100");
        //    yield return new("25% OFF on Seasonal Fruits", "Enjoy 25% off on all seasonal fruits", RandomColor, "FRT25");
        //}
    }
}