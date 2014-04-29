using System;
using System.IO; 
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
    public partial class Economy : Form
    {
        private int id;

        public Economy()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;
            lbl_myName.Text = DataAccess.requestFullName(id);

            fillUserInformation(); 
        }

        private void hideAllPanels()
        {
            panel_home.Visible = false;
            panel_reports.Visible = false;
            string path = @"..\..\Images\icon-reports.png";
            nav_report.BackgroundImage = Image.FromFile(path);
            panel_mySettings.Visible = false; 
            
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

        private void nav_report_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_reports.Visible = true;
            string path = @"..\..\Images\icon-reports-cyan.png";
            nav_report.BackgroundImage = Image.FromFile(path);
           
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

        private void report_employee_pdf_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf-cyan.png";
            report_employee_pdf.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_pdf, "Klicka för att skriva ut som PDF"); 
        }

        private void report_employee_pdf_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf.png";
            report_employee_pdf.BackgroundImage = Image.FromFile(path);
        }

    

        private void report_employee_excel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel-cyan.png";
            report_employee_excel.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_excel, "Klicka för att skriva ut som excel"); 
        }

        private void report_employee_excel_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel.png";
            report_employee_excel.BackgroundImage = Image.FromFile(path);
        }

        private void report_employee_system_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system-cyan.png";
            report_employee_system.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_system, "Klicka för att skriva ut internt"); 
        }

        private void report_employee_system_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system.png";
            report_employee_system.BackgroundImage = Image.FromFile(path);
        }

        private void report_all_pdf_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf-cyan.png";
            report_all_pdf.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_pdf, "Klicka för att skriva ut pdf"); 
        }

        private void report_all_pdf_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf.png";
            report_all_pdf.BackgroundImage = Image.FromFile(path);
        }

        private void report_all_excel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel-cyan.png";
            report_all_excel.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_excel, "Klicka för att skriva ut som excel"); 
        }

        private void report_all_excel_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel.png";
            report_all_excel.BackgroundImage = Image.FromFile(path);
        }

        private void report_all_system_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system-cyan.png";
            report_all_system.BackgroundImage = Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_system, "Klicka för att skriva ut internt"); 
        }

        private void report_all_system_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system.png";
            report_all_system.BackgroundImage = Image.FromFile(path);
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
