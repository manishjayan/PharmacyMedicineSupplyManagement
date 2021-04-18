using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharamcyMedicineSupplyPortal.Models
{
    public class RepSchedule
    {
        public string Name { get; set; }
        public string Doctorname { get; set; }
        public string MeetingSlot { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dateofmeeting { get; set; }
        public string DoctorContactnumber { get; set; }

        public string TreatingAlignment { get; set; }

        public List<string> Medicine { get; set; }
    }
}
