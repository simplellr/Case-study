using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using CaseStudy.Models;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchRoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SearchRoomController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(SearchRooms Sea)
        {
            string query = @"
                  select SUM(Rooms_Available) AS Rooms_Available from SearchRooms where (check_IN_DATE BETWEEN '" + Sea.check_IN_DATE + @"' AND '" + Sea.Check_OUT_DATE + @"')AND RoomType = '" + Sea.RoomType + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
