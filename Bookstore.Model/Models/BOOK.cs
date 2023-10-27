using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Model.Models
{
    [Table( "T_BOOKS" )]
    public class BOOK : EntityBase
    {        
        [ExplicitKey]
        public int ID { get; set; }
        public DateTime CRT_DATE_TIME { get; set; }
        public string AUTHOR { get; set; }
        public string TITLE { get; set; }
        public int PUBLISHER_ID { get; set; }
        public int? PAGE_COUNT { get; set; }
        public int? PUBLISH_YEAR { get; set; }
        public int EDITION { get; set; }
        public string FORMAT { get; set; }
        public string ISBN { get; set; }
        public double PRICE { get; set; }
        public DateTime? DATE_WHEN_GET { get; set; }
        public int WRAPPER { get; set; }
        public int LANGUAGE_ID { get; set; }
        public int? GROUP_ID { get; set; }
        public int SHOP_ID { get; set; }
        public int CITY_ID { get; set; }
        public int HAS_DIGIT_COPY { get; set; }
        public string ANNOTATION { get; set; }
        public string DETAILS { get; set; }
        public byte[] COVER_IMAGE { get; set; }
        public string BOOK_FILE { get; set; }

    }
}
