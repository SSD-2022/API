using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApp.Controllers
{
    /// <summary>
    /// This class controller is used to verify when a user logsin
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly IConfiguration _iconfigurations;
        private readonly DbContext_dpal _context;
        /// <summary>
        /// Constructor to read configuration and get context to database
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public UserInfoesController(IConfiguration configuration, DbContext_dpal context)
        {
            _iconfigurations = configuration;
            _context = context;
        }
        //using post to disguise as get
        /// <summary>
        /// This method will retrun response code OK(200) is user gave correct login info 
        /// else will return Unauthorized(401) and user won't be able to login
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetUser(UserInfo info)
        {
            //Console.WriteLine("here request start");
            //Console.WriteLine(info.EmailAdd);
            string query = @"select EmailAdd,Password  from RegisterUsers
                            where EmailAdd = '" + info.EmailAdd + "'";
            DataTable table = new DataTable("table");
            //Console.WriteLine(query);
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
            string checkUser = "";
            string pass = "";
            UserInfo[] newRow = new UserInfo[2];
            table.BeginLoadData();
            DataRow row;
            // Add the new row to the rows collection.
            row = table.LoadDataRow(newRow, true);
            foreach (DataRow dr in table.Rows)
            {
                checkUser = dr["EmailAdd"].ToString();
                pass = dr["Password"].ToString();
                break;
            }
            table.EndLoadData();
            if (checkUser.Equals(info.EmailAdd) && pass.Equals(info.Password))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
