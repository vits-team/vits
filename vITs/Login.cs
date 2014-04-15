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
            /* Fixa metod för att kontrollera vilken användartyp man är, samt dess ID ifrån databasen. */


            if (txt_password.Text == "1")
            {
                this.Hide();
                Admin z = new Admin();
                z.ShowDialog();

            }
            else if (txt_password.Text == "2")
            {
                this.Hide();
                Economy x = new Economy();
                x.ShowDialog();
            }
            else if (txt_password.Text == "3")
            {
                this.Hide();
                Manager x = new Manager();
                x.ShowDialog();
            }

            else
            {
                this.Hide();
                Consultant x = new Consultant();
                x.ShowDialog();

            }
            

        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            txt_password.Text = "";
            txt_password.PasswordChar = '*';
        }

       

    
    }
}
