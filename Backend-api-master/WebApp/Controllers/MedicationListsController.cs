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
    /// This class will handle all calls made to api/medicalhistories
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationListsController : ControllerBase
    {
        private readonly IConfiguration _iconfigurations;
        private readonly DbContext_dpal _context;


        /// <summary>
        /// Constructor to read configuration and get context to database
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        public MedicationListsController(IConfiguration configuration, DbContext_dpal context)
        {

            _iconfigurations = configuration;
            _context = context;


        }

        /// <summary>
        /// this method is used to get list of all the medications setup for a user
        /// </summary>
        /// <param name="emailAdd"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetMedications([FromQuery(Name = "emailAdd")] string emailAdd ) {

            Console.WriteLine("Here in medication List controller");

            string query = @"select MedName,MedDescp,Dosage  from MedicationList
                            where EmailAdd = '" + emailAdd.ToLower() + "'";

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


        // PUT: api/MedicationLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicationList(Guid id, MedicationList medicationList)
        {
            if (id != medicationList.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicationList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationListExists(id))
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

        
        // POST: api/MedicationLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// whenever a new medication is saved this method gets called and saved that medication to database 
        /// </summary>
        /// <param name="medicationList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MedicationList>> PostMedicationList(MedicationList medicationList)
        {
            _context.MedicationList.Add(medicationList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicationList", new { id = medicationList.Id }, medicationList);
        }

        // DELETE: api/MedicationLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicationList>> DeleteMedicationList(Guid id)
        {
            var medicationList = await _context.MedicationList.FindAsync(id);
            if (medicationList == null)
            {
                return NotFound();
            }

            _context.MedicationList.Remove(medicationList);
            await _context.SaveChangesAsync();

            return medicationList;
        }

        private bool MedicationListExists(Guid id)
        {
            return _context.MedicationList.Any(e => e.Id == id);
        }
    }
}
