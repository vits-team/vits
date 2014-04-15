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

        public Admin()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;
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



    

        

       

        

      
    }
}
