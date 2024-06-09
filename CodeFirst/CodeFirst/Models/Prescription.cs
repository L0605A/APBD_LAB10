using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("prescriptions")]
public class Prescription
{
    [Key]
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [ForeignKey("patients")]
    public int IdPatient { get; set; }
    
    [ForeignKey("doctors")]
    public int IdDoctor { get; set; }
}