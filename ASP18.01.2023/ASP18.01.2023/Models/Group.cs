using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP18._01._2023.Models
{
    public class Group
    {
        public Group() //קונסטרקטור
        {
            SubGroups = new List<Group>();
            Items = new List<Item>();
        }
        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "שם קבוצה")]
        //[StringLength(50)] //max lengtgh
        public string Name { get; set; }

        [Display(Name = "תיאור")]
        public string Description { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }

        public Group Parent { get; set; } //קטגוריית אבא
        public List<Group> SubGroups { get; set; } //רשימת תתי קטגוריה
        public List<Item> Items { get; set; } //רשימת מוצרים

        //פונקצייה של הוספת תת קבוצה
        public Group AddSubGroup(string name)
        {
            Group subGroup = new Group { Name = name, Parent = this };
            return AddSubGroup(subGroup);
        }
        public Group AddSubGroup(string name, string description)
        {
            Group subGroup = new Group { Name = name, Description = description, Parent = this };
            return AddSubGroup(subGroup);
        }
        public Group AddSubGroup(string name, string description, IFormFile image)
        {
            Group subGroup = new Group { Name = name, Description = description, SetImage = image, Parent = this };
            return AddSubGroup(subGroup);
        }
        public Group AddSubGroup(Group subGroup)
        {
            subGroup.Parent= this;
            SubGroups.Add(subGroup);
            return subGroup;
        }

        //פונקצייה של הוספת פריט
        public Item AddItem(string name, string description)
        {
            Item item = new Item { Name = name, Description = description, Group=this };
            return AddItem(item);
        }

        public Item AddItem(string name, string description, decimal price)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price);
            return AddItem(item);
        }

        public Item AddItem(string name, string description, IFormFile image, decimal price)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price);
            item.AddImage(image);
            return AddItem(item);
        }

        public Item AddItem(string name, string description, DateTime start, DateTime end, IFormFile image, decimal price)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price, start, end);
            item.AddImage(image);
            return AddItem(item);
        }

        public Item AddItem(string name, string description, List<IFormFile> images, decimal price)
        {
            Item item = new Item { Name = name, Description = description, Group = this };
            item.AddPrice(price);
            foreach (IFormFile image in images)
            {
                item.AddImage(image);
            }
            return AddItem(item);
        }

        public Item AddItem(Item item)
        {
            item.Group = this;
            Items.Add(item);
            return item;
        }

        //פונקצייה של הכנסת תמונה
        public IFormFile SetImage
        {
            set
            {
                if (value == null) return;
                //יצירת מקום בזכרון המכיל קובץ
                MemoryStream stream = new MemoryStream();
                //העתקת הקובץ מהמשתמש למקום שנוצר זכרון
                value.CopyTo(stream);
                //הפיכת הזכרון למערך כדי שיוכל להיכנס למסד נתונים
                Image = stream.ToArray();
            }
        }

        //הצגת פריטים כולל תתי קבוצות
        [NotMapped]
        public List<Item> AllItems { get { return GetItems(this); } }

        private List<Item> GetItems(Group group)
        {
            List<Item> items = new List<Item>();
            return GetItems(group, items);
        }      

        private List<Item> GetItems(Group group, List<Item> items)
        {
            if (group.SubGroups.Count > 0)
            {
                foreach (Group subgroup in group.SubGroups)
                {
                    GetItems(subgroup, items);
                }
            }
            else
            {
                if (group.Items.Count > 0)
                {
                    foreach (Item item in group.Items)
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}
