using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;

namespace SalonIrisTicketsSchedule
{
    public partial class Form2 : Form
    {
        Color ColorRed = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        Color ColorGreen = System.Drawing.Color.FromArgb(255, 41, 192, 70);
        Color FirstColor = System.Drawing.Color.FromArgb(255, 32, 142, 223);
        Color SecondColor = System.Drawing.Color.FromArgb(255, 12, 101, 166);
        Color HeaderColor = System.Drawing.Color.FromArgb(255, 0, 97, 93);


        int apptno;
        public Form2()
        {
            InitializeComponent();
            this.tableLayoutPanel1.RowCount = 6;
            this.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
        }

        private void Form2_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
            //MessageBox.Show("something");
        }

        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row > 0 && e.Row % 2 == 0)
            {
                System.Drawing.Brush brushalt = new SolidBrush(HeaderColor);
                //SolidColorBrush brush1 = new SolidColorBrush(Color.FromArgb(255, 255, 139, 0));
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(brushalt, r);
            }
            else if (e.Row == 0)
            {
                System.Drawing.Brush brushtop = new SolidBrush(SecondColor);
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(brushtop, r);
                //brushtop.Dispose();
            }
            else
            {
                System.Drawing.Brush brush = new SolidBrush(FirstColor);
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(brush, r);
                //brush.Dispose();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string CompanyAirportName
        {
            get
            {
                return this.companyairport.Text;
            }
            set
            {
                this.companyairport.Text = value;
            }
        }

        public string hora1
        {
            get
            {
                return this.row1time.Text;
            }
            set
            {
                this.row1time.Text = value;
            }
        }

        public string hora2
        {
            get
            {
                return this.row2time.Text;
            }
            set
            {
                this.row2time.Text = value;
            }
        }

        public string hora3
        {
            get
            {
                return this.row3time.Text;
            }
            set
            {
                this.row3time.Text = value;
            }
        }

        public string hora4
        {
            get
            {
                return this.row4time.Text;
            }
            set
            {
                this.row4time.Text = value;
            }
        }

        public string hora5
        {
            get
            {
                return this.row5time.Text;
            }
            set
            {
                this.row5time.Text = value;
            }
        }

        public string hora6
        {
            get
            {
                return this.row6time.Text;
            }
            set
            {
                this.row6time.Text = value;
            }
        }

        public string hora7
        {
            get
            {
                return this.row7time.Text;
            }
            set
            {
                this.row7time.Text = value;
            }
        }

        public string hora8
        {
            get
            {
                return this.row8time.Text;
            }
            set
            {
                this.row8time.Text = value;
            }
        }

        public string employee1
        {
            get
            {
                return this.row1employee.Text;
            }
            set
            {
                this.row1employee.Text = value;
            }
        }

        public string employee2
        {
            get
            {
                return this.row2employee.Text;
            }
            set
            {
                this.row2employee.Text = value;
            }
        }

        public string employee3
        {
            get
            {
                return this.row3employee.Text;
            }
            set
            {
                this.row3employee.Text = value;
            }
        }

        public string employee4
        {
            get
            {
                return this.row4employee.Text;
            }
            set
            {
                this.row4employee.Text = value;
            }
        }

        public string employee5
        {
            get
            {
                return this.row5employee.Text;
            }
            set
            {
                this.row5employee.Text = value;
            }
        }

        public string employee6
        {
            get
            {
                return this.row6employee.Text;
            }
            set
            {
                this.row6employee.Text = value;
            }
        }

        public string employee7
        {
            get
            {
                return this.row7employee.Text;
            }
            set
            {
                this.row7employee.Text = value;
            }
        }

        public string employee8
        {
            get
            {
                return this.row8employee.Text;
            }
            set
            {
                this.row8employee.Text = value;
            }
        }

        public string appt1
        {
            get
            {
                return this.row1appt.Text;
            }
            set
            {
                this.row1appt.Text = value;
            }
        }

        public string appt2
        {
            get
            {
                return this.row2appt.Text;
            }
            set
            {
                this.row2appt.Text = value;
            }
        }

        public string appt3
        {
            get
            {
                return this.row3appt.Text;
            }
            set
            {
                this.row3appt.Text = value;
            }
        }

        public string appt4
        {
            get
            {
                return this.row4appt.Text;
            }
            set
            {
                this.row4appt.Text = value;
            }
        }

        public string appt5
        {
            get
            {
                return this.row5appt.Text;
            }
            set
            {
                this.row5appt.Text = value;
            }
        }

        public string appt6
        {
            get
            {
                return this.row6appt.Text;
            }
            set
            {
                this.row6appt.Text = value;
            }
        }

        public string appt7
        {
            get
            {
                return this.row7appt.Text;
            }
            set
            {
                this.row7appt.Text = value;
            }
        }

        public string appt8
        {
            get
            {
                return this.row8appt.Text;
            }
            set
            {
                this.row8appt.Text = value;
            }
        }

        public void SetClientStatus(Label  client, Label rowStatus, Label rowTime, Label rowEmployee, Label rowAppt, Color firstColor, Color secondColor)
        {
            if (client.Text == "Time Block")
            {
                SetRowColor(rowStatus, rowTime, rowEmployee, rowAppt, client, ColorRed);
            }
            else
            {
                if (rowStatus.Text == "Available")
                {
                    SetRowColor(rowStatus, rowTime, rowEmployee, rowAppt, client, ColorGreen);
                }
                else if (rowStatus.Text == "Taken")
                {
                    SetRowColor(rowStatus, rowTime, rowEmployee, rowAppt, client, rowAppt.Text == "Done" ? firstColor : ColorRed);
                }
                else
                {
                    SetRowColor(rowStatus, rowTime, rowEmployee, rowAppt, client, firstColor);
                }
            }
        }

        private void SetRowColor(Label rowStatus, Label rowTime, Label rowEmployee, Label rowAppt, Label client, Color color)
        {
            rowStatus.BackColor = color;
            rowTime.BackColor = color;
            rowEmployee.BackColor = color;
            rowAppt.BackColor = color;
            client.BackColor = color;
        }

        public string Client1
        {
            get => client1.Text;
            set
            {
                client1.Text = value;
                SetClientStatus(client1, row1status, row1time, row1employee, row1appt, FirstColor, SecondColor);
            }
        }

        public string Client2
        {
            get => client2.Text;
            set
            {
                client2.Text = value;
                SetClientStatus(client2, row2status, row2time, row2employee, row2appt, FirstColor, SecondColor);
            }
        }

        public string Client3
        {
            get => client3.Text;
            set
            {
                client3.Text = value;
                SetClientStatus(client3, row3status, row3time, row3employee, row3appt, FirstColor, SecondColor);
            }
        }

        public string Client4
        {
            get => client4.Text;
            set
            {
                client4.Text = value;
                SetClientStatus(client4, row4status, row4time, row4employee, row4appt, FirstColor, SecondColor);
            }
        }

        public string Client5
        {
            get => client5.Text;
            set
            {
                client5.Text = value;
                SetClientStatus(client5, row5status, row5time, row5employee, row5appt, FirstColor, SecondColor);
            }
        }

        public string Client6
        {
            get => client6.Text;
            set
            {
                client6.Text = value;
                SetClientStatus(client6, row6status, row6time, row6employee, row6appt, FirstColor, SecondColor);
            }
        }

        public string Client7
        {
            get => client7.Text;
            set
            {
                client7.Text = value;
                SetClientStatus(client7, row7status, row7time, row7employee, row7appt, FirstColor, SecondColor);
            }
        }

        public string Client8
        {
            get => client8.Text;
            set
            {
                client8.Text = value;
                SetClientStatus(client8, row8status, row8time, row8employee, row8appt, FirstColor, SecondColor);
            }
        }


        public string stat1
        {
            get
            {
                return this.row1status.Text;
            }
            set
            {
                this.row1status.Text = value;

            }
        }

        public string stat2
        {
            get
            {
                return this.row2status.Text;
            }
            set
            {
                this.row2status.Text = value;

            }
        }

        public string stat3
        {
            get
            {
                return this.row3status.Text;
            }
            set
            {
                this.row3status.Text = value;

            }
        }

        public string stat4
        {
            get
            {
                return this.row4status.Text;
            }
            set
            {
                this.row4status.Text = value;

            }
        }

        public string stat5
        {
            get
            {
                return this.row5status.Text;
            }
            set
            {
                this.row5status.Text = value;

            }
        }

        public string stat6
        {
            get
            {
                return this.row6status.Text;
            }
            set
            {
                this.row6status.Text = value;

            }
        }

        public string stat7
        {
            get
            {
                return this.row7status.Text;
            }
            set
            {
                /*if (apptno > 3)
                {*/
                this.row7status.Text = value;
                //}

            }
        }

        public string stat8
        {
            get
            {
                return this.row8status.Text;
            }
            set
            {
                /*if (apptno > 3)
                {*/
                this.row8status.Text = value;
                //}

            }
        }

        public string watchtext
        {
            get
            {
                return this.watch.Text;
            }
            set
            {
                this.watch.Text = value;
            }
        }

        public string pagetext
        {
            get
            {
                return this.pagination.Text;
            }
            set
            {
                this.pagination.Text = value;
            }
        }

        public string showtext
        {
            get { return this.showtime.Text; }
            set { this.showtime.Text = value; }
        }

        public int apptnogetset
        {
            get { return this.apptno; }
            set { this.apptno = value; }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            this.tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("MMMM d, yyyy h:mm tt");

            Console.WriteLine(formattedDate);

            watchtext = formattedDate;
        }
    }
}
