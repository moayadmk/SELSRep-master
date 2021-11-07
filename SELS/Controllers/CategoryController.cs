using SELS_Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SELS.Controllers
{
    public class CategoryController : ApiController
    {
        private const string cCLASS_NAME = "CategoryController";
        [HttpGet]
        public List<Category> Get()
        {
            try
            {
                eResult tResult = eResult.Error;
                List<Category> tCategoryList = new List<Category>();
                tResult = Manager_BL.CategoryImplementation.GetCategoryList(ref tCategoryList);
                if (tResult == eResult.Sucess)
                {
                    return tCategoryList;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return null;
            }
        }
        [HttpGet]
        public Category Get(int id)
        {
            try
            {
                eResult tResult = eResult.Error;
                Category tCategory = new Category();
                tCategory.ID = id;
                tResult = Manager_BL.CategoryImplementation.GetCategory(ref tCategory);
                if (tResult == eResult.Sucess)
                {
                    return tCategory;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return null;
            }
        }
        [HttpPost]
        public string Post(Category pCategory)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.CategoryImplementation.InsertCategory(pCategory);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpPut]
        public string Put(Category pCategory)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.CategoryImplementation.EditCategory(pCategory);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.CategoryImplementation.DeleteCategory(id);
                if (tResult == eResult.Sucess)
                {
                    return eResult.Sucess.ToString();
                }
                return eResult.Error.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
    }
}