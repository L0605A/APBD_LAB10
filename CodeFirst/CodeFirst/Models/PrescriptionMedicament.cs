using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("PrescriptionMedicaments")]

[PrimaryKey(nameof(IdPrescription), nameof(IdMedicament))]
public class PrescriptionMedicament
{
    public int IdPrescription { get; set; }

    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; } = string.Empty;

}