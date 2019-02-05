using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StayAlfredExercise.Models
{
  public class Guest
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid GuestId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
