using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Model.Models
{
    [Table("T_SHOPS")]
    public class SHOP : EntityBase
    {
        [ExplicitKey]
        public int ID { get; set; }
        public string NAME { get; set; }
    }
}
