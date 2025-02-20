using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonIrisTicketsSchedule
{
    public class Ticket
    {
        int page;
        int id;
        string time;
        string stylist;
        int stid;
        string status;
        string appointment;
        string client;
        public Ticket prox;
        public int Page { get { return page; } }
        public int Id { get { return id; } }
        public String Time { get { return time; } }
        public String Stylist { get { return stylist; } }
        public String Status { get { return status; } }
        public String Appointment { get { return appointment; } }
        public String Client { get { return client; } }

        public int Stid { get => stid; set => stid = value; }

        public Ticket(int pagex, int idx, string timex, string stylistx, int stidx, string statusx, string appointmentx, string clientx, Ticket proxx)
        {
            page = pagex;
            id = idx;
            time = timex;
            stylist = stylistx;
            Stid = stidx;
            status = statusx;
            appointment = appointmentx;
            client = clientx;
            prox = proxx;
        }



    }
}
