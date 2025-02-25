using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonIrisTicketsSchedule.Models
{
    public class Ticket
    {
        public DateTime? StartDateTime { get; set; }
        public int? EmployeeId { get; set; }
        public string TicketStatus { get; set; }
        public bool? Completed { get; set; }
        public bool? CheckedIn { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public DateTime? EndDateTime { get; internal set; }
        public int? PK { get; internal set; }
    }
}
