using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonIrisTicketsSchedule
{
    static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            try
            {
                // Ensure the log directory exists
                string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SalonIrisTicketsSchedule", "logs");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                logger.Info("Application started.");
                Application.Run(new ConnectionForm());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Unhandled exception in Main");
                MessageBox.Show("An error occurred. Check logs for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LogManager.Shutdown();  // Ensure logs are flushed
            }

        }
    }
}
