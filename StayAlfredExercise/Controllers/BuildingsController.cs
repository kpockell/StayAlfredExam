using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StayAlfredExercise;
using StayAlfredExercise.Models;

namespace StayAlfredExercise.Controllers
{
    public class BuildingsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Buildings
        public IQueryable<Building> GetBuildings()
        {
            return db.Buildings;
        }

        // GET: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> GetBuilding(string id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // PUT: api/Buildings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBuilding(string id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.BuildingId)
            {
                return BadRequest();
            }

            db.Entry(building).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Buildings
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buildings.Add(building);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingExists(building.BuildingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = building.BuildingId }, building);
        }

        // DELETE: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> DeleteBuilding(string id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            db.Buildings.Remove(building);
            await db.SaveChangesAsync();

            return Ok(building);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuildingExists(string id)
        {
            return db.Buildings.Count(e => e.BuildingId == id) > 0;
        }
    }
}