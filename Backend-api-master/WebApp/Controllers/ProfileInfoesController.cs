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

            await using (SqlConnection myConn = new SqlConnection(sqlDataSource)) {

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

        //These Commented method can be used later to give more functionality to the program

        /*/ GET: api/ProfileInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileInfo>> GetProfileInfo(Guid id)
        {
            var profileInfo = await _context.ProfileInfo.FindAsync(id);

            if (profileInfo == null)
            {
                return NotFound();
            }

            return profileInfo;
        }

        // PUT: api/ProfileInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileInfo(Guid id, ProfileInfo profileInfo)
        {
            if (id != profileInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(profileInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileInfoExists(id))
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

        // POST: api/ProfileInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProfileInfo>> PostProfileInfo(ProfileInfo profileInfo)
        {
            _context.ProfileInfo.Add(profileInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileInfo", new { id = profileInfo.Id }, profileInfo);
        }

        // DELETE: api/ProfileInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileInfo>> DeleteProfileInfo(Guid id)
        {
            var profileInfo = await _context.ProfileInfo.FindAsync(id);
            if (profileInfo == null)
            {
                return NotFound();
            }

            _context.ProfileInfo.Remove(profileInfo);
            await _context.SaveChangesAsync();

            return profileInfo;
        }

        private bool ProfileInfoExists(Guid id)
        {
            return _context.ProfileInfo.Any(e => e.Id == id);
        }*/
    }
}
