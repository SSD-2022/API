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

            //JsonResult checkUser = new JsonResult(table);

            table.BeginLoadData();
            DataRow row;
            // Add the new row to the rows collection.
            row = table.LoadDataRow(newRow, true);

            foreach (DataRow dr in table.Rows)
            {
                checkUser = dr["EmailAdd"].ToString();
                pass = dr["Password"].ToString();

                //Console.WriteLine(String.Format("Row: {0}, {1}", dr["EmailAdd"], dr["Password"]));
                
                break;
            }

            table.EndLoadData();

            if (checkUser.Equals(info.EmailAdd) && pass.Equals(info.Password)) {

                return Ok();
            }
            else {
                //Console.WriteLine("in row" + checkUser);
                //Console.WriteLine("in row" + pass);
                
                return Unauthorized();
            }

            

        }
        //These Commented method can be used later to give more functionality to the program

        // GET: api/UserInfoes
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserInfo()
        {
            return await _context.UserInfo.ToListAsync();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(Guid id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(Guid id, UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
            _context.UserInfo.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfo>> DeleteUserInfo(Guid id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();

            return userInfo;
        }

        private bool UserInfoExists(Guid id)
        {
            return _context.UserInfo.Any(e => e.Id == id);
        }*/
    }
}
