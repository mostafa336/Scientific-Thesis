using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Data.SqlClient;
using System.Data;
using Thesis.Models;

namespace Thesis.Repository
{
    public class ExcelGenRepository : IExcelGenRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public ExcelGenRepository()
        {
            _context = new ScienteficThesisDbContext();
        }
        public DataTable getTable()
        {

            string connectionString = "Server=DESKTOP-M1LE963;Database=ScienteficThesisDB;Integrated Security=true;TrustServerCertificate=true;";
            //This Query should change according to the filter which will change selected items in the table
            string query = "SELECT [APP_ID] ,[APP_NameAr] ,[APP_NameEn] ,[APP_Email] ,[APP_BirthDate] ,[APP_Job] ,Country.CNT_NameEN ,[APP_NationalID] ,[APP_ThesisTitleAr] ,[APP_ThesisTitleEn] ,[APP_Volumes] ,[APP_Pages] ,[APP_PublicationYear] ,[APP_Department] ,[APP_Faculty] ,University.UNI_NameEn ,[APP_keyword] ,[APP_notes] ,[APP_SubmissionLetter] ,[APP_Thesis] ,[APP_LanguageMaster] ,Degree.DEG_NameEn ,[APP_LastModificationDate] ,Admin.AD_Name ,Status.ST_State ,[APP_EbCode] FROM [ScienteficThesisDB].[dbo].[ModifiedApplication] JOIN Country ON Country.CNT_ID = ModifiedApplication.APP_NationalityID\r\nJOIN University ON University.UNI_ID = ModifiedApplication.APP_UniversityID JOIN Degree ON Degree.DEG_ID = ModifiedApplication.APP_DegreeID JOIN Status ON ST_ID = ModifiedApplication.APP_StatusID JOIN Admin ON AD_ID = ModifiedApplication.APP_LastModifierID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }

                
        }
    }
}
