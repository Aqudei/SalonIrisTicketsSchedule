using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonIrisTicketsSchedule.Models
{
    public class Entry
    {
        public string Time { get; set; }
        public string Stylist { get; set; }
        public string Status { get; set; }
        public string Appointment { get; set; }
        public string Client { get; set; }
        public DateTime StartDateTime { get; internal set; }
        public DateTime EndDateTime { get; internal set; }
    }
}
