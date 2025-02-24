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
using System.Windows;
using static SalonIrisTicketsSchedule.Form1;
using System.Diagnostics;
using SalonIrisTicketsSchedule.Models;

namespace SalonIrisTicketsSchedule
{
    public partial class ConnectionForm : Form
    {
        private string ConnectionString;
        private SqlConnection _connection;
        private int _currentPage;
        private Form2 _form2;

        public HashSet<Models.Ticket> Tickets { get; set; } = new HashSet<Models.Ticket>();

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            
        }

        private void LoadSettings()
        {
            CompanyTextBox.Text = Properties.Settings.Default.Company;
            ServerNameTextBox.Text = Properties.Settings.Default.Server;
            DatabaseTextBox.Text = Properties.Settings.Default.Database;
            DBUserTextBox.Text = Properties.Settings.Default.DBUser;
            DBPasswordTextBox.Text = Properties.Settings.Default.DBPass;
            SSPICheckBox.Checked = Properties.Settings.Default.SSPI;
            AppointmentPerHourComboBox.Text = Properties.Settings.Default.AppointmentNum.ToString();
        }

        private void SaveAndConnectButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            ConnectionString = $"Data Source={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Integrated Security={Properties.Settings.Default.SSPI};UID={Properties.Settings.Default.DBUser};PWD={Properties.Settings.Default.DBPass};MultipleActiveResultSets=True;";


            _form2 = new Form2();
            _form2.Show();

            // CycleTimer.Start();

            RefreshScreen();
            Hide();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Company = CompanyTextBox.Text;
            Properties.Settings.Default.Server = ServerNameTextBox.Text;
            Properties.Settings.Default.Database = DatabaseTextBox.Text;
            Properties.Settings.Default.DBUser = DBUserTextBox.Text;
            Properties.Settings.Default.DBPass = DBPasswordTextBox.Text;
            Properties.Settings.Default.SSPI = SSPICheckBox.Checked;

            if (int.TryParse(AppointmentPerHourComboBox.Text, out var apptPerHour))
            {
                Properties.Settings.Default.AppointmentNum = apptPerHour;
            }
            else
            {
                Properties.Settings.Default.AppointmentNum = 4;
            }

