using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace MedicineStock_Microservice.Entity
{
    public class MedicineStock
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ChemicalComposition { get; set; }
        public string TargetAilment { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public int NumberOfTabletsInStock { get; set; }
    }
}
