using SELS_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_DL
{
    public static class CategoryEntity
    {
        private const string cCLASS_NAME = "CategoryEntity";
        public static eResult GetCategoryList(ref List<Category> pCategoryList)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"Select * from Category";
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    List<Category> tCategoryList = new List<Category>();
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                }
                foreach (DataRow dataRow in tTable.Rows)
                {
                    Category category = new Category();
                    category.ID = Convert.ToInt32(dataRow["ID"]);
                    category.Name = dataRow["Name"].ToString();
                    category.Description = dataRow["Description"].ToString();
                    category.Photo = dataRow["Photo"].ToString();
                    pCategoryList.Add(category);
                }
                if(pCategoryList.Count > 0)
                {
                    tResult = eResult.Sucess;
                }
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
                string tQuery = @"Select * from Category where ID = " + pCategory.ID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    List<Category> tCategoryList = new List<Category>();
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                }
                if (tTable.Rows != null)
                {
                    pCategory.ID = Convert.ToInt32(tTable.Rows[0][0]);
                    pCategory.Name = tTable.Rows[0][1].ToString();
                    pCategory.Description = tTable.Rows[0][2].ToString();
                    pCategory.Photo = tTable.Rows[0][3].ToString();
                    tResult = eResult.Sucess;
                }
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
                string tQuery = @"delete from Category where ID = " + pID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                {
                    con.Open();
                    tCommand.ExecuteNonQuery();
                    con.Close();
                    tResult = eResult.Sucess;
                }
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
                string tQuery = @"
                                    INSERT INTO dbo.[Category] VALUES (
                                    '" + pCategory.Name + @"'
                                    ,'" + pCategory.Description + @"'
                                    ,'" + pCategory.Photo + @"'
                                  )";
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                    tResult = eResult.Sucess;
                }
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
                string tQuery = @"UPDATE dbo.[Category] SET Name = '" + pCategory.Name + @"', Description = '" + pCategory.Description + @"', Photo = '" + pCategory.Photo + @"' WHERE ID = " + pCategory.ID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                    tResult = eResult.Sucess;
                }
                return tResult;
            }
            catch (Exception ex)
            {

                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult InsertCategroiesPerUser (CategoryPerUser pCategoryPerUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = DeleteAllCategroiesPerUser(pCategoryPerUser.UserID);
                if (tResult == eResult.Sucess)
                {
                    string tQuery = @"
                                    INSERT INTO dbo.[CategoryPerUser] VALUES";
                    for  (int tIndex = 0; tIndex< pCategoryPerUser.CategoriesID.Count; ++tIndex)
                    {
                        tQuery += "("+pCategoryPerUser.UserID+","+ pCategoryPerUser.CategoriesID[tIndex]+ ")";
                        if (tIndex+1 < pCategoryPerUser.CategoriesID.Count)
                        {
                            tQuery += ",";
                        }
                    }
                    DataTable tTable = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                    using (var tCommand = new SqlCommand(tQuery, con))
                    using (var tDatatable = new SqlDataAdapter(tCommand))
                    {
                        tCommand.CommandType = CommandType.Text;
                        tDatatable.Fill(tTable);
                        tResult = eResult.Sucess;
                    }
                    if(tResult == eResult.Sucess)
                    {
                        tQuery = @"UPDATE dbo.[FilledTable] SET IsCategoryFilled = 1 WHERE ID = " + pCategoryPerUser.UserID;
                        tTable = new DataTable();
                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                        using (var tCommand = new SqlCommand(tQuery, con))
                        using (var tDatatable = new SqlDataAdapter(tCommand))
                        {
                            tCommand.CommandType = CommandType.Text;
                            tDatatable.Fill(tTable);
                            tResult = eResult.Sucess;
                        }
                    }
                }
                return tResult; 
            }
            catch (Exception ex)
            {

                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult DeleteAllCategroiesPerUser (int pUserID)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"delete from CategoryPerUser where UserID = " + pUserID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                {
                    con.Open();
                    tCommand.ExecuteNonQuery();
                    con.Close();
                    tResult = eResult.Sucess;
                }
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
                string tQuery = @"Select Category.* from Category inner join CategoryPerUser on Category.ID = CategoryPerUser.CategoryID inner join [User] on CategoryPerUser.UserID = [User].ID and [User].ID = " + pUserId.ToString();
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    List<Category> tCategoryList = new List<Category>();
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                }
                foreach (DataRow dataRow in tTable.Rows)
                {
                    Category category = new Category();
                    category.ID = Convert.ToInt32(dataRow["ID"]);
                    category.Name = dataRow["Name"].ToString();
                    category.Description = dataRow["Description"].ToString();
                    category.Photo = dataRow["Photo"].ToString();
                    pCategoryList.Add(category);
                }
                if (pCategoryList.Count > 0)
                {
                    tResult = eResult.Sucess;
                }
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
