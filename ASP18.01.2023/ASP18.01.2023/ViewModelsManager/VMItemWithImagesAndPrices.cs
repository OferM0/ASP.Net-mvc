using ASP18._01._2023.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP18._01._2023.ViewModelsManager
{
    public class VMItemWithImagesAndPrices
    {
        public VMItemWithImagesAndPrices()
        {
            Group = new Group();
            Item = new Item();
            Price = new Price();
        }

        public Group Group { get; set; }

        public Item Item { get; set; }

        //לפעמים יש מין בעיה שברגע ששולחים מעל 2 אובייקטים בטופס זה מתחיל להתבלבל
        public Price Price { get; set; }

        [Display(Name = "הוספת תמונה")]
        public IFormFile File { get; set; }
    }
}
