﻿using System;
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

        private Form2 _form2 = new Form2();

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

            _form2.Show();

            Task.Run(RefreshScreen);

            CycleTimer.Start();

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

        private string GetClosingTime(DateTime today)
        {
            //string cmdText = $@"SELECT top 1
            //    CASE
            //        WHEN fldEnd >= fldEnd2 AND fldEnd >= fldEnd3 AND fldEnd >= fldEnd4 AND fldEnd >= fldEnd5 AND fldEnd >= fldEnd6 THEN fldEnd
            //        WHEN fldEnd2 >= fldEnd AND fldEnd2 >= fldEnd3 AND fldEnd2 >= fldEnd4 AND fldEnd2 >= fldEnd5 AND fldEnd2 >= fldEnd6 THEN fldEnd2
            //        WHEN fldEnd3 >= fldEnd AND fldEnd3 >= fldEnd2 AND fldEnd3 >= fldEnd4 AND fldEnd3 >= fldEnd5 AND fldEnd3 >= fldEnd6 THEN fldEnd3
            //        WHEN fldEnd4 >= fldEnd AND fldEnd4 >= fldEnd2 AND fldEnd4 >= fldEnd4 AND fldEnd4 >= fldEnd5 AND fldEnd4 >= fldEnd6 THEN fldEnd4
            //        WHEN fldEnd5 >= fldEnd AND fldEnd5 >= fldEnd2 AND fldEnd5 >= fldEnd4 AND fldEnd5 >= fldEnd5 AND fldEnd5 >= fldEnd6 THEN fldEnd5
            //        WHEN fldEnd6 >= fldEnd AND fldEnd6 >= fldEnd2 AND fldEnd6 >= fldEnd4 AND fldEnd6 >= fldEnd5 AND fldEnd6 >= fldEnd6 THEN fldEnd6
            //        ELSE fldEnd
            //    END AS MostRecentDate from tblScheduling where CAST(fldDate AS DATE) = CAST(@today AS DATE) order by MostRecentDate desc";

            var cmdText =
                @"SELECT TOP 1 
                    GREATEST(fldEnd, fldEnd2, fldEnd3, fldEnd4, fldEnd5, fldEnd6) AS MostRecentDate
                    FROM tblScheduling
                    WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                    ORDER BY MostRecentDate DESC;";

            using (var connection = GetOpenConnection())
            {
                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@today", today);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var ordinal = reader.GetOrdinal("MostRecentDate");
                            var closingDateTime = reader.GetDateTime(ordinal);
                            return closingDateTime.ToString("h:mm tt", new System.Globalization.CultureInfo("en-US"));
                        }

                    }

                    return string.Empty;
                }
            }
        }

        private List<Models.Ticket> GetTickets(DateTime date)
        {
            var result = new List<Models.Ticket>();

            using (var connection = GetOpenConnection())
            {
                string query = @"
                        SELECT DISTINCT(t.fldPK) AS PK,
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
                                    PK = reader.IsDBNull(reader.GetOrdinal("PK"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("PK")),
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
            var now = DateTime.Parse("2025-02-19 14:00");

            var tickets = GetTickets(now.Date);
            var schedules = GetSchedules(now.Date);

            var minutesIncrement = 60 / Properties.Settings.Default.AppointmentNum;
            var excess = now.Minute % minutesIncrement;
            var start = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute - excess, 0);

            var numRows = Properties.Settings.Default.AppointmentNum == 4 ? 8 : 6;
            var entries = new List<Entry>();

            foreach (var schedule in schedules.OrderBy(s => s.EmployeeID))
            {
                for (int i = 0; i < numRows; i++)
                {
                    var startTime = start.AddMinutes(i * minutesIncrement);
                    var endTime = startTime.AddMinutes(minutesIncrement);
                    var entryAdded = false;

                    var employeeTickets = tickets
                        .Where(t => t.EmployeeId == schedule.EmployeeID)
                        .OrderByDescending(t => t.PK)
                        .ToArray();

                    foreach (var ticket in employeeTickets)
                    {
                        if (startTime < ticket.StartDateTime || endTime > ticket.EndDateTime)
                            continue;

                        var appointment = GetAppointmentStatus(ticket);
                        var client = ticket.Description?.ToLower().Contains("time block") == true ? "Time Block" : ticket.ClientName;

                        entries.Add(new Entry
                        {
                            StartDateTime = startTime,
                            EndDateTime = endTime,
                            Time = $"{startTime:h:mm tt} - {endTime:h:mm tt}".ToUpper(),
                            Stylist = schedule.FirstName,
                            Client = client,
                            Status = ticket.TicketStatus == "Open" ? "Taken" : "Open",
                            Appointment = appointment
                        });

                        entryAdded = true;
                        break;
                    }

                    if (!entryAdded)
                    {
                        var timeSlots = GetValidTimeSlots(schedule);
                        foreach (var slot in timeSlots)
                        {
                            if (startTime >= slot.Item1 && endTime <= slot.Item2)
                            {
                                entries.Add(new Entry
                                {
                                    StartDateTime = startTime,
                                    EndDateTime = endTime,
                                    Time = $"{startTime:h:mm tt} - {endTime:h:mm tt}".ToUpper(),
                                    Stylist = schedule.FirstName,
                                    Client = "",
                                    Status = "Available",
                                    Appointment = "Available"
                                });
                                entryAdded = true;
                                break;
                            }
                        }
                    }

                    if (!entryAdded)
                    {
                        entries.Add(new Entry
                        {
                            StartDateTime = startTime,
                            EndDateTime = endTime,
                            Time = $"{startTime:h:mm tt} - {endTime:h:mm tt}".ToUpper(),
                            Stylist = "",
                            Client = string.Empty,
                            Status = string.Empty,
                            Appointment = string.Empty
                        });
                    }
                }
            }

            var totalPage = (int)Math.Ceiling(entries.Count / (double)numRows);
            if (totalPage == 0)
            {
                _currentPage = 0;
                return;
            }

            DisplayEntries(now, entries, totalPage, _currentPage++, numRows);
            _currentPage %= totalPage;
        }

        // Helper method to determine appointment status
        private string GetAppointmentStatus(Models.Ticket ticket)
        {
            if (ticket.TicketStatus == "Open")
            {
                if (ticket.CheckedIn == true) return "Arrived";
                return "On Schedule";
            }
            if (ticket.Completed == true || ticket.TicketStatus == "Closed")
            {
                return "Done";
            }
            return ticket.TicketStatus;
        }

        // Helper method to retrieve valid time slots
        private List<Tuple<DateTime, DateTime>> GetValidTimeSlots(Schedule schedule)
        {
            var date = schedule.Date?.Date ?? DateTime.MinValue;
            var timeSlots = new List<Tuple<DateTime, DateTime>>
            {
                Tuple.Create(date + (schedule.Start?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd?.TimeOfDay ?? TimeSpan.Zero)),
                Tuple.Create(date + (schedule.Start2?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd2?.TimeOfDay ?? TimeSpan.Zero)),
                Tuple.Create(date + (schedule.Start3?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd3?.TimeOfDay ?? TimeSpan.Zero)),
                Tuple.Create(date + (schedule.Start4?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd4?.TimeOfDay ?? TimeSpan.Zero)),
                Tuple.Create(date + (schedule.Start5?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd5?.TimeOfDay ?? TimeSpan.Zero)),
                Tuple.Create(date + (schedule.Start6?.TimeOfDay ?? TimeSpan.Zero), date + (schedule.DEnd6?.TimeOfDay ?? TimeSpan.Zero))
            };

            return timeSlots.Where(t => t.Item1 < t.Item2).ToList();
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
        private void DisplayEntries(DateTime now, List<Entry> entries, int totalPage, int pageNum, int perPage)
        {
            var pageItems = entries.Skip(pageNum * perPage).Take(perPage).OrderBy(i => i.StartDateTime).ToArray();
            if (pageItems.Length <= 0)

                return;

            if (pageItems.All(p => string.IsNullOrEmpty(p.Appointment)))
                return;

            var showTime = $"{pageItems?.FirstOrDefault().StartDateTime:h:mm tt} to {pageItems.LastOrDefault()?.EndDateTime:h:mm tt}";
            var closingTime = GetClosingTime(now.Date);

            SafeInvoke(_form2, () => _form2.showtext = $"SHOWING TIME: {showTime}    TODAY CLOSING TIME: {closingTime}".ToUpper());
            SafeInvoke(_form2, () => _form2.pagetext = "Page " + (pageNum + 1) + " of " + totalPage);

            var form2Type = _form2.GetType();

            for (int i = 0; i < pageItems.Count(); i++)
            {
                var pageItem = pageItems[i];
                SafeInvoke(_form2, () =>
                {
                    var prop = form2Type.GetProperty(string.Format("hora{0}", i + 1));
                    form2Type.GetProperty(string.Format("hora{0}", i + 1)).SetValue(_form2, pageItem.Time);
                    form2Type.GetProperty(string.Format("employee{0}", i + 1)).SetValue(_form2, pageItem.Stylist);
                    form2Type.GetProperty(string.Format("appt{0}", i + 1)).SetValue(_form2, pageItem.Appointment);
                    form2Type.GetProperty(string.Format("stat{0}", i + 1)).SetValue(_form2, pageItem.Status);
                    form2Type.GetProperty(string.Format("clientt{0}", i + 1)).SetValue(_form2, pageItem.Client);
                });
            }
        }
    }
}
