using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELS_Models
{
    public class CategoryPerUser
    {
        public int UserID { get; set; }
        public List<int> CategoriesID { get; set; }

        public CategoryPerUser()
        {
            CategoriesID = new List<int>(); 
        }
    }
}
