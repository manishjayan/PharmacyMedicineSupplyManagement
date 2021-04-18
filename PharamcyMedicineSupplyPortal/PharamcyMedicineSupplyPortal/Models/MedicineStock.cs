using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharamcyMedicineSupplyPortal.Models
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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfExpiry { get; set; }
        public int NumberOfTabletsInStock { get; set; }
    }
}
