using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult PostUserDetails(UserRegistration ur)
        {
            string query = @"
                    insert into dbo.UserRegistration (Name,UserName,Email,Password) values
                    ('" + ur.Name + @"','" + ur.UserName + @"','" + ur.Email + @"','" + ur.Password + "')";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand myCommand = new SqlCommand(query, con))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    con.Close();
                }
            }

            return new JsonResult("user Registration successful");
        }
        [HttpGet]
        public JsonResult GetUsers(string UserName, string Password)
        {
            /*string query = @"
                    select Username,Password from dbo.AdminTable";*/
            /*string query = @" select count(UserName) as matches
                    from dbo.UserRegistration where UserName='" + ad.UserName + "' and Password = '" + ad.Password + "'";*/
            /*string query = @"twocolumnsdata @UserName='" + Username + "' @Password='" + password + "'";*/
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand myCommand = new SqlCommand("twocolumnsdata", con))
                {
                    myCommand.Parameters.AddWithValue("@UserName", UserName);
                    myCommand.Parameters.AddWithValue("@Password", Password);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    con.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
