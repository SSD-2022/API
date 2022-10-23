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
    /// This class will handle all calls made to api/BehaviourTrackers
    /// Current required functionality is only post
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviourTrackersController : ControllerBase
    {
        private readonly IConfiguration _iconfigurations;
        private readonly DbContext_dpal _context;

        /// <summary>
        /// Constructor to read configuration and get context to database
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public BehaviourTrackersController(IConfiguration configuration, DbContext_dpal context)
        {

            _iconfigurations = configuration;
            _context = context;


        }
        /// <summary>
        /// This method handels post request made to the server with help of Sql
        /// </summary>
        /// <param name="track"> json object for behaviour tracker</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BehaviourTracker>> Post(BehaviourTracker track)
        {
            //Console.WriteLine("doing check : before chek");
            var check = await _context.BehaviourTracker.FindAsync(track.EmailAdd);

            // if the user is updating behaviour and An Sql query will be used to update tracker for specific user
            if (check != null)
            {
                string query = @"UPDATE BehaviourTracker 
                SET Agression = '" + track.Agression + "', Agitation ='" + track.Agitation + "', Apathy ='" + track.Apathy +"'," +
                " EatingProblems ='" + track.EatingProblems + "', ExcessiveCollecting ='" + track.ExcessiveCollecting +"'," +
                "ExcessiveOrganizing ='" + track.ExcessiveOrganizing + "',ImaginingThings ='" +track.ImaginingThings +"'," +
                " Impulsiveness ='" + track.ImaginingThings+ "',Incontinence ='" + track.Incontinence + "',Repetition ='" +track.Repetition +"'," +
                " ResistancetoCare ='" + track.ResistancetoCare+ "',Restlessness ='" +track.Restlessness + "',SafetyConcerns ='" +track.SafetyConcerns +"'," +
                "Sleeping ='" + track.Sleeping + "',Suspicion = '" + track.Suspicion + "', Wandering ='" +track.Wandering+ "' " + 
                "WHERE EmailAdd = '" + track.EmailAdd + "'";

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
                return track;

            }
            // if user is updating for first time it will simply add the data
            else
            {
                _context.BehaviourTracker.Add(track);

                await _context.SaveChangesAsync();

                Console.WriteLine("Created ");
                return track;
            }
        }
        //These Commented method can be used later to give more functionality to the program

        /*[HttpPost]
        public async Task<IActionResult> GetUser(UserInfo info)
        {

            string query = @"select EmailAdd,Password  from RegisterUsers
                            where EmailAdd = '" + info.EmailAdd + @"'";

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

            if (checkUser.Equals(info.EmailAdd) && pass.Equals(info.Password))
            {

                return Ok();
            }
            else
            {
                Console.WriteLine("in row" + checkUser);
                Console.WriteLine("in row" + pass);

                return Unauthorized();
            }



        }*/



        // GET: api/BehaviourTrackers
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<BehaviourTracker>>> GetBehaviourTracker()
        {
            return await _context.BehaviourTracker.ToListAsync();
        }

        // GET: api/BehaviourTrackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BehaviourTracker>> GetBehaviourTracker(string id)
        {
            var behaviourTracker = await _context.BehaviourTracker.FindAsync(id);

            if (behaviourTracker == null)
            {
                return NotFound();
            }

            return behaviourTracker;
        }
        */
        // PUT: api/BehaviourTrackers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutBehaviourTracker(string id, BehaviourTracker behaviourTracker)
        {
            if (id != behaviourTracker.EmailAdd)
            {
                return BadRequest();
            }

            _context.Entry(behaviourTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BehaviourTrackerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/
        /*
        // POST: api/BehaviourTrackers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BehaviourTracker>> PostBehaviourTracker(BehaviourTracker behaviourTracker)
        {
            _context.BehaviourTracker.Add(behaviourTracker);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BehaviourTrackerExists(behaviourTracker.EmailAdd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBehaviourTracker", new { id = behaviourTracker.EmailAdd }, behaviourTracker);
        }

        // DELETE: api/BehaviourTrackers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BehaviourTracker>> DeleteBehaviourTracker(string id)
        {
            var behaviourTracker = await _context.BehaviourTracker.FindAsync(id);
            if (behaviourTracker == null)
            {
                return NotFound();
            }

            _context.BehaviourTracker.Remove(behaviourTracker);
            await _context.SaveChangesAsync();

            return behaviourTracker;
        }
        
        private bool BehaviourTrackerExists(string id)
        {
            return _context.BehaviourTracker.Any(e => e.EmailAdd == id);
        }*/
    }
}
