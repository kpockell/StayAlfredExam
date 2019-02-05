using StayAlfredExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StayAlfredExercise
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(): base("StayAlfredExercise") { }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
  }
}
