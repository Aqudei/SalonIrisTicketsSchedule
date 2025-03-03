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

        public string clientt1
        {
            get
            {
                return this.client1.Text;
            }
            set
            {
                this.client1.Text = value;
                if (value == "Time Block")
                {
                    this.row1status.BackColor = ColorRed;
                    this.row1time.BackColor = ColorRed;
                    this.row1employee.BackColor = ColorRed;
                    this.row1appt.BackColor = ColorRed;
                    this.client1.BackColor = ColorRed;
                }
                else
                {
                    if (this.row1status.Text == "Available")
                    {
                        this.row1status.BackColor = ColorGreen;
                        this.row1time.BackColor = ColorGreen;
                        this.row1employee.BackColor = ColorGreen;
                        this.row1appt.BackColor = ColorGreen;
                        this.client1.BackColor = ColorGreen;
                    }
                    else if (this.row1status.Text == "Taken")
                    {
                        if (row1appt.Text == "Done")
                        {
                            this.row1status.BackColor = FirstColor;
                            this.row1time.BackColor = FirstColor;
                            this.row1employee.BackColor = FirstColor;
                            this.row1appt.BackColor = FirstColor;
                            this.client1.BackColor = FirstColor;
                        }
                        else
                        {
                            this.row1status.BackColor = ColorRed;
                            this.row1time.BackColor = ColorRed;
                            this.row1employee.BackColor = ColorRed;
                            this.row1appt.BackColor = ColorRed;
                            this.client1.BackColor = ColorRed;
                        }
                    }
                    else
                    {
                        this.row1status.BackColor = FirstColor;
                        this.row1time.BackColor = FirstColor;
                        this.row1employee.BackColor = FirstColor;
                        this.row1appt.BackColor = FirstColor;
                        this.client1.BackColor = FirstColor;
                    }
                }
            }
        }

        public string clientt2
        {
            get
            {
                return this.client2.Text;
            }
            set
            {
                this.client2.Text = value;
                if (value == "Time Block")
                {
                    this.row2status.BackColor = ColorRed;
                    this.row2time.BackColor = ColorRed;
                    this.row2employee.BackColor = ColorRed;
                    this.row2appt.BackColor = ColorRed;
                    this.client2.BackColor = ColorRed;
                }

                else
                {
                    if (this.row2status.Text == "Available")
                    {
                        this.row2status.BackColor = ColorGreen;
                        this.row2time.BackColor = ColorGreen;
                        this.row2employee.BackColor = ColorGreen;
                        this.row2appt.BackColor = ColorGreen;
                        this.client2.BackColor = ColorGreen;
                    }
                    else if (this.row2status.Text == "Taken")
                    {
                        if (row2appt.Text == "Done")
                        {
                            this.row2status.BackColor = SecondColor;
                            this.row2time.BackColor = SecondColor;
                            this.row2employee.BackColor = SecondColor;
                            this.row2appt.BackColor = SecondColor;
                            this.client2.BackColor = SecondColor;
                        }
                        else
                        {
                            this.row2status.BackColor = ColorRed;
                            this.row2time.BackColor = ColorRed;
                            this.row2employee.BackColor = ColorRed;
                            this.row2appt.BackColor = ColorRed;
                            this.client2.BackColor = ColorRed;
                        }


                    }
                    else
                    {
                        this.row2status.BackColor = SecondColor;
                        this.row2time.BackColor = SecondColor;
                        this.row2employee.BackColor = SecondColor;
                        this.row2appt.BackColor = SecondColor;
                        this.client2.BackColor = SecondColor;
                    }
                }
            }
        }

        public string clientt3
        {
            get
            {
                return this.client3.Text;
            }
            set
            {
                this.client3.Text = value;
                if (value == "Time Block")
                {
                    this.row3status.BackColor = ColorRed;
                    this.row3time.BackColor = ColorRed;
                    this.row3employee.BackColor = ColorRed;
                    this.row3appt.BackColor = ColorRed;
                    this.client3.BackColor = ColorRed;
                }
                else
                {
                    if (this.row3status.Text == "Available")
                    {
                        this.row3status.BackColor = ColorGreen;
                        this.row3time.BackColor = ColorGreen;
                        this.row3employee.BackColor = ColorGreen;
                        this.row3appt.BackColor = ColorGreen;
                        this.client3.BackColor = ColorGreen;
                    }
                    else if (this.row3status.Text == "Taken")
                    {
                        if (row3appt.Text == "Done")
                        {
                            this.row3status.BackColor = FirstColor;
                            this.row3time.BackColor = FirstColor;
                            this.row3employee.BackColor = FirstColor;
                            this.row3appt.BackColor = FirstColor;
                            this.client3.BackColor = FirstColor;
                        }
                        else
                        {
                            this.row3status.BackColor = ColorRed;
                            this.row3time.BackColor = ColorRed;
                            this.row3employee.BackColor = ColorRed;
                            this.row3appt.BackColor = ColorRed;
                            this.client3.BackColor = ColorRed;
                        }

                    }
                    else
                    {
                        this.row3status.BackColor = FirstColor;
                        this.row3time.BackColor = FirstColor;
                        this.row3employee.BackColor = FirstColor;
                        this.row3appt.BackColor = FirstColor;
                        this.client3.BackColor = FirstColor;
                    }
                }
            }
        }

        public string clientt4
        {
            get
            {
                return this.client4.Text;
            }
            set
            {
                this.client4.Text = value;
                if (value == "Time Block")
                {
                    this.row4status.BackColor = ColorRed;
                    this.row4time.BackColor = ColorRed;
                    this.row4employee.BackColor = ColorRed;
                    this.row4appt.BackColor = ColorRed;
                    this.client4.BackColor = ColorRed;
                }
                else
                {
                    if (this.row4status.Text == "Available")
                    {
                        this.row4status.BackColor = ColorGreen;
                        this.row4time.BackColor = ColorGreen;
                        this.row4employee.BackColor = ColorGreen;
                        this.row4appt.BackColor = ColorGreen;
                        this.client4.BackColor = ColorGreen;
                    }
                    else if (this.row4status.Text == "Taken")
                    {
                        if (row4appt.Text == "Done")
                        {
                            this.row4status.BackColor = SecondColor;
                            this.row4time.BackColor = SecondColor;
                            this.row4employee.BackColor = SecondColor;
                            this.row4appt.BackColor = SecondColor;
                            this.client4.BackColor = SecondColor;
                        }
                        else
                        {
                            this.row4status.BackColor = ColorRed;
                            this.row4time.BackColor = ColorRed;
                            this.row4employee.BackColor = ColorRed;
                            this.row4appt.BackColor = ColorRed;
                            this.client4.BackColor = ColorRed;
                        }

                    }
                    else
                    {
                        this.row4status.BackColor = SecondColor;
                        this.row4time.BackColor = SecondColor;
                        this.row4employee.BackColor = SecondColor;
                        this.row4appt.BackColor = SecondColor;
                        this.client4.BackColor = SecondColor;
                    }
                }
            }
        }

        public string clientt5
        {
            get
            {
                return this.client5.Text;
            }
            set
            {
                this.client5.Text = value;
                if (value == "Time Block")
                {
                    this.row5status.BackColor = ColorRed;
                    this.row5time.BackColor = ColorRed;
                    this.row5employee.BackColor = ColorRed;
                    this.row5appt.BackColor = ColorRed;
                    this.client5.BackColor = ColorRed;
                }
                else
                {
                    if (this.row5status.Text == "Available")
                    {
                        this.row5status.BackColor = ColorGreen;
                        this.row5time.BackColor = ColorGreen;
                        this.row5employee.BackColor = ColorGreen;
                        this.row5appt.BackColor = ColorGreen;
                        this.client5.BackColor = ColorGreen;
                    }
                    else if (this.row5status.Text == "Taken")
                    {
                        if (row5appt.Text == "Done")
                        {
                            this.row5status.BackColor = FirstColor;
                            this.row5time.BackColor = FirstColor;
                            this.row5employee.BackColor = FirstColor;
                            this.row5appt.BackColor = FirstColor;
                            this.client5.BackColor = FirstColor;
                        }
                        else
                        {
                            this.row5status.BackColor = ColorRed;
                            this.row5time.BackColor = ColorRed;
                            this.row5employee.BackColor = ColorRed;
                            this.row5appt.BackColor = ColorRed;
                            this.client5.BackColor = ColorRed;
                        }

                    }
                    else
                    {
                        this.row5status.BackColor = FirstColor;
                        this.row5time.BackColor = FirstColor;
                        this.row5employee.BackColor = FirstColor;
                        this.row5appt.BackColor = FirstColor;
                        this.client5.BackColor = FirstColor;
                    }
                }
            }
        }

        public string clientt6
        {
            get
            {
                return this.client6.Text;
            }
            set
            {
                this.client6.Text = value;
                if (value == "Time Block")
                {
                    this.row6status.BackColor = ColorRed;
                    this.row6time.BackColor = ColorRed;
                    this.row6employee.BackColor = ColorRed;
                    this.row6appt.BackColor = ColorRed;
                    this.client6.BackColor = ColorRed;
                }
                else
                {
                    if (this.row6status.Text == "Available")
                    {
                        this.row6status.BackColor = ColorGreen;
                        this.row6time.BackColor = ColorGreen;
                        this.row6employee.BackColor = ColorGreen;
                        this.row6appt.BackColor = ColorGreen;
                        this.client6.BackColor = ColorGreen;
                    }
                    else if (this.row6status.Text == "Taken")
                    {
                        if (row6appt.Text == "Done")
                        {
                            this.row6status.BackColor = SecondColor;
                            this.row6time.BackColor = SecondColor;
                            this.row6employee.BackColor = SecondColor;
                            this.row6appt.BackColor = SecondColor;
                            this.client6.BackColor = SecondColor;
                        }
                        else
                        {
                            this.row6status.BackColor = ColorRed;
                            this.row6time.BackColor = ColorRed;
                            this.row6employee.BackColor = ColorRed;
                            this.row6appt.BackColor = ColorRed;
                            this.client6.BackColor = ColorRed;
                        }

                    }
                    else
                    {
                        this.row6status.BackColor = SecondColor;
                        this.row6time.BackColor = SecondColor;
                        this.row6employee.BackColor = SecondColor;
                        this.row6appt.BackColor = SecondColor;
                        this.client6.BackColor = SecondColor;
                    }
                }
            }
        }

        public string clientt7
        {
            get
            {
                return this.client7.Text;
            }
            set
            {
                //if (apptno > 3)
                //{
                this.client7.Text = value;
                if (value == "Time Block")
                {
                    this.row7status.BackColor = ColorRed;
                    this.row7time.BackColor = ColorRed;
                    this.row7employee.BackColor = ColorRed;
                    this.row7appt.BackColor = ColorRed;
                    this.client7.BackColor = ColorRed;
                }
                else
                {
                    if (this.row7status.Text == "Available")
                    {
                        this.row7status.BackColor = ColorGreen;
                        this.row7time.BackColor = ColorGreen;
                        this.row7employee.BackColor = ColorGreen;
                        this.row7appt.BackColor = ColorGreen;
                        this.client7.BackColor = ColorGreen;
                    }
                    else if (this.row7status.Text == "Taken")
                    {
                        if (row7appt.Text == "Done")
                        {
                            this.row7status.BackColor = FirstColor;
                            this.row7time.BackColor = FirstColor;
                            this.row7employee.BackColor = FirstColor;
                            this.row7appt.BackColor = FirstColor;
                            this.client7.BackColor = FirstColor;
                        }
                        else
                        {
                            this.row7status.BackColor = ColorRed;
                            this.row7time.BackColor = ColorRed;
                            this.row7employee.BackColor = ColorRed;
                            this.row7appt.BackColor = ColorRed;
                            this.client7.BackColor = ColorRed;
                        }

                    }
                    else
                    {
                        this.row7status.BackColor = FirstColor;
                        this.row7time.BackColor = FirstColor;
                        this.row7employee.BackColor = FirstColor;
                        this.row7appt.BackColor = FirstColor;
                        this.client7.BackColor = FirstColor;
                    }
                }
                //}
            }
        }

        public string clientt8
        {
            get
            {
                return this.client8.Text;
            }
            set
            {
                //if (apptno > 3) { 
                this.client8.Text = value;
                if (value == "Time Block")
                {
                    this.row8status.BackColor = ColorRed;
                    this.row8time.BackColor = ColorRed;
                    this.row8employee.BackColor = ColorRed;
                    this.row8appt.BackColor = ColorRed;
                    this.client8.BackColor = ColorRed;
                }
                else
                {
                    if (this.row8status.Text == "Available")
                    {
                        this.row8status.BackColor = ColorGreen;
                        this.row8time.BackColor = ColorGreen;
                        this.row8employee.BackColor = ColorGreen;
                        this.row8appt.BackColor = ColorGreen;
                        this.client8.BackColor = ColorGreen;
                    }
                    else if (this.row8status.Text == "Taken")
                    {
                        if (row8appt.Text == "Done")
                        {
                            this.row8status.BackColor = SecondColor;
                            this.row8time.BackColor = SecondColor;
                            this.row8employee.BackColor = SecondColor;
                            this.row8appt.BackColor = SecondColor;
                            this.client8.BackColor = SecondColor;
                        }
                        else
                        {
                            this.row8status.BackColor = ColorRed;
                            this.row8time.BackColor = ColorRed;
                            this.row8employee.BackColor = ColorRed;
                            this.row8appt.BackColor = ColorRed;
                            this.client8.BackColor = ColorRed;
                        }
                    }
                    else
                    {
                        this.row8status.BackColor = SecondColor;
                        this.row8time.BackColor = SecondColor;
                        this.row8employee.BackColor = SecondColor;
                        this.row8appt.BackColor = SecondColor;
                        this.client8.BackColor = SecondColor;
                    }
                }
                //}
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
