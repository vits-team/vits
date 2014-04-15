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
    public partial class Login : Form
    {

        public static int id = 1;

        public Login()
        {
            InitializeComponent();
        }

        /* Skicka vidare användarID:t till nästa Form, där den sätter värdet på ett fält, så att databas-id:t är lättåtkomligt ifrån andra klasserna. */

        public static int passThisUser()
        {

            return id;

        }


        private void txt_userName_MouseClick(object sender, MouseEventArgs e)
        {
            txt_userName.Text = "";
        }

        private void txt_userName_Leave(object sender, EventArgs e)
        {
            if (txt_userName.Text.Equals(""))
            {
                txt_userName.Text = "Användarnamn";
            }
        }

        private void txt_password_MouseClick(object sender, MouseEventArgs e)
        {
            
            txt_password.Text = "";
            txt_password.PasswordChar = '*';
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text.Equals(""))
            {
                txt_password.PasswordChar = '\0';
                txt_password.Text = "Lösenord";
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            

            int userIdentity = Convert.ToInt32(txt_userName.Text);
            string password = txt_password.Text; 

            if (DataAccess.validateUserLogIn(userIdentity, password) == 1)
            {

                int StaffLevel = DataAccess.requestStaffLevel(userIdentity);

                switch (StaffLevel)
                {
                    case 1: 
                        this.Hide();
                        Consultant c = new Consultant();
                        c.ShowDialog();
                        break; 
                    
                    case 2: 
                        this.Hide();
                        Manager m = new Manager();
                        m.ShowDialog();
                        break; 
                    
                    case 3: 
                        this.Hide();
                        Economy ec = new Economy();
                        ec.ShowDialog();
                        break; 
                    
                    case 4:
                        this.Hide();
                        Admin a = new Admin();
                        a.ShowDialog();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Felaktiga användaruppgifter!"); 
            }

        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            txt_password.Text = "";
            txt_password.PasswordChar = '*';
        }

       

    
    }
}
