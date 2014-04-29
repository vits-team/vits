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
    public partial class Admin : Form
    {
        private int id;
        private List<string[]> users = DataAccess.requestUserList();
        private List<string[]> missions = DataAccess.getMissionDetails();

        public Admin()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;

            lbl_myName.Text = DataAccess.requestFullName(id);
            initializeBoxes();
            showMissions();
            fillUserInformation(); 
        }

        private void hideAllPanels()
        {
            panel_home.Visible = false;
            
            panel_addUser.Visible = false;
            
            string path = @"..\..\Images\icon-adminAdd.png";
            nav_addUser.BackgroundImage = Image.FromFile(path);
            
            panel_manage.Visible = false;
            string path1 = @"..\..\Images\icon-adminManage.png";  
            nav_manage.BackgroundImage = Image.FromFile(path1);
           
            panel_assignments.Visible = false;
            string path2 = @"..\..\Images\icon-assignments-grey.png";
            nav_assignments.BackgroundImage = Image.FromFile(path2);
           
            panel_mySettings.Visible = false; 
            
        }

        private void nav_manage_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_manage.Visible = true;
            string path = @"..\..\Images\icon-adminManage-cyan.png";
            nav_manage.BackgroundImage = Image.FromFile(path);

        }

        private void nav_assignments_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_assignments.Visible = true;
            string path = @"..\..\Images\icon-assignments-cyan.png";
            nav_assignments.BackgroundImage = Image.FromFile(path);
        }

        private void nav_mySettings_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_mySettings.Visible = true; 
        }

        private void nav_home_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_home.Visible = true; 
        }

        private void nav_addUser_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_addUser.Visible = true;
            string path = @"..\..\Images\icon-adminAdd-cyan.png";
            nav_addUser.BackgroundImage = Image.FromFile(path);
        }

        private void nav_logOut_Click(object sender, EventArgs e)
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

        private void nav_addUser_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-adminAdd-cyan.png";
            nav_addUser.BackgroundImage = Image.FromFile(path);
        }

        private void nav_addUser_MouseLeave(object sender, EventArgs e)
        {
            if (panel_addUser.Visible == true)
            {
                string path = @"..\..\Images\icon-adminAdd-cyan.png";
                nav_addUser.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-adminAdd.png";
                nav_addUser.BackgroundImage = Image.FromFile(path);
            }
        }

        private void nav_manage_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-adminManage-cyan.png";
            nav_manage.BackgroundImage = Image.FromFile(path);
        }

        private void nav_manage_MouseLeave(object sender, EventArgs e)
        {
            if (panel_manage.Visible == true)
            {
                string path = @"..\..\Images\icon-adminManage-cyan.png";
                nav_manage.BackgroundImage = Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-adminManage.png";
                nav_manage.BackgroundImage = Image.FromFile(path);
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


        /* Initialisera alla boxar vid laddning */

        private void initializeBoxes()
        {
            users = DataAccess.requestUserList();


            /* Fyller listboxen med användare */
            lb_manage_employees.DataSource = users.Select(x => new { ID = x[0], FirstName = x[1], LastName = x[2], Level = x[3], Phone = x[4], Email = x[5], Address = x[6], Password = x[7], Birthdate = x[8] }).ToList();
            lb_manage_employees.DisplayMember = "FirstName";
            lb_manage_employees.ValueMember = "ID";
        }


        /* Uppdatera boxarna efter vald användare */

        private void lb_manage_employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FirstName
            txt_manage_firstName.Text = users[lb_manage_employees.SelectedIndex].GetValue(1).ToString();
            // LastName
            txt_manage_lastName.Text = users[lb_manage_employees.SelectedIndex].GetValue(2).ToString();
            // Personnummer
            txt_manage_personalNumber.Text = users[lb_manage_employees.SelectedIndex].GetValue(8).ToString();
            // Address
            txt_manage_adress.Text = users[lb_manage_employees.SelectedIndex].GetValue(6).ToString();
            // Phone
            txt_manage_phone.Text = users[lb_manage_employees.SelectedIndex].GetValue(4).ToString();
            // Email
            txt_manage_email.Text = users[lb_manage_employees.SelectedIndex].GetValue(5).ToString();
            // Password
            txt_manage_password.Text = users[lb_manage_employees.SelectedIndex].GetValue(7).ToString();
        }


        /* Uppdatera vald användares användarinfo med data från boxarna */

        private void btn_manage_confirm_Click(object sender, EventArgs e)
        {
            DataAccess.updateUser(int.Parse(lb_manage_employees.SelectedValue.ToString()), txt_manage_firstName.Text, txt_manage_lastName.Text, txt_manage_phone.Text, txt_manage_email.Text, txt_manage_adress.Text, txt_manage_password.Text, txt_manage_personalNumber.Text);

            initializeBoxes();
            MessageBox.Show("Användare uppdaterades.");
        }


        /* Ta bort den i listan valda användaren. */

        private void btn_manage_remove_Click(object sender, EventArgs e)
        {
            DataAccess.deleteUser(int.Parse(lb_manage_employees.SelectedValue.ToString()));

            initializeBoxes();
            MessageBox.Show("Användare togs bort.");
        }


        /* Lägg till en användare med data från fälten. */

        private void btn_add_confirm_Click(object sender, EventArgs e)
        {
            DataAccess.createUser(txt_add_firstName.Text, txt_add_lastName.Text, int.Parse(cb_add_position.Text), txt_add_phone.Text, txt_add_email.Text, txt_add_adress.Text, txt_add_password.Text, txt_add_personalNumber.Text);

            initializeBoxes();
            MessageBox.Show("Användare lades till.");
        }


        /* Ta bort "placeholder"-texten. */

        private void removeText(object sender, EventArgs e)
        {
            TextBox felt = sender as TextBox;

            if (felt.Text == felt.AccessibleName) { felt.Text = ""; }
        }


        /* Lägg till "placeholder"-text. */

        private void addText(object sender, EventArgs e)
        {
            TextBox felt = sender as TextBox;

            if (string.IsNullOrEmpty(felt.Text)) { felt.Text = felt.AccessibleName; }

        }

        /*Lägg till ett uppdrag*/

        private void btn_assignments_confirm_Click(object sender, EventArgs e)
        {
            string missionName = txt_assignments_name.Text;
            string description = txt_assignments_description.Text;
            string startdate = dpicker_assignments_startDate.Value.Date.ToString("yyyy/MM/dd");
            string enddate = dpicker_assignments_endDate.Value.Date.ToString("yyyy/MM/dd");
            int costcenter = Convert.ToInt32(txt_assignments_costCenter.Text);

            DataAccess.addMission(missionName, description, startdate, costcenter, enddate);
            MessageBox.Show("Nytt uppdrag lades till");

            //lb_assignments_assignmentList.Items.Clear();
            showMissions(); 
        }

    
        /*Fyll uppdragslista*/
        private void showMissions()
        {
            missions = DataAccess.getMissionDetails();


            lb_assignments_assignmentList.DataSource = missions.Select(x => new { ID = x[0], MissionName = x[1], Description = x[2], StartDate = x[3], costcenter = x[4], Enddate = x[5]}).ToList();
            lb_assignments_assignmentList.DisplayMember = "MissionName";
            lb_assignments_assignmentList.ValueMember = "ID";
        
           
        }
        /*Tilldela fälten aktuellt värde för valt uppdrag*/

        private void lb_assignments_assignmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sdate = missions[lb_assignments_assignmentList.SelectedIndex].GetValue(3).ToString();
            /* string year = sdate.Substring(0,3);
             string month = sdate.Substring(5,6);
             string day = sdate.Substring(8, 9);

             int newYear = Convert.ToInt32(year);
             int newMonth = Convert.ToInt32(month);
             int newDay = Convert.ToInt32(day);*/


            txt_assignments_manageName.Text = missions[lb_assignments_assignmentList.SelectedIndex].GetValue(1).ToString();
            txt_assignments_manageDescription.Text = missions[lb_assignments_assignmentList.SelectedIndex].GetValue(2).ToString();
            txt_assignments_manageCostCenter.Text = missions[lb_assignments_assignmentList.SelectedIndex].GetValue(4).ToString();
            // dpicker_assignment_manage_startDate.Value = new DateTime(newYear, newMonth, newDay);
            //missions[lb_assignments_assignmentList.SelectedIndex].GetValue(3);

        }

        private void txt_assignments_update_Click(object sender, EventArgs e)
        {
            string missionName = txt_assignments_manageName.Text;
            string description = txt_assignments_manageDescription.Text;
            string startdate = dpicker_assignment_manage_startDate.Value.Date.ToString("yyyy/MM/dd");
            string enddate = dpicker_assignment_manage_endDate.Value.Date.ToString("yyyy/MM/dd");
            int costcenter = Convert.ToInt32(txt_assignments_manageCostCenter.Text);

            DataAccess.updateMission(int.Parse(lb_assignments_assignmentList.SelectedValue.ToString()), missionName, description, startdate, costcenter, enddate);

            showMissions();
            MessageBox.Show("Uppdrag uppdaterades");
        }

        private void fillUserInformation()
        {
            List<List<string>> staffInformation = DataAccess.getUserInformation(id);

            txt_mySettings_firstName.Text = staffInformation[0][0].ToString() + " " + staffInformation[0][1].ToString();
            txt_mySettings_lastName.Text = staffInformation[0][2].ToString();
            txt_mySettings_email.Text = staffInformation[0][3].ToString();
            txt_mySettings_password.Text = staffInformation[0][4].ToString();

            txt_mySettings_employmentNumber.Text = staffInformation[0][5].ToString();
            txt_mySettings_personalNumber.Text = staffInformation[0][6].ToString().Substring(0, 10);

            if (staffInformation[0][7].ToString().Equals("1"))
            {
                txt_mySettings_position.Text = "Konsult";
            }
            else if (staffInformation[0][7].ToString().Equals("2"))
            {
                txt_mySettings_position.Text = "Chef";
            }
            else if (staffInformation[0][7].ToString().Equals("3"))
            {
                txt_mySettings_position.Text = "Ekonom";
            }
            else if (staffInformation[0][7].ToString().Equals("4"))
            {
                txt_mySettings_position.Text = "Administratör";
            }

        }
  
    }
}
