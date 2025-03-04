using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SalonIrisTicketsSchedule.Models;
using System.Configuration;
using NLog;

namespace SalonIrisTicketsSchedule
{
    public partial class ConnectionForm : Form
    {
        // Logger will write errors to file
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // database connection string. Will be setup later
        private string ConnectionString;
        private SqlConnection _connection;

        // current page display
        private int _currentPage;

        private Form2 _form2 = new Form2();

        public HashSet<Models.Ticket> Tickets { get; set; } = new HashSet<Models.Ticket>();

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            // Load settings upload form loading
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load settings from storage to User Interface
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
            // On button click,
            // Save Settings and start processing display screens
            SaveSettings();

            ConnectionString = $"Data Source={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Integrated Security={Properties.Settings.Default.SSPI};UID={Properties.Settings.Default.DBUser};PWD={Properties.Settings.Default.DBPass};MultipleActiveResultSets=True;";

            _form2.Show();

            Task.Run(RefreshScreen);

            CycleTimer.Start();

            Hide();
        }
        /// <summary>
        /// Safely invokes a specified action on a control, ensuring thread-safe operations.
        /// </summary>
        /// <param name="control">The control on which to invoke the action.</param>
        /// <param name="action">The action to perform on the control.</param>
        private static void SafeInvoke(Control control, Action action)
        {
            // Check if the current thread is different from the thread that created the control.
            if (control.InvokeRequired)
            {
                // If so, marshal the action to the control's thread using MethodInvoker.
                control.Invoke(new MethodInvoker(() => action()));
            }
            else
            {
                // If the current thread is the same as the control's thread, execute the action directly.
                action();
            }
        }

        private void SaveSettings()
        {
            // Save Settings from User Interface to storage
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
            // Open SQL connection if its not already open, otherwise just return previosly opened connection
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }

