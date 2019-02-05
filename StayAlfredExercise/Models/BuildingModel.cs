using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StayAlfredExercise.Models
{
  public class Building
  {
    [Key]
    [StringLength(2)]
    public string BuildingId { get; set; }
    [Required]
    public string BuildingName { get; set; }
  }
}
