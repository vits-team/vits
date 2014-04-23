using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vITs
{
    public partial class Consultant : Form
    {
        private int id;
        private List<Receipt> receiptList; 

        public Consultant()
        {
            InitializeComponent();
            id = Login.passThisUser();
            receiptList = new List<Receipt>(); 
            
            hideAllPanels();
            panel_home.Visible = true;
            lbl_myName.Text = DataAccess.requestFullName(id);
            cb_trip_land.DataSource = vITs.DataAccess.FillCountryList();
            cb_trip_assignments.DataSource = vITs.DataAccess.FillQuestList();

        }

        private void btn_trip_addReciept_Click(object sender, EventArgs e)
        {
            string date = dpicker_trip_receiptdate.Value.Date.ToString();
            string type = txt_trip_recieptType.Text;
            string number = txt_trip_recieptNumber.Text;
            int sum = Convert.ToInt32(txt_trip_recieptAmount.Text);
            string currency = cb_trip_currency.SelectedItem.ToString();

            int doesRecieptExist = 0;
            string recieptExists;

            if (check_receipts.Checked == true)
            {
                doesRecieptExist = 1;
            }
            else
            {
                doesRecieptExist = 2;
            }


            Receipt newRec = new Receipt(date, type, number, sum, currency, doesRecieptExist);
            receiptList.Add(newRec);

            lb_trip_reciepts.Items.Clear();

            foreach (Receipt re in receiptList)
            {
                if (re.recieptExist == 1)
                {
                    recieptExists = "Kvitto finns ej";
                }
                else
                {
                    recieptExists = "Kvitto finns";
                }


                lb_trip_reciepts.Items.Add(re.date + "\t" + re.type + "\t" + re.number + "\t\t" + re.sum + " " + re.currency + "\t\t" + recieptExists);

            }




        }

        private void cb_trip_currency_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_trip_currency.SelectedItem.Equals("SEK"))
            {
                txt_trip_recieptRate.Text = "1 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("EUR"))
            {
                txt_trip_recieptRate.Text = "9.00 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("USD"))
            {
                txt_trip_recieptRate.Text = "6.50 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("GBP"))
            {
                txt_trip_recieptRate.Text = "10.90 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("NOK"))
            {
                txt_trip_recieptRate.Text = "1.10 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("DKK"))
            {
                txt_trip_recieptRate.Text = "1.20 SEK";

            }
            else if (cb_trip_currency.SelectedItem.Equals("- Ange valuta -"))
            {
                txt_trip_recieptRate.Text = "";

            }
        }

        private void btn_trip_removeReciept_Click(object sender, EventArgs e)
        {
            int obj = lb_trip_reciepts.SelectedIndex;

            receiptList.RemoveAt(obj);
            string recieptExists;

            lb_trip_reciepts.Items.Clear();

            foreach (Receipt re in receiptList)
            {
                if (re.recieptExist == 1)
                {
                    recieptExists = "Kvitto finns ej";
                }
                else
                {
                    recieptExists = "Kvitto finns";
                }


                lb_trip_reciepts.Items.Add(re.date + "\t" + re.type + "\t" + re.number + "\t\t" + re.sum + " " + re.currency + "\t\t" + recieptExists);

            }
        }

        private void btn_trip_confirm_Click(object sender, EventArgs e)
        {
            int destinationID = DataAccess.getDestinationID(cb_trip_land.Text);
            int missionID = DataAccess.getMissionID(cb_trip_assignments.Text);

            string startdate = dpicker_start.Value.Date.ToString("yyyy/MM/dd");
            string enddate = dpicker_end.Value.Date.ToString("yyyy/MM/dd");
            int breakfasts = Convert.ToInt32(txt_trip_breakfasts.Text);
            int lunches = Convert.ToInt32(txt_trip_lunches.Text);
            int dinners = Convert.ToInt32(txt_trip_dinners.Text);
            int vacationdays = Convert.ToInt32(txt_trip_vacationDays.Text);



            DataAccess.addTrip(destinationID, startdate, enddate, cb_trip_travelWay.Text, missionID, breakfasts, lunches, dinners, vacationdays, id);

            MessageBox.Show("Du har lagt till en ny resa");

            /* Efter att en resa skapats, så kommer tillhörande kvitton att registeras till den resan. */

            if
                (lb_trip_reciepts.Items.Count != 0)
            {
                DataAccess.addReceipt(receiptList, DataAccess.getIdentityOfLastTrip());
            }
            else { }
       
        }


        /* ------------------------------ -------------------------------------------
         *                  NAVIGERING OCH FANCY
         * -----------------------------------------------------------------------*/


        private void hideAllPanels()
        {
            panel_home.Visible = false;

            panel_trip.Visible = false;
            string path = @"..\..\Images\icon-travel-grey.png";
            nav_travel.BackgroundImage = Image.FromFile(path);

            panel_myTrips.Visible = false;
            string path1 = @"..\..\Images\icon-mytravels-grey.png";
            nav_mytravels.BackgroundImage = Image.FromFile(path1);

            panel_prepayment.Visible = false;
            string path3 = @"..\..\Images\icon-prepayment-grey.png";
            nav_prepayment.BackgroundImage = Image.FromFile(path3);

            panel_assignments.Visible = false;
            string path2 = @"..\..\Images\icon-assignments-grey.png";
            nav_assignments.BackgroundImage = Image.FromFile(path2);

            panel_mySettings.Visible = false; 
        }

        private void nav_travel_MouseClick(object sender, MouseEventArgs e)
        {
            hideAllPanels(); 
            panel_trip.Visible = true;
            string path = @"..\..\Images\icon-travel-cyan.png";
            nav_travel.BackgroundImage = Image.FromFile(path);
        }

        private void nav_mytravels_Click(object sender, EventArgs e)
        {
            hideAllPanels(); 
            panel_myTrips.Visible = true;
            string path = @"..\..\Images\icon-mytravels-cyan.png";
            nav_mytravels.BackgroundImage = Image.FromFile(path);
        }

        private void nav_home_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_home.Visible = true; 
        }

        private void nav_assignments_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_assignments.Visible = true;
            string path = @"..\..\Images\icon-assignments-cyan.png";
            nav_assignments.BackgroundImage = Image.FromFile(path);
        }

        private void nav_prepayment_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_prepayment.Visible = true;
            string path = @"..\..\Images\icon-prepayment-cyan.png";
            nav_prepayment.BackgroundImage = Image.FromFile(path);
        }

        private void nav_mySettings_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_mySettings.Visible = true; 
        }

        private void nav_logOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult dr = MessageBox.Show("Vill du verkligen logga ut?", "Bekräfta utloggning", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login x = new Login();
                x.ShowDialog(); 
            }
            
        }

        private void nav_travel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-travel-cyan.png";
            nav_travel.BackgroundImage = Image.FromFile(path);
        }

        private void nav_travel_MouseLeave(object sender, EventArgs e)
        {
            if (panel_trip.Visible == true)
            {
                string path = @"..\..\Images\icon-travel-cyan.png";
                nav_travel.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-travel-grey.png";
                nav_travel.BackgroundImage = Image.FromFile(path);
            }
        }

        private void nav_mytravels_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-mytravels-cyan.png";
            nav_mytravels.BackgroundImage = Image.FromFile(path);
        }

        private void nav_mytravels_MouseLeave(object sender, EventArgs e)
        {
            if (panel_myTrips.Visible == true)
            {
                string path = @"..\..\Images\icon-mytravels-cyan.png";
                nav_mytravels.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-mytravels-grey.png";
                nav_mytravels.BackgroundImage = Image.FromFile(path);
            }
        }

        private void nav_assignments_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-assignments-cyan.png";
            nav_assignments.BackgroundImage = Image.FromFile(path);
        }

        private void nav_assignments_MouseLeave(object sender, EventArgs e)
        {
            if (panel_assignments.Visible == true)
            {
                string path = @"..\..\Images\icon-assignments-cyan.png";
                nav_assignments.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-assignments-grey.png";
                nav_assignments.BackgroundImage = Image.FromFile(path);
            }
        }

        private void nav_prepayment_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-prepayment-cyan.png";
            nav_prepayment.BackgroundImage = Image.FromFile(path);
        }

        private void nav_prepayment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_prepayment.Visible == true)
            {
                string path = @"..\..\Images\icon-prepayment-cyan.png";
                nav_prepayment.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-prepayment-grey.png";
                nav_prepayment.BackgroundImage = Image.FromFile(path);
            }
        }

      
    }
}
