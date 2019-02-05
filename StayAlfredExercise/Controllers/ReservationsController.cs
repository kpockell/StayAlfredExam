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
    public class ReservationsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations;
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> GetReservation(Guid id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // GET: api/Reservations/{unitId}
        [Route("api/Reservations/{unitId}")]
        public IQueryable<Reservation> GetReservations(string unitId)
        {
            return db.Reservations.Where(r => r.UnitId.ToString() == unitId);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReservation(Guid id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reservation.ReservationId }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public async Task<IHttpActionResult> DeleteReservation(Guid id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(Guid id)
        {
            return db.Reservations.Count(e => e.ReservationId == id) > 0;
        }
    }
}
