using ASP26._12._2022.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP26._12._2022.ViewsModels
{
    public class VMFriendWithImage
    {
        public VMFriendWithImage() { Friend=new Friend(); }
        public Friend Friend { get; set; }

        [Display(Name ="הוספת תמונה")]
        public IFormFile File { get; set; }
    }
}