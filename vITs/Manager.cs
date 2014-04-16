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
    public partial class Manager : Form
    {
        private int id;
        private List<string[]> unapprovedPrePays = DataAccess.requestUnApprovedPrePays();
        
        public Manager()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;

            initializeBoxes();
        }

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

            panel_toDo.Visible = false;
            string path4 = @"..\..\Images\icon-manager-manage.png";
            nav_toDo.BackgroundImage = Image.FromFile(path4);
            
            panel_reports.Visible = false;
            string path5 = @"..\..\Images\icon-reports.png";
            nav_report.BackgroundImage = Image.FromFile(path5);

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

        private void nav_toDo_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_toDo.Visible = true;
            string path = @"..\..\Images\icon-manager-manage-cyan.png";
            nav_toDo.BackgroundImage = Image.FromFile(path);
        }

        private void nav_report_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_reports.Visible = true;
            string path = @"..\..\Images\icon-reports-cyan.png";
            nav_report.BackgroundImage = Image.FromFile(path);
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

        private void nav_toDo_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-manager-manage-cyan.png";
            nav_toDo.BackgroundImage = Image.FromFile(path);
        }

        private void nav_toDo_MouseLeave(object sender, EventArgs e)
        {
            if (panel_toDo.Visible == true)
            {
                string path = @"..\..\Images\icon-manager-manage-cyan.png";
                nav_toDo.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-manager-manage.png";
                nav_toDo.BackgroundImage = Image.FromFile(path);
            }
        }

        private void nav_report_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-reports-cyan.png";
            nav_report.BackgroundImage = Image.FromFile(path);
        }

        private void nav_report_MouseLeave(object sender, EventArgs e)
        {
            if (panel_reports.Visible == true)
            {
                string path = @"..\..\Images\icon-reports-cyan.png";
                nav_report.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-reports.png";
                nav_report.BackgroundImage = Image.FromFile(path);
            }
        }



        /* Initialisera alla boxar vid laddning */

        private void initializeBoxes()
        {
            List<string[]> unapprovedPrePays = DataAccess.requestUnApprovedPrePays();
            

            /* Fyller listboxen med förskottsbetalningar att godkänna */
            lb_toDo_employee.DataSource = unapprovedPrePays.Select(x => new { TripID = x[0], Advance = x[1], Description = x[2], MissionName = x[3] }).ToList();
            lb_toDo_employee.DisplayMember = "TripID";
            lb_toDo_employee.ValueMember = "TripID";
        }


        /* Godkänn-knappen. När den trycks så ändras Approved-värdet på vald förskottsbetalning. */

        private void btn_toDo_approve_Click(object sender, EventArgs e)
        {
            DataAccess.approveOfPrePay(unapprovedPrePays[lb_toDo_employee.SelectedIndex].GetValue(0).ToString());

            MessageBox.Show("Förskottsbetalningen godkändes.");

            initializeBoxes();
        }


        /* Vid klick i listan, ändra värdet i boxarna */

        private void lb_toDo_employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Advance
            txt_toDo_amount.Text = unapprovedPrePays[lb_toDo_employee.SelectedIndex].GetValue(1).ToString();
            // Description
            txt_toDo_description.Text = unapprovedPrePays[lb_toDo_employee.SelectedIndex].GetValue(2).ToString();
            // MissionName
            txt_toDo_assignment.Text = unapprovedPrePays[lb_toDo_employee.SelectedIndex].GetValue(3).ToString();
        }
    

        

       

        

      
    }
}
