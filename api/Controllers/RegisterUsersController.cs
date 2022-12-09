using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// This class will handle all calls made to api/registerusers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUsersController : ControllerBase
    {
        private readonly IConfiguration _iconfigurations;
        private readonly DbContext_dpal _context;


        /// <summary>
        /// Constructor to read configuration and get context to database
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public RegisterUsersController(IConfiguration configuration, DbContext_dpal context)
        {

            _iconfigurations = configuration;
            _context = context;
        }

        /// <summary>
        /// Only Post method is provided as there is no need to get user data 
        /// this method will first check if the email address has been used before 
        /// if email address already exists will return an error
        /// other wise will proceed to create an account.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<RegisterUser>> Post(RegisterUser user)
        {

            string query = @"select EmailAdd from RegisterUsers
                            where EmailAdd = '" + user.EmailAdd + @"'";

            DataTable table = new DataTable("table");

            // string to connect to database 
            string sqlDataSource = _iconfigurations.GetConnectionString("dpal");

            SqlDataReader myReader;

            // loads teh Reader with data form database 
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

            string checkUser = user.EmailAdd;

            UserInfo[] newRow = new UserInfo[1];

            bool validUser = true;
            //JsonResult checkUser = new JsonResult(table);

            table.BeginLoadData();

            DataRow row;
            // Add the new row to the rows collection.
            //row =  table.LoadDataRow(newRow, true);

            foreach (DataRow dr in table.Rows)
            {

                if (checkUser == dr["EmailAdd"].ToString())
                {
                    Console.WriteLine(String.Format("Row: {0}", dr["EmailAdd"]));
                    validUser = false;
                }

            }

            table.EndLoadData();

            // if user name has not been used before account is created else error is returned
            if (validUser)
            {
                CreatePasswordHash(user.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.RegisterUsers.Add(user);
                await _context.SaveChangesAsync();

                Console.WriteLine("added here");

                return user;

            }
            else
            {

                Console.WriteLine("returned error");
                return NoContent();

            }


            return BadRequest();

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private ActionResult<RegisterUser> JsonResult(object table)
        {
            throw new NotImplementedException();
        }


    }
}
