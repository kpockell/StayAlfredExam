using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StayAlfredExercise.Models
{
  public class Unit
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UnitId { get; set; }

    [NotMapped]
    public string CompositeId
    {
      get
      {
        return $"{this.UnitNumber} {this.BuildingId}{this.Bedrooms}{this.Bathrooms}";
      }
    }
    [Required]
    public string UnitNumber { get; set; }

    public Building Building { get; set; }
    [Required]
    public string BuildingId { get; set; }
    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int SquareFootage { get; set; }
  }
}
