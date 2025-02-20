using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace SalonIrisTicketsSchedule
{
    public partial class Form1 : Form
    {
        Tickets tickets = new Tickets();
        Form2 frm2 = new Form2();


        private static string ConfigPath = Application.StartupPath + "\\Config\\SalonIrisScheduler.txt";

        private static string Company;
        private static string Server;
        private static string Database;
        private static string DBUser;
        private static string DBPass;
        private static bool SSPI;
        private static int ApptNum;
        private static string ConnectionString;

        public Form1()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {


            Server = confserver.Text;
            Database = confdb.Text;
            Company = confcompany.Text;
            DBUser = serveruser.Text;
            DBPass = serverpass.Text;
            SSPI = checkbox11.Checked;

            if (int.TryParse(apptno.Text, out var apptNum))
            {
                ApptNum = apptNum;
            }
            else
            {
                ApptNum = 4;
            }

            //MessageBox.Show(server1 + " " + database1);
            if (Server.Length < 3 || Database.Length < 3 || DBUser.Length < 2)
            {
                MessageBox.Show("Not a Valid Server or DataBase");
                return;
            }

            ConnectionString = $"Data Source={Server};Initial Catalog={Database};Integrated Security={SSPI};UID={DBUser};PWD={DBPass};MultipleActiveResultSets=True;";

            Start();

            Hide();
        }

        private void Start()
        {
            //List schedule = new SISchedule();
            //if (File.Exists(Application.StartupPath + "\\Config\\SalonIrisScheduler.txt"))
            //{
            string[] lines = { Company, Server, Database, DBUser, DBPass, SSPI.ToString(), ApptNum.ToString() };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            File.WriteAllLines(ConfigPath, lines);
            //}


            string datetoday = "";
            datetoday = DateTime.Now.ToString("yyyy-MM-dd");
            //timenow = DateTime.Now.ToString("hh:mm:ss");
            //MessageBox.Show(datetoday);

            timer1.Enabled = true;
            timer1.Interval = 12000; // in miliseconds

            frm2.CompanyAirportName = confcompany.Text.ToUpper() + " - AIRPORT SALON SOFTWARE";

            frm2.Show();

            Task.Run(() => tickets.RefreshScreen(frm2));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete the Airport Salon Software configuration file?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.IO.File.Delete(Application.StartupPath + "\\Config\\SalonIrisScheduler.txt");
                confserver.Clear();
                confdb.Clear();
                confcompany.Clear();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(() => tickets.RefreshScreen(frm2));
        }



        public class Tickets
        {
            int page;
            int currentpage;
            Ticket prim;
            Ticket ult;
            //SqlDataReader reader;
            int cantElem;
            Boolean busy;
            Boolean formopen;

            public Tickets()
            {
                currentpage = 0;
                page = 0;
                prim = ult = null;
                cantElem = 0;
                busy = false;
                formopen = false;
            }

            public Boolean empty()
            {
                return (prim == null);
            }

            public void addTicket(int pagex, int idx, string timex, string stylist, int stid, string statusx, string appointmentx, string clientx, Ticket proxx)
            {
                if (empty())
                    prim = ult = new Ticket(pagex, idx, timex, stylist, stid, statusx, appointmentx, clientx, null);
                else
                {
                    ult.prox = new Ticket(pagex, idx, timex, stylist, stid, statusx, appointmentx, clientx, null);
                    ult = ult.prox;
                }
                cantElem = cantElem + 1;
            }

            public void deleteTickets()
            {
                currentpage = 0;
                page = 0;
                prim = ult = null;
                cantElem = 0;
                busy = false;
            }

            private static void SafeInvoke(Control control, Action action)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new MethodInvoker(() => action()));
                }
                else
                {
                    action();
                }
            }

            public void RefreshScreen(Form2 frm2)
            {

                string datetoday;
                string timenow = "13:35:00";
                string timeforquery2 = "";
                string hour = DateTime.Now.ToString("HH");
                string minutes = DateTime.Now.ToString("mm");

                SafeInvoke(frm2, () => frm2.watchtext = DateTime.Now.ToString("MMMM dd, h:mm").ToUpper());

                if (Convert.ToInt32(hour) >= 12)
                {
                    SafeInvoke(frm2, () => frm2.watchtext += " PM");
                }
                else
                {
                    SafeInvoke(frm2, () => frm2.watchtext += " AM");
                }

                string[] changetime;
                int apptTerm;
                int numberOfTickets;
                if (ApptNum == 4)
                {
                    changetime = new string[] { "00", "15", "30", "45" };
                    apptTerm = 15;
                    numberOfTickets = 8;
                }
                else
                {
                    changetime = new string[] { "00", "20", "40" };
                    apptTerm = 20;
                    numberOfTickets = 6;
                }
                string starttime = hour + ":" + changetime[changetime.Length - 1];
                /*if(apptno == 3){
                    starttime = hour + ":" + changetime3[arraynumber];
                    endtime = tohour + ":" + changetime3[arraynumber];
                }*/
                string starttotime = Convert.ToDateTime(starttime).AddMinutes(apptTerm).ToString("HH:mm");
                string time1 = Convert.ToDateTime(starttime).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime).ToString("h:mm");
                string starttotime2 = Convert.ToDateTime(starttotime).AddMinutes(apptTerm).ToString("HH:mm");
                string time2 = Convert.ToDateTime(starttotime).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime2).ToString("h:mm");
                string starttotime3 = Convert.ToDateTime(starttotime2).AddMinutes(apptTerm).ToString("HH:mm");
                string time3 = Convert.ToDateTime(starttotime2).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime3).ToString("h:mm");
                string starttotime4 = Convert.ToDateTime(starttotime3).AddMinutes(apptTerm).ToString("HH:mm");
                string time4 = Convert.ToDateTime(starttotime3).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime4).ToString("h:mm");
                string starttotime5 = Convert.ToDateTime(starttotime4).AddMinutes(apptTerm).ToString("HH:mm");
                string time5 = Convert.ToDateTime(starttotime4).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime5).ToString("h:mm");
                string starttotime6 = Convert.ToDateTime(starttotime5).AddMinutes(apptTerm).ToString("HH:mm");
                string time6 = Convert.ToDateTime(starttotime5).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime6).ToString("h:mm");
                string starttotime7 = Convert.ToDateTime(starttotime6).AddMinutes(apptTerm).ToString("HH:mm");
                string time7 = Convert.ToDateTime(starttotime6).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime7).ToString("h:mm");
                string starttotime8 = Convert.ToDateTime(starttotime7).AddMinutes(apptTerm).ToString("HH:mm");
                string time8 = Convert.ToDateTime(starttotime7).ToString("h:mm") + " - " + Convert.ToDateTime(starttotime8).ToString("h:mm");
                string[] timeforquery = { starttime, starttotime, starttotime2, starttotime3, starttotime4, starttotime5, starttotime6, starttotime7, starttotime8 };
                //MessageBox.Show(tohour);
                datetoday = DateTime.Now.ToString("yyyy-MM-dd");

                timeforquery2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                if (!busy)
                {
                    /*string query1 = @"SELECT 
E.fldEmployeeID AS ID, 
E.fldFirstName + ISNULL(' ' + E.fldLastName, '') as FirstName, 
S.fldDate as Date, 
S.fldStart as Start, S.fldEnd as DEnd, 
S.fldStart2 as Start2, S.fldEnd2 as DEnd2, 
S.fldStart3 as Start3, S.fldEnd3 as DEnd3, 
S.fldStart4 as Start4, S.fldEnd4 as DEnd4, 
S.fldStart5 as Start5, S.fldEnd5 as DEnd5, 
S.fldStart6 as Start6, S.fldEnd6 as DEnd6 
FROM tblScheduling S Join tblEmployees E on S.fldEmployeeID=E.fldEmployeeID where 
S.fldDate='" + datetoday + @"' AND (
(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart AS time) AND CAST(S.fldEnd AS time))
OR(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart2 AS time) AND CAST(S.fldEnd2 AS time))
OR(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart3 AS time) AND CAST(S.fldEnd3 AS time))
OR(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart4 AS time) AND CAST(S.fldEnd4 AS time))
OR(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart5 AS time) AND CAST(S.fldEnd5 AS time))
OR(CAST('" + timenow + @"' AS time) BETWEEN CAST(S.fldStart6 AS time) AND CAST(S.fldEnd6 AS time))
); ";*/

                    string query1 = @"SELECT 
E.fldEmployeeID AS ID, 
E.fldFirstName + ISNULL(' ' + E.fldLastName, '') as FirstName, 
S.fldDate as Date, 
S.fldStart as Start, S.fldEnd as DEnd, 
S.fldStart2 as Start2, S.fldEnd2 as DEnd2, 
S.fldStart3 as Start3, S.fldEnd3 as DEnd3, 
S.fldStart4 as Start4, S.fldEnd4 as DEnd4, 
S.fldStart5 as Start5, S.fldEnd5 as DEnd5, 
S.fldStart6 as Start6, S.fldEnd6 as DEnd6 
FROM tblScheduling S Join tblEmployees E on S.fldEmployeeID=E.fldEmployeeID where 
S.fldDate='" + datetoday + @"' AND (
('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd, 120), 8))))
OR('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart2, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd2, 120), 8))))
OR('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart3, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd3, 120), 8))))
OR('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart4, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd4, 120), 8))))
OR('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart5, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd5, 120), 8))))
OR('" + timeforquery2 + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart6, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldEnd6, 120), 8))))
); ";

                    //LTRIM(RIGHT(CONVERT(VARCHAR(20), S.fldStart, 120), 8))
                    //MessageBox.Show(query1);
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString))
                        using (SqlCommand cmd = new SqlCommand(query1, connection))
                        {
                            //MessageBox.Show("waiting");

                            connection.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Check is the reader has any rows at all before starting to read.
                                if (reader.HasRows)
                                {

                                    busy = true;
                                    // Read advances to the next row.
                                    while (reader.Read())
                                    {
                                        page++;
                                        string employeename = reader.GetString(reader.GetOrdinal("FirstName"));
                                        //MessageBox.Show(employeename);
                                        int IDDB = reader.GetInt32(reader.GetOrdinal("ID"));
                                        try
                                        {
                                            int ticketsid = 0;
                                            while (ticketsid < numberOfTickets)
                                            {
                                                string ticketstatus = "Available";
                                                string apptstatus = "Available";
                                                string timeblock = "";
                                                string clientname = "";
                                                /*string query2 = @"SELECT top 1 t.fldStartDateTime,  s.fldTicketStatus as fldTicketStatus, s.fldCompleted as fldCompleted, s.fldCheckedIn as fldCheckedIn
                        FROM tblTicketsRow t join tblTicketsSummary s on t.fldTicketID=s.fldTicketID  join tblScheduling SC on t.fldEmployeeID=SC.fldEmployeeID 
                        where t.fldEmployeeID=" + IDDB + @" AND 
                        ((t.fldStartDateTime >= cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as datetime) 
                        and t.fldStartDateTime < cast('" + datetoday + @" " + timeforquery[ticketsid+1] + @"' as datetime)) 
                        ) and ((cast('"+datetoday + @" " + timeforquery[ticketsid]+ @"' as time) between CAST(SC.fldStart AS time) AND CAST(SC.fldEnd AS time))
or (cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as time) between CAST(SC.fldStart2 AS time) AND CAST(SC.fldEnd2 AS time))
or (cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as time) between CAST(SC.fldStart3 AS time) AND CAST(SC.fldEnd3 AS time))
or (cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as time) between CAST(SC.fldStart4 AS time) AND CAST(SC.fldEnd4 AS time))
or (cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as time) between CAST(SC.fldStart5 AS time) AND CAST(SC.fldEnd5 AS time))
or (cast('" + datetoday + @" " + timeforquery[ticketsid] + @"' as time) between CAST(SC.fldStart6 AS time) AND CAST(SC.fldEnd6 AS time))
);";*/

                                                /*string query2 = @"SELECT top 1 t.fldStartDateTime,  s.fldTicketStatus as fldTicketStatus, s.fldCompleted as fldCompleted, s.fldCheckedIn as fldCheckedIn, ISNULL('' + s.fldFirstName,'') + ISNULL(' ' + s.fldLastName, '')  as ClientName, t.fldDescription as Description 
                        FROM tblTicketsRow t join tblTicketsSummary s on t.fldTicketID=s.fldTicketID  join tblScheduling SC on t.fldEmployeeID=SC.fldEmployeeID 
                        where t.fldEmployeeID=" + IDDB + @" AND 
                        ((t.fldStartDateTime >= '" + datetoday + @" " + timeforquery[ticketsid] + @"' 
                        and t.fldStartDateTime < '" + datetoday + @" " + timeforquery[ticketsid + 1] + @"') 
                        ) and (('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart2, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd2, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart3, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd3, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart4, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd4, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart5, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd5, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart6, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd6, 120), 8))))
) order by t.fldTicketID DESC;";*/
                                                string query2 = @"SELECT top 1 t.fldStartDateTime,  s.fldTicketStatus as fldTicketStatus, s.fldCompleted as fldCompleted, s.fldCheckedIn as fldCheckedIn, ISNULL('' + s.fldFirstName,'') + ISNULL(' ' + s.fldLastName, '')  as ClientName, t.fldDescription as Description 
                        FROM tblTicketsRow t join tblTicketsSummary s on t.fldTicketID=s.fldTicketID  join tblScheduling SC on t.fldEmployeeID=SC.fldEmployeeID 
                        where t.fldEmployeeID=" + IDDB + @" AND 
                        ((t.fldStartDateTime <= '" + datetoday + @" " + timeforquery[ticketsid] + @"' 
                        and t.fldEndDateTime >= '" + datetoday + @" " + timeforquery[ticketsid + 1] + @"' and s.fldTicketStatus!='Canceled') 
                        ) and (('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart2, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd2, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart3, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd3, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart4, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd4, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart5, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd5, 120), 8))))
or ('" + datetoday + @" " + timeforquery[ticketsid] + @"' BETWEEN convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldStart6, 120), 8))) AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), SC.fldEnd6, 120), 8))))
) order by t.fldTicketID DESC;";
                                                //MessageBox.Show(query2);
                                                //MessageBox.Show(query2);
                                                //return;
                                                using (SqlCommand cmd2 = new SqlCommand(query2, connection))
                                                {
                                                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                                    {
                                                        // Check is the reader has any rows at all before starting to read.
                                                        if (reader2.HasRows)
                                                        {
                                                            while (reader2.Read())
                                                            {
                                                                string apptcontrol;
                                                                apptcontrol = ticketstatus = reader2.GetString(reader2.GetOrdinal("fldTicketStatus"));
                                                                clientname = reader2.GetString(reader2.GetOrdinal("ClientName"));
                                                                timeblock = reader2.GetString(reader2.GetOrdinal("Description"));
                                                                //MessageBox.Show(timeblock);
                                                                if (timeblock.Contains("Time Block"))
                                                                {
                                                                    clientname = "Time Block";
                                                                }

                                                                Boolean checkin = false;
                                                                if (!reader2.IsDBNull(reader2.GetOrdinal("fldCheckedIn")))
                                                                    checkin = true;
                                                                if (ticketstatus == "Open")
                                                                {
                                                                    //apptcontrol = ticketstatus;
                                                                    ticketstatus = "Taken";
                                                                }
                                                                if (apptcontrol == "Open" && checkin == true)
                                                                {
                                                                    apptstatus = "Arrived";
                                                                }
                                                                else if (apptcontrol == "Open" && checkin == false)
                                                                {
                                                                    apptstatus = "On Schedule";
                                                                }
                                                                else if (reader2.GetBoolean(reader2.GetOrdinal("fldCompleted")) || apptcontrol == "Closed")
                                                                {
                                                                    apptstatus = "Done";
                                                                }

                                                                //MessageBox.Show(query2);

                                                            }
                                                        }

                                                        reader2.Close();
                                                    }
                                                    //cmd2.Dispose();
                                                    //reader2.Close();
                                                }
                                                ticketsid++;
                                                //MessageBox.Show(employeename);
                                                addTicket(page, ticketsid, datetoday + " " + timeforquery[ticketsid], employeename, IDDB, ticketstatus, apptstatus, clientname, null);
                                                //Person p = new Person();

                                                // To avoid unexpected bugs access columns by name.
                                                //frm2.LabelText = Convert.ToString(reader.GetInt32(reader.GetOrdinal("ID")));
                                                //p.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                                //p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                                // If a column is nullable always check for DBNull...
                                                //if (!reader.IsDBNull(middleNameIndex))
                                                //{
                                                //    p.MiddleName = reader.GetString(middleNameIndex);
                                                //}
                                                //p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                                //persons.Add(p);
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show("There's a problem with the tickets table");
                                            SafeInvoke(frm2, () => frm2.Close());
                                            System.Windows.Forms.Application.Exit();
                                            return;
                                        }

                                    }
                                }
                                reader.Close();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("There was a problem with the connection to the Server or Database. Please check your configuration");
                        SafeInvoke(frm2, () => frm2.Close());
                        System.Windows.Forms.Application.Exit();
                        return;
                    }
                }
                currentpage++;
                //MessageBox.Show(currentpage + " = " + page);
                if (currentpage > page)
                {
                    deleteTickets();
                }
                else
                {
                    string[] times = new string[] { time1, time2, time3, time4, time5, time6, time7, time8 };
                    AssignValuesToForm2(numberOfTickets, times, currentpage, frm2, datetoday);
                    string closingtime = "";
                    string queryct = @"SELECT top 1
    CASE
        WHEN fldEnd >= fldEnd2 AND fldEnd >= fldEnd3 AND fldEnd >= fldEnd4 AND fldEnd >= fldEnd5 AND fldEnd >= fldEnd6 THEN fldEnd
        WHEN fldEnd2 >= fldEnd AND fldEnd2 >= fldEnd3 AND fldEnd2 >= fldEnd4 AND fldEnd2 >= fldEnd5 AND fldEnd2 >= fldEnd6 THEN fldEnd2
        WHEN fldEnd3 >= fldEnd AND fldEnd3 >= fldEnd2 AND fldEnd3 >= fldEnd4 AND fldEnd3 >= fldEnd5 AND fldEnd3 >= fldEnd6 THEN fldEnd3
        WHEN fldEnd4 >= fldEnd AND fldEnd4 >= fldEnd2 AND fldEnd4 >= fldEnd4 AND fldEnd4 >= fldEnd5 AND fldEnd4 >= fldEnd6 THEN fldEnd4
        WHEN fldEnd5 >= fldEnd AND fldEnd5 >= fldEnd2 AND fldEnd5 >= fldEnd4 AND fldEnd5 >= fldEnd5 AND fldEnd5 >= fldEnd6 THEN fldEnd5
        WHEN fldEnd6 >= fldEnd AND fldEnd6 >= fldEnd2 AND fldEnd6 >= fldEnd4 AND fldEnd6 >= fldEnd5 AND fldEnd6 >= fldEnd6 THEN fldEnd6
        ELSE fldEnd
    END AS MostRecentDate from tblScheduling where fldDate = '" + datetoday + @"' order by MostRecentDate desc";
                    try
                    {
                        using (SqlConnection connection3 = new SqlConnection(ConnectionString))
                        using (SqlCommand cmd3 = new SqlCommand(queryct, connection3))
                        {
                            //MessageBox.Show("waiting");

                            connection3.Open();
                            using (SqlDataReader reader3 = cmd3.ExecuteReader())
                            {
                                // Check is the reader has any rows at all before starting to read.
                                if (reader3.HasRows)
                                {
                                    while (reader3.Read())
                                    {
                                        closingtime = reader3.GetDateTime(reader3.GetOrdinal("MostRecentDate")).ToString("h:mm tt", new System.Globalization.CultureInfo("en-US"));
                                    }
                                }
                                reader3.Close();
                                connection3.Close();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Problem with query of CLosing Time");
                    }
                    /*
                    frm2.employee2 = getStylist2;
                    frm2.employee3 = getStylist2;
                    frm2.employee4 = getStylist2;
                    frm2.employee5 = getStylist2;
                    frm2.employee6 = getStylist2;
                    frm2.employee7 = getStylist2;
                    frm2.employee8 = getStylist2;
                    
                    frm2.appt2 = getStatus(2 , currentpage);
                    frm2.appt3 = getStatus(3 , currentpage);
                    frm2.appt4 = getStatus(4 , currentpage);
                    frm2.appt5 = getStatus(5 , currentpage);
                    frm2.appt6 = getStatus(6 , currentpage);
                    frm2.appt7 = getStatus(7 , currentpage);
                    frm2.appt8 = getStatus(8 , currentpage);
                    
                    frm2.stat2 = getAppt(2 , currentpage);
                    frm2.stat3 = getAppt(3 , currentpage);
                    frm2.stat4 = getAppt(4 , currentpage);
                    frm2.stat5 = getAppt(5 , currentpage);
                    frm2.stat6 = getAppt(6 , currentpage);
                    frm2.stat7 = getAppt(7 , currentpage);
                    frm2.stat8 = getAppt(8 , currentpage);*/
                    SafeInvoke(frm2, () => frm2.pagetext = "Page " + currentpage + " of " + page);
                    string ampm = "AM";
                    if (Convert.ToInt32(Convert.ToDateTime(starttime).ToString("HH")) >= 12)
                        ampm = "PM";
                    string ampm2 = "AM";
                    if (Convert.ToInt32(Convert.ToDateTime(starttotime8).ToString("HH")) >= 12)
                        ampm2 = "PM";
                    if (ApptNum == 4)
                    {
                        SafeInvoke(frm2, () => frm2.showtext = "SHOWING TIME: " + Convert.ToDateTime(starttime).ToString("h:mm") + " " + ampm + " to " + Convert.ToDateTime(starttotime8).ToString("h:mm") + " " + ampm2 + "   TODAY CLOSING TIME: " + closingtime);
                    }
                    else
                    {
                        SafeInvoke(frm2, () => frm2.showtext = "SHOWING TIME: " + Convert.ToDateTime(starttime).ToString("h:mm") + " " + ampm + " to " + Convert.ToDateTime(starttotime6).ToString("h:mm") + " " + ampm2 + "   TODAY CLOSING TIME: " + closingtime);
                    }

                }
                //MessageBox.Show("hi1");


            }

            public string getTime(int idx, int pagex, int stid)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex && p.Stid == stid)
                        return p.Time;
                    p = p.prox;
                }
                return "";
            }

            public string getStatus(int idx, int pagex)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex)
                        return p.Status;
                    p = p.prox;
                }
                return "";
            }

            public string getClient(int idx, int pagex)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex)
                        return p.Client;
                    p = p.prox;
                }
                return "";
            }

            public string getStylist(int pagex, int idx)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex)
                        return p.Stylist;
                    p = p.prox;
                }
                return "";
            }

            public int getStid(int pagex, int idx)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex)
                        return p.Stid;
                    p = p.prox;
                }
                return 0;
            }

            public string getAppt(int idx, int pagex)
            {
                Ticket p = prim;
                while (p != null)
                {
                    if (p.Id == idx && p.Page == pagex)
                        return p.Appointment;
                    p = p.prox;
                }
                return "";
            }

            private void AssignValuesToForm2(int numberOfTickets, string[] times, int currentpage, Form2 frm2, string datetoday)
            {
                var form2Type = frm2.GetType();

                for (int i = 0; i < numberOfTickets; i++)
                {

                    SafeInvoke(frm2, () => form2Type.GetProperty(string.Format("hora{0}", i + 1)).SetValue(frm2, times[i]));
                    int stidget = getStid(currentpage, 1);
                    string getStylist2 = getStylist(currentpage, 1);
                    string timex = getTime(i + 1, currentpage, stidget);
                    string query = @"SELECT TOP 1 *
                FROM tblScheduling where fldDate = '" + datetoday + @"' and fldEmployeeID = " + stidget + @"
                and(
                '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart, 120), 8)))
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd, 120), 8)))
                or '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart2, 120), 8)))
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd2, 120), 8)))
                or '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart3, 120), 8))) 
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd3, 120), 8)))
                or '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart4, 120), 8))) 
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd4, 120), 8)))
                or '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart5, 120), 8))) 
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd5, 120), 8)))
                or '" + timex + @"' between convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldStart6, 120), 8))) 
                AND convert(datetime, '" + datetoday + @"' +' ' +LTRIM(RIGHT(CONVERT(VARCHAR(20), fldEnd6, 120), 8)))
                )";
                    try
                    {
                        using (SqlConnection connection3 = new SqlConnection(ConnectionString))
                        using (SqlCommand cmd3 = new SqlCommand(query, connection3))
                        {
                            //MessageBox.Show("waiting");

                            connection3.Open();
                            using (SqlDataReader reader3 = cmd3.ExecuteReader())
                            {
                                // Check is the reader has any rows at all before starting to read.
                                if (reader3.HasRows)
                                {
                                    SafeInvoke(frm2, () =>
                                    {
                                        form2Type.GetProperty(string.Format("employee{0}", i + 1)).SetValue(frm2, getStylist2);
                                        form2Type.GetProperty(string.Format("appt{0}", i + 1)).SetValue(frm2, getAppt(i + 1, currentpage));
                                        form2Type.GetProperty(string.Format("stat{0}", i + 1)).SetValue(frm2, getStatus(i + 1, currentpage));
                                        form2Type.GetProperty(string.Format("clientt{0}", i + 1)).SetValue(frm2, getClient(i + 1, currentpage));
                                    });
                                }
                                else
                                {
                                    SafeInvoke(frm2, () =>
                                    {
                                        form2Type.GetProperty(string.Format("employee{0}", i + 1)).SetValue(frm2, "");
                                        form2Type.GetProperty(string.Format("appt{0}", i + 1)).SetValue(frm2, "");
                                        form2Type.GetProperty(string.Format("stat{0}", i + 1)).SetValue(frm2, "");
                                        form2Type.GetProperty(string.Format("clientt{0}", i + 1)).SetValue(frm2, "");
                                    });

                                }
                                reader3.Close();
                                connection3.Close();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problem with query of Schedules");
                        MessageBox.Show(query);
                        return;
                    }
                }

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting Default 4 for number of appointments 
            apptno.Text = "4";

            if (File.Exists(ConfigPath))
            {
                var lines = File.ReadAllLines(ConfigPath);

                if(lines.Length < 7)
                {
                    return;
                }

                Company = lines?[0];
                Server = lines?[1];
                Database = lines?[2];
                DBUser = lines?[3];
                DBPass = lines?[4];
                SSPI = lines?[5]?.ToLower() == "sspi" || lines?[5]?.ToLower() == "true";

                if (int.TryParse(lines[6], out var appNo))
                {
                    ApptNum = appNo;
                }
            }
            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
            confcompany.Text = Company;
            confserver.Text = Server;
            confdb.Text = !string.IsNullOrEmpty(Database) ? "SalonIris" : Database;
            serveruser.Text = DBUser;
            serverpass.Text = DBPass;
            checkbox11.Checked = SSPI;
            apptno.Text = ApptNum.ToString();
        }

        /*public class Persons
{
    List<Person> lstPersons = new List<Person>();

    public void AddPerson(string FirstName, ...)
    {
        Person person = new Person();
        person.strFirstName = FirstName;
        ...
        lstPersons.Add(person);
    }
}*/
    }
}
