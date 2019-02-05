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
    public class UnitsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Units
        public IQueryable<Unit> GetUnits()
        {
            return db.Units;
        }

        // GET: api/Units/5
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> GetUnit(Guid id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/Units/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnit(string id, Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.UnitId.ToString())
            {
                return BadRequest();
            }

            db.Entry(unit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> PostUnit(Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Units.Add(unit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitExists(unit.UnitId.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = unit.UnitId }, unit);
        }

        // DELETE: api/Units/5
        [ResponseType(typeof(Unit))]
        public async Task<IHttpActionResult> DeleteUnit(string id)
        {
            Unit unit = await db.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            db.Units.Remove(unit);
            await db.SaveChangesAsync();

            return Ok(unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitExists(string id)
        {
            return db.Units.Count(e => e.UnitId.ToString() == id) > 0;
        }
    }
}
