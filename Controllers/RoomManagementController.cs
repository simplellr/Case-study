using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class RoomManagementController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            public RoomManagementController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            public JsonResult Get()
            {
                string query = @"select * from RoomManagement";

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
                    }
                }
                return new JsonResult(table);
            }

        //[HttpGet("{id}")]
        //public JsonResult Get(int id)
        //{
        //    string query = @"select * from SetRoomRates
        //where RoomTypeId = " + id + @"
        //";

        //    DataTable table = new DataTable();

        //    string sqlDataSource = _configuration.GetConnectionString("HotelDB");

        //    SqlDataReader myReader;

        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader); ;
        //            myReader.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}

        [HttpPost]
        public JsonResult Post(RoomManagement rm)
        {
            string query = @"
                    insert into RoomManagement
                    (RoomNo,Facilities,No_Of_Adults,RoomType)
                    values 
                    (
                    '" + rm.RoomNo + @"'
                    ,'" + rm.Facilities + @"'
                    ,'" + rm.No_Of_Adults + @"'
                    ,'" + rm.RoomType + @"'
                    )
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
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(RoomManagement rm)
        {
            string query = @"
                update roommanagement set 
                RoomNo = '" + rm.RoomNo + @"'
                ,Facilities = '" + rm.Facilities + @"'
                ,No_Of_Adults = '" + rm.No_Of_Adults + @"'
                ,RoomTypeId = '" + rm.RoomType + @"'
                where RoomNo = " + rm.RoomNo + @"
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

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from roommanagement
                where RoomNo = " + id + @" 
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
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
    } 

