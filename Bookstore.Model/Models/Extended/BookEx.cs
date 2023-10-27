using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Models.Extended
{
    public class BookEx : BOOK
    {
        public string PublisherName { get; set; }
        public string GroupName { get; set; }
        public string LanguageName { get; set; }
        public string ShopName { get; set; }
        public string CityName { get; set; }
    }
}
