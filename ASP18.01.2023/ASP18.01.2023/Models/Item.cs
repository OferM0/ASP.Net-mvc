using System.ComponentModel.DataAnnotations;

namespace ASP18._01._2023.Models
{
    public class Item
    {
        public Item() 
        {
            Images = new List<Image>();
            Prices = new List<Price>();
        }

        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "שם פריט")]
        //[StringLength(50)] //max lengtgh
        public string Name { get; set; }

        [Display(Name = "תיאור")]
        public string Description { get; set; }

        public Group Group { get; set; }

        public List<Image> Images { get; set; }

        public List<Price> Prices { get; set; }

        //פונקצייה הוספת תמונה
        public void AddImage(IFormFile file)
        {
            if (file == null) return;
            Images.Add(new Image { Item = this, SetImage = file });
        }

        //פונקצייה הוספת מחיר       
        public Price AddPrice(decimal myPrice)
        {
            return AddPrice(new Price { MyPrice = myPrice, Item = this });
        }
        public Price AddPrice(decimal myPrice, DateTime end)
        {
            return AddPrice(new Price { MyPrice = myPrice, End = end, Item = this });
        }
        public Price AddPrice(decimal myPrice, DateTime start, DateTime end)
        {
            return AddPrice(new Price { MyPrice = myPrice, Start = start, End = end, Item = this });
        }
        public Price AddPrice (Price price)
        {
            price.Item = this;
            Prices.Add(price);
            return price;
        }
    }
}