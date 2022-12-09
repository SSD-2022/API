using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// This class will handle all calls made to api/profileinfoes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileInfoesController : ControllerBase
    {
        private readonly IConfiguration _iconfigurations;
        private readonly DbContext_dpal _context;


        /// <summary>
        /// Constructor to read configuration and get context to database
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public ProfileInfoesController(IConfiguration configuration, DbContext_dpal context)
        {

            _iconfigurations = configuration;
            _context = context;


        }

        /// <summary>
        /// This method will be used to profile data form register users table 
        /// </summary>
        /// <param name="Email"> get the email address for which the profile info has been requested</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Get(ProfileInfo Email)
        {
            Console.WriteLine("Here");
            string query = @"select FirstName,LastName,Address  from RegisterUsers
                            where EmailAdd = '" + Email.EmailAdd + @"'";

            DataTable table = new DataTable();


            string sqlDataSource = _iconfigurations.GetConnectionString("dpal");

            SqlDataReader myReader;

            await using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {

                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();

                };

            };
            return new JsonResult(table);

        }
    }
}
