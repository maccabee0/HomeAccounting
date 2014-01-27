using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.UI.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryString { get; set; }
    }
}
