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
using iTextSharp.text; 
using iTextSharp.text.pdf;



namespace vITs
{
    public partial class Manager : Form
    {
        
        private int id;
        private List<string[]> unapprovedPrePays = DataAccess.requestUnApprovedPrePays();
        private List<int> tripIDGhost = new List<int>(); 
        
        public Manager()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;

            initializeBoxes();
            fillEmployeeList(); 

        }

        private void hideAllPanels()
        {
            panel_home.Visible = false;
            panel_trip.Visible = false;
            string path = @"..\..\Images\icon-travel-grey.png";
            nav_travel.BackgroundImage = System.Drawing.Image.FromFile(path);
            
            panel_myTrips.Visible = false;
            string path1 = @"..\..\Images\icon-mytravels-grey.png";
            nav_mytravels.BackgroundImage = System.Drawing.Image.FromFile(path1);
           
            panel_prepayment.Visible = false;
            string path3 = @"..\..\Images\icon-prepayment-grey.png";
            nav_prepayment.BackgroundImage = System.Drawing.Image.FromFile(path3);
            
            panel_assignments.Visible = false;
            string path2 = @"..\..\Images\icon-assignments-grey.png";
            nav_assignments.BackgroundImage = System.Drawing.Image.FromFile(path2);
            
            panel_mySettings.Visible = false;

            panel_toDo.Visible = false;
            string path4 = @"..\..\Images\icon-manager-manage.png";
            nav_toDo.BackgroundImage = System.Drawing.Image.FromFile(path4);
            
            panel_reports.Visible = false;
            string path5 = @"..\..\Images\icon-reports.png";
            nav_report.BackgroundImage = System.Drawing.Image.FromFile(path5);

        }

