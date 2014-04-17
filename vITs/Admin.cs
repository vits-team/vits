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

        public Admin()
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
            List<string[]> users = DataAccess.requestUserList();


            /* Fyller listboxen med användare */
            lb_manage_employees.DataSource = users.Select(x => new { ID = x[0], FirstName = x[1], LastName = x[2], Level = x[3], Phone = x[4], Email = x[5], Address = x[6], Password = x[7] }).ToList();
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
            txt_manage_personalNumber.Text = "0000-00-00";
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
            DataAccess.updateUser(lb_manage_employees.SelectedValue.ToString(), txt_manage_firstName.ToString(), txt_manage_lastName.ToString(), txt_manage_phone.ToString(), txt_manage_email.ToString(), txt_manage_adress.ToString(), txt_manage_password.ToString());

            initializeBoxes();
        }


    

        

       

        

      
    }
}
