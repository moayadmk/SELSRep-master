using SELS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_BL
{
    public static class CategoryImplementation
    {
        private const string cCLASS_NAME = "CategoryImplementation";
        public static eResult GetCategoryList(ref List<Category> pCategoryList)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.GetCategoryList(ref pCategoryList);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult GetCategory(ref Category pCategory)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.GetCategory(ref pCategory);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult DeleteCategory(int pID)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.DeleteCategory(pID);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult InsertCategory(Category pCategory)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.InsertCategory(pCategory);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult EditCategory(Category pCategory)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.EditCategory(pCategory);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult InsertCategroiesPerUser(CategoryPerUser pCategoryPerUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.InsertCategroiesPerUser(pCategoryPerUser);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult GetCategroiesPerUser(ref List<Category> pCategoryList, int pUserId)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.CategoryEntity.GetCategroiesPerUser(ref pCategoryList, pUserId);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
    }
}
