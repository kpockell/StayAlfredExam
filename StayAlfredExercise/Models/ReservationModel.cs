using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StayAlfredExercise.Models
{
  public class Reservation
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ReservationId { get; set; }

    public Guest Guest { get; set; }
    [Required]
    public Guid GuestId { get; set; }

    public Unit Unit { get; set; }
    [Required]
    public Guid UnitId { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }


  }
}