            Properties.Settings.Default.Save();
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(RefreshScreen);
        }

        public SqlConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }

            return _connection;
        }


        private List<Models.Schedule> GetSchedules(DateTime date)
        {
            var result = new List<Models.Schedule>();

            using (var connection = GetOpenConnection())
            {
                string query = @"
                        SELECT 
                            E.fldEmployeeID AS ID, 
                            E.fldFirstName + ISNULL(' ' + E.fldLastName, '') AS FirstName, 
                            S.fldDate AS Date, 
                            S.fldStart AS Start, 
                            S.fldEnd AS DEnd, 
                            S.fldStart2 AS Start2, 
                            S.fldEnd2 AS DEnd2, 
                            S.fldStart3 AS Start3, 
                            S.fldEnd3 AS DEnd3, 
                            S.fldStart4 AS Start4, 
                            S.fldEnd4 AS DEnd4, 
                            S.fldStart5 AS Start5, 
                            S.fldEnd5 AS DEnd5, 
                            S.fldStart6 AS Start6, 
                            S.fldEnd6 AS DEnd6 
                        FROM 
                            tblScheduling S 
                            JOIN tblEmployees E ON S.fldEmployeeID = E.fldEmployeeID 
                        WHERE 
                            CAST(S.fldDate AS Date) = CAST(@today AS Date);";


                using (var cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@today", date);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(new Models.Schedule
                                {
                                    EmployeeID = reader.IsDBNull(reader.GetOrdinal("ID"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("ID")),

                                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName"))
                                        ? string.Empty
                                        : reader.GetString(reader.GetOrdinal("FirstName")),

                                    Date = reader.IsDBNull(reader.GetOrdinal("Date"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Date")),

                                    Start = reader.IsDBNull(reader.GetOrdinal("Start"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start")),

                                    DEnd = reader.IsDBNull(reader.GetOrdinal("DEnd"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd")),

                                    Start2 = reader.IsDBNull(reader.GetOrdinal("Start2"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start2")),

                                    DEnd2 = reader.IsDBNull(reader.GetOrdinal("DEnd2"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd2")),

                                    Start3 = reader.IsDBNull(reader.GetOrdinal("Start3"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start3")),

                                    DEnd3 = reader.IsDBNull(reader.GetOrdinal("DEnd3"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd3")),

                                    Start4 = reader.IsDBNull(reader.GetOrdinal("Start4"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start4")),

                                    DEnd4 = reader.IsDBNull(reader.GetOrdinal("DEnd4"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd4")),

                                    Start5 = reader.IsDBNull(reader.GetOrdinal("Start5"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start5")),

                                    DEnd5 = reader.IsDBNull(reader.GetOrdinal("DEnd5"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd5")),

                                    Start6 = reader.IsDBNull(reader.GetOrdinal("Start6"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("Start6")),

                                    DEnd6 = reader.IsDBNull(reader.GetOrdinal("DEnd6"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("DEnd6")),
                                });
                            }

                            return result;
                        }
                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                }

            }

            return new List<Models.Schedule>();
        }


        private List<Models.Ticket> GetTickets(DateTime date)
        {
            var result = new List<Models.Ticket>();

            using (var connection = GetOpenConnection())
            {
                string query = @"
                        SELECT DISTINCT(t.fldPK),
                        t.fldStartDateTime,  
                        t.fldEndDateTime,  
                        t.fldEmployeeID,
                        s.fldTicketStatus AS fldTicketStatus, 
                        s.fldCompleted AS fldCompleted, 
                        s.fldCheckedIn AS fldCheckedIn, 
                        ISNULL('' + s.fldFirstName, '') + ISNULL(' ' + s.fldLastName, '') AS ClientName, 
                        t.fldDescription AS Description 
                    FROM 
                        tblTicketsRow t 
                        JOIN tblTicketsSummary s ON t.fldTicketID = s.fldTicketID  
                        JOIN tblScheduling SC ON t.fldEmployeeID = SC.fldEmployeeID 
                    WHERE 
                        CAST(t.fldStartDateTime AS DATE) = CAST(@today AS DATE)
                        AND s.fldTicketStatus != 'Canceled';";


                using (var cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@today", date);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var employeeId = reader.IsDBNull(reader.GetOrdinal("fldEmployeeID"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("fldEmployeeID"));

                                result.Add(new Models.Ticket
                                {
                                    CheckedIn = reader.IsDBNull(reader.GetOrdinal("fldCheckedIn"))
                                        ? (bool?)null
                                        : reader.GetBoolean(reader.GetOrdinal("fldCheckedIn")),

                                    ClientName = reader.IsDBNull(reader.GetOrdinal("ClientName"))
                                        ? string.Empty
                                        : reader.GetString(reader.GetOrdinal("ClientName")),

                                    Completed = reader.IsDBNull(reader.GetOrdinal("fldCompleted"))
                                        ? (bool?)null
                                        : reader.GetBoolean(reader.GetOrdinal("fldCompleted")),

                                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                        ? string.Empty
                                        : reader.GetString(reader.GetOrdinal("Description")),

                                    EmployeeId = employeeId,

                                    StartDateTime = reader.IsDBNull(reader.GetOrdinal("fldStartDateTime"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("fldStartDateTime")),

                                    EndDateTime = reader.IsDBNull(reader.GetOrdinal("fldEndDateTime"))
                                        ? (DateTime?)null
                                        : reader.GetDateTime(reader.GetOrdinal("fldEndDateTime")),

                                    TicketStatus = reader.IsDBNull(reader.GetOrdinal("fldTicketStatus"))
                                        ? string.Empty
                                        : reader.GetString(reader.GetOrdinal("fldTicketStatus"))
                                });
                            }

                            return result;
                        }
                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                }

            }

            return new List<Models.Ticket>();
        }

        private void RefreshScreen()
        {
            // var now = DateTime.Now;

            var now = DateTime.Parse("2025-02-19 13:00");

            var tickets = GetTickets(now.Date);
            var schedules = GetSchedules(now.Date);

            var start = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            var minutesIncrement = (int)(60 / Properties.Settings.Default.AppointmentNum);

            var numRows = Properties.Settings.Default.AppointmentNum == 4 ? 8 : 6;
            var entries = new List<Entry>();
            foreach (var schedule in schedules.OrderBy(x => x.EmployeeID))
            {
                for (int i = 0; i < numRows; i++)
                {
                    var startTime = start.AddMinutes(i * minutesIncrement);
                    var endTime = start.AddMinutes((i + 1) * minutesIncrement);
                    var entryAdded = false;

                    foreach (var ticket in tickets)
                    {
                        if (ticket.EmployeeId != schedule.EmployeeID)
                        {
                            continue;
                        }

                        if (!(startTime >= ticket.StartDateTime) || !(endTime <= ticket.EndDateTime))
                        {
                            continue;
                        }

                        var appointment = ticket.TicketStatus;
                        if (ticket.TicketStatus == "Open" && ticket.CheckedIn.HasValue && ticket.CheckedIn.Value)
                        {
                            appointment = "Arrived";
                        }
                        if (ticket.TicketStatus == "Open" && (!ticket.CheckedIn.HasValue || !ticket.CheckedIn.Value))
                        {
                            appointment = "On Schedule";
                        }
                        var client = ticket.ClientName;
                        var isTimeBlock = ticket.Description?.ToLower().Contains("time block");
                        if (isTimeBlock.HasValue && isTimeBlock.Value)
                        {
                            client = "Time Block";
                        }

                        if ((ticket.Completed.HasValue && ticket.Completed.Value) || ticket.TicketStatus == "Closed")
                        {
                            appointment = "Done";
                        }

                        var entry = new Entry
                        {
                            Time = startTime.ToString("h:mm"),
                            Stylist = schedules.FirstOrDefault(s => s.EmployeeID == schedule.EmployeeID)?.FirstName,
                            Client = client,
                            Status = ticket.TicketStatus == "Open" ? "Taken" : "Open",
                            Appointment = appointment
                        };

                        entries.Add(entry);
                        entryAdded = true;
                    }

                    if (!entryAdded)
                    {
                        entries.Add(new Entry
                        {
                            Time = startTime.ToString("h:mm"),
                            Stylist = schedules.FirstOrDefault(s => s.EmployeeID == schedule.EmployeeID)?.FirstName,
                            Client = "",
                            Status = "Available",
                            Appointment = "Available"
                        });
                    }
                }
            }

            var totalPage = entries.Count / numRows;
            DisplayEntries(entries, totalPage, _currentPage++, numRows);
            _currentPage = _currentPage % totalPage;
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
        private void DisplayEntries(List<Entry> entries, int totalPage, int pageNum, int perPage)
        {
            //var form2Type = frm2.GetType();

            //SafeInvoke(frm2, () =>
            //{
            //    form2Type.GetProperty(string.Format("employee{0}", i + 1)).SetValue(frm2, getStylist2);
            //    form2Type.GetProperty(string.Format("appt{0}", i + 1)).SetValue(frm2, getAppt(i + 1, currentpage));
            //    form2Type.GetProperty(string.Format("stat{0}", i + 1)).SetValue(frm2, getStatus(i + 1, currentpage));
            //    form2Type.GetProperty(string.Format("clientt{0}", i + 1)).SetValue(frm2, getClient(i + 1, currentpage));
            //});
        }
    }
}