        private void nav_travel_MouseClick(object sender, MouseEventArgs e)
        {
            hideAllPanels(); 
            panel_trip.Visible = true;
            string path = @"..\..\Images\icon-travel-cyan.png";
            nav_travel.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_mytravels_Click(object sender, EventArgs e)
        {
            hideAllPanels(); 
            panel_myTrips.Visible = true;
            string path = @"..\..\Images\icon-mytravels-cyan.png";
            nav_mytravels.BackgroundImage = System.Drawing.Image.FromFile(path);
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
            nav_assignments.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_prepayment_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_prepayment.Visible = true;
            string path = @"..\..\Images\icon-prepayment-cyan.png";
            nav_prepayment.BackgroundImage = System.Drawing.Image.FromFile(path);
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
            nav_toDo.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_report_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panel_reports.Visible = true;
            string path = @"..\..\Images\icon-reports-cyan.png";
            nav_report.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_travel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-travel-cyan.png";
            nav_travel.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_travel_MouseLeave(object sender, EventArgs e)
        {
            if (panel_trip.Visible == true)
            {
                string path = @"..\..\Images\icon-travel-cyan.png";
                nav_travel.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-travel-grey.png";
                nav_travel.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
        }

        private void nav_mytravels_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-mytravels-cyan.png";
            nav_mytravels.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_mytravels_MouseLeave(object sender, EventArgs e)
        {
            if (panel_myTrips.Visible == true)
            {
                string path = @"..\..\Images\icon-mytravels-cyan.png";
                nav_mytravels.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-mytravels-grey.png";
                nav_mytravels.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
        }

        private void nav_assignments_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-assignments-cyan.png";
            nav_assignments.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_assignments_MouseLeave(object sender, EventArgs e)
        {
            if (panel_assignments.Visible == true)
            {
                string path = @"..\..\Images\icon-assignments-cyan.png";
                nav_assignments.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-assignments-grey.png";
                nav_assignments.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
        }

        private void nav_prepayment_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-prepayment-cyan.png";
            nav_prepayment.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_prepayment_MouseLeave(object sender, EventArgs e)
        {
            if (panel_prepayment.Visible == true)
            {
                string path = @"..\..\Images\icon-prepayment-cyan.png";
                nav_prepayment.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-prepayment-grey.png";
                nav_prepayment.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
        }

        private void nav_toDo_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-manager-manage-cyan.png";
            nav_toDo.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_toDo_MouseLeave(object sender, EventArgs e)
        {
            if (panel_toDo.Visible == true)
            {
                string path = @"..\..\Images\icon-manager-manage-cyan.png";
                nav_toDo.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-manager-manage.png";
                nav_toDo.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
        }

        private void nav_report_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-reports-cyan.png";
            nav_report.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void nav_report_MouseLeave(object sender, EventArgs e)
        {
            if (panel_reports.Visible == true)
            {
                string path = @"..\..\Images\icon-reports-cyan.png";
                nav_report.BackgroundImage = System.Drawing.Image.FromFile(path);
            }
            else
            {
                string path = @"..\..\Images\icon-reports.png";
                nav_report.BackgroundImage = System.Drawing.Image.FromFile(path);
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


        /* Neka-knappen. När den trycks så ändras Approved-värdet på vald förskottsbetalning. */

        private void btn_toDo_deny_Click(object sender, EventArgs e)
        {
            DataAccess.denyPrePay(unapprovedPrePays[lb_toDo_employee.SelectedIndex].GetValue(0).ToString());

            MessageBox.Show("Förskottsbetalningen nekades.");

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



        private void fillEmployeeList()
        {

            List<string[]> list = new List<string[]>();
            list = DataAccess.requestUserList();

            lb_employeeList.DataSource = list.Select(x => new {ID = x[0], FirstName = x[1], LastName = x[2] }).ToList();
            lb_employeeList.DisplayMember = "FirstName";
            lb_employeeList.ValueMember = "ID";
        }

        private void lb_employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {   

            /* Koden som ligger innanför try fuckar ur vid uppstart, men funkar fint efter det. */

            lb_employee_travelList.Items.Clear();
            tripIDGhost.Clear();

            try
            {
                int id = Convert.ToInt32(lb_employeeList.SelectedValue);
                string result; 

                List<List<string>> tripList = DataAccess.getEmployeeTrips(id);

                lb_employee_travelList.Items.Add("Ingen resa");

                /* Lägg till ett nummer som inte används, för att skapa rätt ordning */
                tripIDGhost.Add(999); 
                

                foreach (List<string> str in tripList)
                {
                    result = str[1] + "\t\t" + str[2];
                    lb_employee_travelList.Items.Add(result);
                    tripIDGhost.Add(Convert.ToInt32(str[0]));
                   
                }

            }
            catch (Exception exc)
            {

            }
            


        }

        private void lb_employee_travelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lb_employee_travelList.SelectedItem.ToString().Equals("Ingen resa"))
            {
                dpicker_employee_date.Enabled = true;
                cb_employee_timeSpan.Enabled = true;

            }
            else
            {
                dpicker_employee_date.Enabled = false;
                cb_employee_timeSpan.Enabled = false; 
            }
            
        }

        private void report_employee_pdf_Click(object sender, EventArgs e)
        {
            if (lb_employee_travelList.SelectedItem.ToString().Equals("Ingen resa"))
            {
                // Ta hänsyn till tidsintervall, och startdatum. Annars ...
            }
            else
            {
               /* Definiera ID:t på den resan som man vill skapa rapport för */
                int id = tripIDGhost[lb_employee_travelList.SelectedIndex];
                 List<List<string>> result = new List<List<string>>(); 

               /* Variabellista som används i rapporten, innehåller: 
                * ------------------------------------------------
                * consultName - Förnamn och efternamn på konsulten.
                * employeeNumber - anställningsnummer, mao databas-id:t.
                * email - konsultens email. 
                * phone - konsultens telefonnummer. 
                * 
                * 
                * 
                */

                string consultName = null;
                string employeeNumber = null;
                string email = null;
                string phone = null;

                string missionName = null;
                string missionStartDate = null;
                string missionEndDate = null;

                string land = null;
                int traktamente = 0;
                string transit = null;

                int breakfastCost = 0;
                int lunchCost = 0;
                int dinnerCost = 0; 

                string tripStartDate = null;
                string tripEndDate = null;
                
                int breakfasts = 0;
                int lunches = 0;
                int dinners = 0;

                int totalsum = 0;
                int totalrecieptSum = 0;




                /* Slut på variabler */

                result = DataAccess.getReportEmployeeInformation(id);

                foreach (List<string> str in result)
                {
                    consultName = str[0] + " " + str[1];
                    employeeNumber = str[2]; 
                    email = str[3];
                    phone = str[4]; 
                }

                result = DataAccess.getReportMissionInformation(id);

                foreach (List<string> str in result)
                {
                    missionName = str[0];
                    missionStartDate = str[1];
                    missionEndDate = str[2];

                }

                result = DataAccess.getReportDestinationInformation(id);

                foreach (List<string> str in result)
                {
                    land = str[0];
                    traktamente = Convert.ToInt32(str[1]);
                    breakfastCost = Convert.ToInt32(str[2]);
                    lunchCost = Convert.ToInt32(str[3]);
                    dinnerCost = Convert.ToInt32(str[4]); 

                    transit = str[5];
                    tripStartDate = str[6];
                    tripEndDate = str[7];

                    breakfasts = Convert.ToInt32(str[8]);
                    lunches = Convert.ToInt32(str[9]);
                    dinners = Convert.ToInt32(str[10]); 

                }


               
                 

                /* PDF-CODE */

                Document myDocument = new Document(PageSize.A4);
                PdfWriter.GetInstance(myDocument, new FileStream(@"..\..\iTextSharp\EmployeeReport.pdf", FileMode.Create));

                myDocument.Open();

                iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsHead.jpg");
                header.ScaleToFit(myDocument.PageSize.Width, 110f);
                myDocument.Add(header);


                Paragraph consName = new Paragraph("Konsultnamn: " + consultName);
                Paragraph consNumber = new Paragraph("Anställningsnummer: " + employeeNumber);
                Paragraph consEmail = new Paragraph("Emailadress: " + email);
                Paragraph consPhone = new Paragraph("Telefonnummer: " + phone);

                myDocument.Add(consName);
                myDocument.Add(consNumber);
                myDocument.Add(consEmail);
                myDocument.Add(consPhone);


                iTextSharp.text.Image line = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsLine.jpg");
                line.ScaleToFit(myDocument.PageSize.Width, 25f);
                myDocument.Add(line);

                /* destinationkoden */

                Paragraph mission = new Paragraph("Uppdrag: " + missionName);
                Paragraph missiondate = new Paragraph("Datum: " + missionStartDate + " -- " + missionEndDate);
                myDocument.Add(mission);
                myDocument.Add(missiondate);

                myDocument.Add(line);
                string tormat = "{0,-90} {1,-30} {2, -30} ";
                string sormat = "{0,-81} {1,-30} {2, -30} ";
                string kormat = "{0,-92} {1,-30} {2, -40} ";
                Paragraph country = new Paragraph(land);
                Paragraph destination = new Paragraph(string.Format(tormat, "Datum", "Antal", "Pris"));
                Paragraph misc = new Paragraph(string.Format(sormat, tripStartDate + " -- " + tripEndDate, "6", traktamente));
                Paragraph BF = new Paragraph(string.Format(kormat, "Frukostar:", breakfasts, breakfastCost));
                Paragraph lurre = new Paragraph(string.Format(kormat, "Luncher:", lunches, lunchCost));
                Paragraph middag = new Paragraph(string.Format(kormat, "Middagar:", dinners, dinnerCost));

                myDocument.Add(country);
                myDocument.Add(destination);
                myDocument.Add(misc);
                myDocument.Add(BF);
                myDocument.Add(lurre);
                myDocument.Add(middag);

                myDocument.Add(line);
                /* För att loopa ut alla kvitton som tillhör specifik resa. */
                result = DataAccess.getReportReceiptInformation(id);
                Paragraph reciept;
                string exists; 

                string format = "{0,-20} {1,-20} {2, -20} {3, -20} {4, -20}";
                
                foreach(List<string> str in result)
                {
                    if (Convert.ToInt32(str[5]) == 0)
                    {
                        exists = "Kvitto finns";
                    }
                    else
                    {
                        exists = "Kvitto finns inte";

                    }
                    reciept = new Paragraph(string.Format(format, str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString() + " " + str[4].ToString(), exists));
                    myDocument.Add(reciept);
                     
                }
                

               
               


                /* KÖR PDF */
                myDocument.Close();
                System.Diagnostics.Process.Start(@"..\..\iTextSharp\EmployeeReport.pdf");
            }
        }

       

        

      
    }
}
