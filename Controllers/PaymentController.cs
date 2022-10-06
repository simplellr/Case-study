using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Payment";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);

        }
        [HttpPost]
        public JsonResult Post(Payment pay)
        {
            string query = @"
                    insert into Payment(CardHolderName,CardNumber,ExpiryDate,CVV)values('" + pay.CardHolderName + @"','" + pay.CardNumber + @"','" + pay.ExpiryDate + @"','" + pay.CVV + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");

        }
        //[HttpPut]
        //public JsonResult Put(Payment pay)
        //{
        //    string query = @"
        //            update Payment set
                   
        //             CardHolderName = '" + pay.CardHolderName + @"'
        //            ,CardNumber = '" + pay.CardNumber + @"'
        //            ,ExpiryDate = '" + pay.ExpiryDate + @"'
        //            ,CVV = '" + pay.CVV + @"'
        //            where CardHolderName = " + pay.CardHolderName + @"
        //            ";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("HotelDB");
        //    SqlDataReader myReader;
        //    using (SqlConnection mycon = new SqlConnection(sqlDataSource))
        //    {
        //        mycon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, mycon))
        //        {

        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            mycon.Close();
        //        }
        //    }
        //    return new JsonResult("Updated Successfully");

        //}

        [HttpDelete("{CardNumber}")]
        public JsonResult Delete(long CardNumber)
        {
            string query = @"delete from Payment where CardNumber = " + CardNumber + @"";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelDB");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Deleted");

        }
    }
}