            return _connection;
        }

        /// <summary>
        /// Retrieves all schedules for a given stylist on a specified date.
        /// </summary>
        /// <param name="date">The date to search for schedules.</param>
        /// <returns>A collection of schedules for the specified date.</returns>
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
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("GetSchedules() did not return anything!", "Warning");
                            logger.Warn("GetSchedules() did not return anything!");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                // Load database value to our Schedule object
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
                        logger.Error(ex);
                        logger.Error(ex.StackTrace);
                    }

                }

            }

            return new List<Models.Schedule>();
        }

        private DateTime? GetClosingTime(DateTime today)
        {
            try
            {
                //var cmdText =
                //        @"SELECT TOP 1 
                //    GREATEST(CAST(fldEnd AS TIME), CAST(fldEnd2 AS TIME), CAST(fldEnd3 AS TIME), CAST(fldEnd4 AS TIME), CAST(fldEnd5 AS TIME), CAST(fldEnd6 AS TIME)) AS MostRecentDate
                //    FROM tblScheduling
                //    WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                //    ORDER BY MostRecentDate DESC;";

                var cmdText = @"
                    SELECT TOP 1 MostRecentDate
                    FROM (
                        SELECT MAX(EndTime) AS MostRecentDate
                        FROM (
                            SELECT CAST(fldEnd AS TIME) AS EndTime FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                            UNION ALL
                            SELECT CAST(fldEnd2 AS TIME) FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                            UNION ALL
                            SELECT CAST(fldEnd3 AS TIME) FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                            UNION ALL
                            SELECT CAST(fldEnd4 AS TIME) FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                            UNION ALL
                            SELECT CAST(fldEnd5 AS TIME) FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                            UNION ALL
                            SELECT CAST(fldEnd6 AS TIME) FROM tblScheduling WHERE CAST(fldDate AS DATE) = CAST(@today AS DATE)
                        ) AS CombinedTimes
                    ) AS MaxTime
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
                                var closingDateTime = reader.GetTimeSpan(ordinal);
                                return today.Date + closingDateTime;
                                // return closingDateTime.ToString("h:mm tt", new System.Globalization.CultureInfo("en-US"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error @ GetClosingTime()");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);

            }
            return null;
        }
        /// <summary>
        /// Retrieves all tickets/appointments/bookings of clients on a specified date.
        /// </summary>
        /// <param name="date">The date to search for tickets.</param>
        /// <returns>A collection of tickets for the specified date.</returns>
        private List<Models.Ticket> GetTickets(DateTime date)
        {
            var result = new List<Models.Ticket>();

            using (var connection = GetOpenConnection())
            {
                string query = @"SELECT DISTINCT
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
                        AND s.fldTicketStatus != 'Canceled'";


                using (var cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@today", date);
                        var reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("GetTickets() did not  return anything!", "Warning");
                            logger.Warn("GetTickets() did not  return anything!");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                // load database values to our Tickets objects

                                var employeeId = reader.IsDBNull(reader.GetOrdinal("fldEmployeeID"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("fldEmployeeID"));

                                var checkIn = reader.IsDBNull(reader.GetOrdinal("fldCheckedIn"))
                                        ? false
                                        : true;

                                var completed = reader.IsDBNull(reader.GetOrdinal("fldCompleted"))
                                        ? false
                                        : reader.GetBoolean(reader.GetOrdinal("fldCompleted"));

                                result.Add(new Models.Ticket
                                {
                                    CheckedIn = checkIn,
                                    Completed = completed,

                                    ClientName = reader.IsDBNull(reader.GetOrdinal("ClientName"))
                                        ? string.Empty
                                        : reader.GetString(reader.GetOrdinal("ClientName")),

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
                        logger.Error(ex);
                        logger.Error(ex.StackTrace);

                    }

                }

            }

            return new List<Models.Ticket>();
        }


        private void RefreshScreen()
        {
            // var now = DateTime.Parse("2025-03-01 08:00");

            var now = DateTime.Now;

            logger.Info($"@RefreshScreen() - {now}");


            // Retrieve all tickets for given date
            var tickets = GetTickets(now.Date);
            // Retrieve all stylist schedules for given date
            // So no need to hit database for every timeslot
            // make app faster
            var schedules = GetSchedules(now.Date);

            logger.Info($"Tickets for today: {tickets.Count}");
            logger.Info($"Schedules for today: {schedules.Count}");

            // Calculates minutes increments based on selected appointment per hour
            var minutesIncrement = 60 / Properties.Settings.Default.AppointmentNum;
            var excess = now.Minute % minutesIncrement;

            // start date/time display will be the recent minutes increment
            // example for 4 appointment per hour, we have 15 minutes increment,
            // so if it is 12:52 now, the display will start at 12:45
            var start = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute - excess, 0);

            var numRows = Properties.Settings.Default.AppointmentNum == 4 ? 8 : 6;
            var entries = new List<Entry>();

            // Iterate over the list of schedules, ordered by EmployeeID
            foreach (var schedule in schedules.OrderBy(s => s.EmployeeID))
            {
                // Loop through each time slot within the defined number of rows
                for (int i = 0; i < numRows; i++)
                {
                    // Calculate the start and end times for the current time slot
                    var startTime = start.AddMinutes(i * minutesIncrement);
                    var endTime = startTime.AddMinutes(minutesIncrement);
                    var entryAdded = false;

                    // Retrieve tickets for the current employee, ordered by StartDateTime in descending order
                    var employeeTickets = tickets
                        .Where(t => t.EmployeeId == schedule.EmployeeID)
                        .OrderByDescending(t => t.StartDateTime)
                        .ToArray();

                    // Log the number of tickets the stylist has for the day
                    logger.Info($"Stylist {schedule.FirstName} has {employeeTickets.Length} tickets today.");

                    // Iterate over each ticket for the current employee
                    foreach (var ticket in employeeTickets)
                    {
                        // Check if the current time slot overlaps with the ticket's time range
                        if (startTime < ticket.StartDateTime || endTime > ticket.EndDateTime)
                            continue;

                        // Determine the appointment status based on the ticket
                        var appointment = GetAppointmentStatus(ticket);

                        // Identify the client; if the ticket description contains "time block", label it as "Time Block"
                        var client = ticket.Description?.ToLower().Contains("time block") == true ? "Time Block" : ticket.ClientName;

                        // Add an entry indicating the stylist's schedule matches a client's appointment
                        entries.Add(new Entry
                        {
                            StartDateTime = startTime,
                            EndDateTime = endTime,
                            Time = $"{startTime:h:mm tt} - {endTime:h:mm tt}".ToUpper(),
                            Stylist = schedule.FirstName,
                            Client = client,
                            Status = "Taken",
                            Appointment = appointment
                        });

                        entryAdded = true;
                        break;
                    }

                    // If no entry was added from the tickets, check the stylist's available time slots
                    if (!entryAdded)
                    {
                        // Iterate over valid time slots for the stylist
                        foreach (var slot in GetValidTimeSlots(schedule))
                        {
                            // Check if the current time slot fits within the stylist's available slot
                            if (startTime >= slot.Item1 && endTime <= slot.Item2)
                            {
                                // Add an entry indicating the stylist is available during this time slot
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

                    // If no entry was added, add a blank entry for the current time slot
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

            // Count total number of screen pages
            var totalPage = (int)Math.Ceiling(entries.Count / (double)numRows);
            if (totalPage == 0)
            {
                _currentPage = 0;
                return;
            }

            DisplayEntries(now, entries, totalPage, _currentPage++, numRows);

            // Go to next page otherwise return to first page.
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
            // Gather all time slot shchedule of stylist into a Tuple (from, to)
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

        private void DisplayEntries(DateTime now, List<Entry> entries, int totalPage, int pageNum, int perPage)
        {
            logger.Info($"@DisplayEntries(); PageItems count: {entries.Count}");

            // Get current items to be displayed based on page Number
            var pageItems = entries.Skip(pageNum * perPage).Take(perPage).OrderBy(i => i.StartDateTime).ToArray();

            // Just exit function if not items to be displayed.
            if (pageItems.Length <= 0)
            {
                return;
            }

            var closingTime = GetClosingTime(now.Date);
            var showingTime = $"{pageItems?.FirstOrDefault().StartDateTime:h:mm tt} to {pageItems.LastOrDefault()?.EndDateTime:h:mm tt}";

            // var openingTime = GetOpeningTime(now.Date);
            if (closingTime.HasValue)
            {
                SafeInvoke(_form2, () => _form2.showtext = $"SHOWING TIME: {showingTime}    TODAY CLOSING TIME: {closingTime.Value:h:mm tt}".ToUpper());
            }
            else
            {
                logger.Info("closingTime has no value!");
            }

            // SafeInvoke(_form2, () => _form2.showtext = $"SHOWING TIME: {showTime}    TODAY CLOSING TIME: {closingTime.Value:h:mm tt}".ToUpper());
            SafeInvoke(_form2, () => _form2.pagetext = "Page " + (pageNum + 1) + " of " + totalPage);

            var form2Type = _form2.GetType();


            // iterate on all row items and display them in user interface/ form2
            for (int i = 0; i < pageItems.Count(); i++)
            {
                var pageItem = pageItems[i];

                if (pageItem.StartDateTime >= closingTime)
                    continue;

                SafeInvoke(_form2, () =>
                {
                    var prop = form2Type.GetProperty(string.Format("hora{0}", i + 1));
                    form2Type.GetProperty(string.Format("hora{0}", i + 1)).SetValue(_form2, pageItem.Time);
                    form2Type.GetProperty(string.Format("employee{0}", i + 1)).SetValue(_form2, pageItem.Stylist);
                    form2Type.GetProperty(string.Format("appt{0}", i + 1)).SetValue(_form2, pageItem.Appointment);
                    form2Type.GetProperty(string.Format("stat{0}", i + 1)).SetValue(_form2, pageItem.Status);
                    form2Type.GetProperty(string.Format("Client{0}", i + 1)).SetValue(_form2, pageItem.Client);
                });
            }
        }
    }
}
