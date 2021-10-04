using System;
using System.Collections.Generic;

namespace NHRM_Admin_API.ViewModels
{
    public class AllCategoriesView
    {
        public AllCategoriesView(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public int CategoryID { get; set; }
       public string CategoryName { get; set; }
        
       
        
    }

}