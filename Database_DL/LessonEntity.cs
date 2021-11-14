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
    public static class LessonEntity
    {
        private const string cCLASS_NAME = "LessonEntity";
        public static eResult GetLessonList(ref List<Lesson> pLessonList)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"Select * from Lesson";
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    List<Lesson> tLessonList = new List<Lesson>();
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                }
                foreach (DataRow dataRow in tTable.Rows)
                {
                    Lesson Lesson = new Lesson();
                    Lesson.ID = Convert.ToInt32(dataRow["ID"]);
                    Lesson.Name = dataRow["Name"].ToString();
                    Lesson.Description = dataRow["Description"].ToString();
                    Lesson.VideoLink = dataRow["VideoLink"].ToString();
                    pLessonList.Add(Lesson);
                }
                if (pLessonList.Count > 0)
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
        public static eResult GetLesson(ref Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"Select * from Lesson where ID = " + pLesson.ID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    List<Lesson> tLessonList = new List<Lesson>();
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                }
                if (tTable.Rows != null)
                {
                    pLesson.ID = Convert.ToInt32(tTable.Rows[0][0]);
                    pLesson.Name = tTable.Rows[0][1].ToString();
                    pLesson.Description = tTable.Rows[0][2].ToString();
                    pLesson.VideoLink = tTable.Rows[0][3].ToString();
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
        public static eResult DeleteLesson(int pID)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"delete from Lesson where ID = " + pID;
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
        public static eResult InsertLesson(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"
                                    INSERT INTO dbo.[Lesson] VALUES (
                                    '" + pLesson.Name + @"'
                                    ,'" + pLesson.Description + @"'
                                    ,'" + pLesson.VideoLink + @"'
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
        public static eResult EditLesson(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"UPDATE dbo.[Lesson] SET Name = '" + pLesson.Name + @"', Description = '" + pLesson.Description + @"', VideoLink = '" + pLesson.VideoLink + @"' WHERE ID = " + pLesson.ID;
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
    }
}
