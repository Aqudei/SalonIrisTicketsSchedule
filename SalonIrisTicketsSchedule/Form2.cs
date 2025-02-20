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
        System.Drawing.Brush brushalt = new SolidBrush(System.Drawing.Color.FromArgb(255, 18, 112, 181));
        //SolidColorBrush brush1 = new SolidColorBrush(Color.FromArgb(255, 255, 139, 0));
        Graphics g = e.Graphics;
        Rectangle r = e.CellBounds;
        g.FillRectangle(brushalt, r);
      }
      else if (e.Row == 0) {
        System.Drawing.Brush brushtop = new SolidBrush(System.Drawing.Color.FromArgb(255, 9, 65, 106));
        Graphics g = e.Graphics;
        Rectangle r = e.CellBounds;
        g.FillRectangle(brushtop, r);
        //brushtop.Dispose();
      } else {
        System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(255, 13, 93, 152));
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
          this.row1status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row1time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row1employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row1appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client1.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row1status.Text == "Available")
          {
            this.row1status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row1time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row1employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row1appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client1.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row1status.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row1time.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row1employee.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row1appt.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.client1.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
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
          this.row2status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row2time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row2employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row2appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client2.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row2status.Text == "Available")
          {
            this.row2status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row2time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row2employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row2appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client2.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row2status.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row2time.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row2employee.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row2appt.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.client2.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
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
          this.row3status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row3time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row3employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row3appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client3.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row3status.Text == "Available")
          {
            this.row3status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row3time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row3employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row3appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client3.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row3status.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row3time.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row3employee.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row3appt.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.client3.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
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
          this.row4status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row4time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row4employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row4appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client4.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row4status.Text == "Available")
          {
            this.row4status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row4time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row4employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row4appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client4.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row4status.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row4time.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row4employee.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row4appt.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.client4.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
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
          this.row5status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row5time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row5employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row5appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client5.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row5status.Text == "Available")
          {
            this.row5status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row5time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row5employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row5appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client5.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row5status.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row5time.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row5employee.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row5appt.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.client5.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
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
          this.row6status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row6time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row6employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row6appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client6.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row6status.Text == "Available")
          {
            this.row6status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row6time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row6employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row6appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client6.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row6status.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row6time.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row6employee.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row6appt.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.client6.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
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
          this.row7status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row7time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row7employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row7appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client7.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row7status.Text == "Available")
          {
            this.row7status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row7time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row7employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row7appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client7.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row7status.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row7time.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row7employee.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.row7appt.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
            this.client7.BackColor = System.Drawing.Color.FromArgb(255, 13, 93, 152);
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
          this.row8status.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row8time.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row8employee.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.row8appt.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
          this.client8.BackColor = System.Drawing.Color.FromArgb(255, 208, 75, 75);
        }
        else
        {
          if (this.row8status.Text == "Available")
          {
            this.row8status.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row8time.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row8employee.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.row8appt.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
            this.client8.BackColor = System.Drawing.Color.FromArgb(255, 41, 192, 70);
          }
          else
          {
            this.row8status.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row8time.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row8employee.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.row8appt.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
            this.client8.BackColor = System.Drawing.Color.FromArgb(255, 9, 65, 106);
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


  }   
}
