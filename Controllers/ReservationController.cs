using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using CaseStudy.Models;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ReservationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select * from Reservation";

            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");

            SqlDataReader reader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(dt);
        }

        [HttpPost]
        public JsonResult Post(Reservation Res)
        {
            string query = @"
                    insert into Reservation values 
                    ('" + Res.Id + @"','" + Res.Name + @"','" + Res.Email + @"','" + Res.PhoneNumber + @"','" + Res.Address + @"','" + Res.IdProof + @"','" + Res.RoomType + @"','" + Res.NoOfMembers + @"','" + Res.CheckIn + @"','" + Res.CheckOut + @"')";
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

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Reservation Res)
        {
            string query = @"
                    update reservation set 
                    Name = '" + Res.Name + @"',
                    Address = '" + Res.Address + @"',
                    PhoneNumber = '" + Res.PhoneNumber + @"',
                    IdProof = '" + Res.IdProof + @"',
                    RoomType='" + Res.RoomType + @"',
                    NoOfMembers='" + Res.NoOfMembers + @"',
                    CheckIn='" + Res.CheckIn + @"',
                    CheckOut='" + Res.CheckOut + @"'
                    where Id = " + Res.Id + @" 
                    ";
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

            return new JsonResult("Updated Successfully");
        }
    }
}
