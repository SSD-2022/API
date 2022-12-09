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
                SET Agression = '" + track.Agression + "', Agitation ='" + track.Agitation + "', Apathy ='" + track.Apathy + "'," +
                " EatingProblems ='" + track.EatingProblems + "', ExcessiveCollecting ='" + track.ExcessiveCollecting + "'," +
                "ExcessiveOrganizing ='" + track.ExcessiveOrganizing + "',ImaginingThings ='" + track.ImaginingThings + "'," +
                " Impulsiveness ='" + track.ImaginingThings + "',Incontinence ='" + track.Incontinence + "',Repetition ='" + track.Repetition + "'," +
                " ResistancetoCare ='" + track.ResistancetoCare + "',Restlessness ='" + track.Restlessness + "',SafetyConcerns ='" + track.SafetyConcerns + "'," +
                "Sleeping ='" + track.Sleeping + "',Suspicion = '" + track.Suspicion + "', Wandering ='" + track.Wandering + "' " +
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
    }
}
