﻿using System;
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
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Excel;

namespace vITs
{
    public partial class Manager : Form
    {
        
        private int id;
        private List<string[]> unapprovedPrePays = DataAccess.requestUnApprovedPrePays();
        private List<int> tripIDGhost = new List<int>();
        private List<int> userIDGhost = new List<int>(); 
        
        public Manager()
        {
            InitializeComponent();
            id = Login.passThisUser();
            hideAllPanels();
            panel_home.Visible = true;

            lbl_myName.Text = DataAccess.requestFullName(id);
            initializeBoxes();
            initializeListview();
            fillEmployeeList();

            fillUserInformation(); 

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


        /* Initialisera listview med resor att godkänna/neka. */

        private void initializeListview()
        {
            List<string[]> trips = DataAccess.getTrips();
            lv_toDo_viewTrips.Clear();
            lv_toDo_viewTrips.View = View.Details;
            lv_toDo_viewTrips.FullRowSelect = true;

            lv_toDo_viewTrips.Columns.Add("Trip ID");
            lv_toDo_viewTrips.Columns.Add("Destination");
            lv_toDo_viewTrips.Columns.Add("Färdsätt");
            lv_toDo_viewTrips.Columns.Add("Uppdrag");
            lv_toDo_viewTrips.Columns.Add("Nekad");


            for(int x = 0; x < trips.Count; x++)
            {
                if (trips[x][7] != DataAccess.currentUserID.ToString())
                {
                    ListViewItem item = new ListViewItem(new[] { trips[x][0].ToString(), trips[x][1].ToString(), trips[x][4].ToString(), trips[x][5].ToString(), trips[x][11].ToString() == "0" ? "Nej" : "Ja" });
                    lv_toDo_viewTrips.Items.Add(item);
                }
            }
            
            
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


        /* Godkänn den i listan valda resan. */

        private void btn_toDo_approveTrip_Click(object sender, EventArgs e)
        {
            DataAccess.approveOfTrip(lv_toDo_viewTrips.SelectedItems[0].Text);

            MessageBox.Show("Resan godkändes.");

            initializeListview();
        }


        /* Neka den i listan valda resan. */

        private void btn_toDo_denyTrip_Click(object sender, EventArgs e)
        {
            DataAccess.denyTrip(lv_toDo_viewTrips.SelectedItems[0].Text);

            MessageBox.Show("Resan nekades.");

            initializeListview();
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
            /* Definiera ID:t på den resan som man vill skapa rapport för */
           
            
            List<List<string>> result = new List<List<string>>();


            /* Variabellista som används i rapporten, innehåller: 
             * ------------------------------------------------
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
            int tripTotalDays = 0; 

            int breakfasts = 0;
            int lunches = 0;
            int dinners = 0;

            int totalsum = 0;
            int totalrecieptSum = 0;
            int allTripTotalSum = 0; 

            /* Slut på variabler */

            if (lb_employee_travelList.SelectedItem.ToString().Equals("Ingen resa") || lb_employee_travelList.SelectedIndex == -1)
            {
                // Ta hänsyn till tidsintervall, och startdatum. Annars ...
                //string date = dpicker_employee_date.Value.Date.ToString();

                

                string datetime = cb_employee_timeSpan.SelectedItem.ToString();
                int selectedId = Convert.ToInt32(lb_employeeList.SelectedValue.ToString());

                int timeSpandays = GetNumberOfTimespanDays(cb_employee_timeSpan.SelectedItem.ToString());
                string getstartdate = dpicker_employee_date.Value.Date.ToString().Substring(0, 10);

                string exists;

                result = DataAccess.getReportTimeSpanUserInformation(selectedId);

                foreach (List<string> str in result)
                {
                    consultName = str[0] + " " + str[1];
                    employeeNumber = str[2];
                    email = str[3];
                    phone = str[4];
                }


                result = DataAccess.getReportTimeSpanUserMissions(selectedId, getstartdate, timeSpandays);


                Document myDocument = new Document(PageSize.A4);

                try
                {
                    PdfWriter.GetInstance(myDocument, new FileStream(@"..\..\iTextSharp\EmployeeReport.pdf", FileMode.Create));
                }
                catch (Exception exc) 
                {
                    MessageBox.Show("Dokumentet är redan öppet, du måste stänga det först."); 

                }
                   

                myDocument.Open();

                iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsHead.jpg");
                header.ScaleToFit(myDocument.PageSize.Width, 110f);
                myDocument.Add(header);

                iTextSharp.text.Image line = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsLine.jpg");
                line.ScaleToFit(myDocument.PageSize.Width, 25f);

                iTextSharp.text.Font footFont = FontFactory.GetFont("Century Gothic", 10);

                string format = "{0,-20} {1,-20} {2, -25} {3, -20} {4, -20}";
                string format1 = "{0,-75} {1,-20} {2, -30} ";
                string format2 = "{0,-70} {1,-20} {2, -30} ";
                string format3 = "{0,-90} {1,-30} {2, -30} ";
                string format4 = "{0,-81} {1,-30} {2, -30} ";
                string format5 = "{0,-92} {1,-30} {2, -40} ";

                Paragraph consName = new Paragraph("Konsultnamn: " + consultName);
                Paragraph consNumber = new Paragraph("Anställningsnummer: " + employeeNumber);
                Paragraph consEmail = new Paragraph("Emailadress: " + email);
                Paragraph consPhone = new Paragraph("Telefonnummer: " + phone);



                myDocument.Add(consName);
                myDocument.Add(consNumber);
                myDocument.Add(consEmail);
                myDocument.Add(consPhone);

                
                myDocument.Add(line);

 
                foreach (List<string> str in result)
                {
                    Paragraph mission = new Paragraph("Uppdrag: " + str[0]);
                    Paragraph missiondate = new Paragraph("Datum: " + str[1].Substring(0,10) + " -- " + str[2].Substring(0,10));

                    myDocument.Add(mission);
                    myDocument.Add(missiondate);
                }
                

                myDocument.Add(line);

                result = DataAccess.getReportTimeSpanUserTrips(selectedId, getstartdate, timeSpandays);


                
                foreach (List<string> str in result)
                {
                    DateTime st = Convert.ToDateTime(str[6]);
                    DateTime end = Convert.ToDateTime(str[7]);
                    TimeSpan span = end - st;
                    tripTotalDays = Convert.ToInt32(span.TotalDays);

                    int reduceBreakfasts = 0;
                    int reduceLunches = 0;
                    int reduceDinners = 0;
                    int prePayment = 0;

                    reduceBreakfasts = Convert.ToInt32(str[8]) * Convert.ToInt32(str[2]);
                    reduceLunches = Convert.ToInt32(str[9]) * Convert.ToInt32(str[3]);
                    reduceDinners = Convert.ToInt32(str[10]) * Convert.ToInt32(str[4]);
                    prePayment = Convert.ToInt32(DataAccess.getPrePayOfTrip(Convert.ToInt32(str[11])));

                    totalsum = (tripTotalDays * Convert.ToInt32(str[1]) - reduceBreakfasts - reduceLunches - reduceDinners - prePayment);

                    Paragraph country = new Paragraph("Destination: " + str[0] + ", Färdsätt: " + str[5]);
                    Paragraph prePay = new Paragraph("Förskottsutbetalning: " + DataAccess.getPrePayOfTrip(Convert.ToInt32(str[11])) + " kr"); 
                    Paragraph destination = new Paragraph(string.Format(format3, "Datum", "Antal", "Pris"));
                    Paragraph misc = new Paragraph(string.Format(format4, str[6].Substring(0,10) + " -- " + str[7].Substring(0,10), tripTotalDays, str[1]));
                    Paragraph BF = new Paragraph(string.Format(format5, "Frukostar:", str[8], str[2]));
                    Paragraph lurre = new Paragraph(string.Format(format5, "Luncher:", str[9], str[3]));
                    Paragraph middag = new Paragraph(string.Format(format5, "Middagar:", str[10], str[4]));
                    Paragraph sumOfTrip = new Paragraph(string.Format(format5, "", "Totalsumma:", totalsum + " Kr"));

                    myDocument.Add(country);
                    myDocument.Add(prePay);
                    myDocument.Add(destination);
                    myDocument.Add(misc);
                    myDocument.Add(BF);
                    myDocument.Add(lurre);
                    myDocument.Add(middag);

                    myDocument.Add(sumOfTrip);
                    myDocument.Add(line);


                    List<List<string>> kvitton = DataAccess.getReportReceiptInformation(Convert.ToInt32(str[11]));
                    List<List<string>> otherCurrencies = new List<List<string>>(); 

                    Paragraph reciept;

                    if (kvitton.Count != 0)
                    {

                        foreach (List<string> kvitto in kvitton)
                        {
                            if (Convert.ToInt32(kvitto[5]) == 0)
                            {
                                exists = "Kvitto finns";
                            }
                            else
                            {
                                exists = "Kvitto finns inte";

                            }

                            if (kvitto[4].ToString() != "SEK")
                            {
                                List<string> theCurrency = new List<string>();
                                theCurrency.Add(kvitto[3].ToString());
                                theCurrency.Add(kvitto[4].ToString());

                                otherCurrencies.Add(theCurrency);
                            }
                            else
                            {
                                totalrecieptSum += Convert.ToInt32(kvitto[3]);
                            }

                            reciept = new Paragraph(string.Format(format, kvitto[0].ToString(), kvitto[1].ToString(), kvitto[2].ToString(), kvitto[3].ToString() + " " + kvitto[4].ToString(), exists));
                            myDocument.Add(reciept);

                        }


                        foreach (List<string> oC in otherCurrencies)
                        {


                            if (oC[1].Equals("EUR"))
                            {
                                int toAdd = Convert.ToInt32(oC[0]) * 9;
                                totalrecieptSum += toAdd;

                            }
                            else if (oC[1].Equals("USD"))
                            {
                                double toAdd = Convert.ToInt32(oC[0]) * 6.5;
                                totalrecieptSum += (int)toAdd;

                            }
                            else if (oC[1].Equals("GBP"))
                            {
                                double toAdd = Convert.ToInt32(oC[0]) * 10.9;
                                totalrecieptSum += (int)toAdd;

                            }
                            else if (oC[1].Equals("NOK"))
                            {
                                double toAdd = Convert.ToInt32(oC[0]) * 1.1;
                                totalrecieptSum += (int)toAdd;
                            }
                            else if (oC[1].Equals("DKK"))
                            {
                                double toAdd = Convert.ToInt32(oC[0]) * 1.2;
                                totalrecieptSum += (int)toAdd;

                            }

                        }

                        Paragraph recieptSumma = new Paragraph(string.Format(format5, "", "Kvitton: ", totalrecieptSum + " Kr"));
                        myDocument.Add(line);
                        myDocument.Add(recieptSumma);

                        allTripTotalSum += totalsum + totalrecieptSum; 
                    }
                    else
                    {
                        Paragraph noKvitts = new Paragraph("Inga tillhörande kvitton");
                        myDocument.Add(noKvitts);
                        allTripTotalSum += totalsum; 

                    }

                    

                }

                Paragraph allTripsCost = new Paragraph(string.Format(format5, "", "Alla resor: ", allTripTotalSum + " Kr"));
                myDocument.Add(line);
                myDocument.Add(allTripsCost);


                Paragraph currs = new Paragraph("Rådande växelkurser som tagits med i uträkningen", footFont);
                Paragraph euro = new Paragraph("EUR - rådande växelkurs: 9.00 SEK", footFont);
                Paragraph usd = new Paragraph("USD - rådande växelkurs: 6.50 SEK", footFont);
                Paragraph gbp = new Paragraph("GBP - rådande växelkurs: 10.90 SEK", footFont);
                Paragraph nok = new Paragraph("NOK - rådande växelkurs: 1.10 SEK", footFont);
                Paragraph dkk = new Paragraph("DKK - rådande växelkurs: 1.20 SEK", footFont);

                myDocument.Add(currs);
                myDocument.Add(euro);
                myDocument.Add(usd);
                myDocument.Add(gbp);
                myDocument.Add(nok);
                myDocument.Add(dkk);

                myDocument.Close();
                System.Diagnostics.Process.Start(@"..\..\iTextSharp\EmployeeReport.pdf");

            }
            else
            {
              
                // Tilldela variabler värden ifrån databasen
                int id = tripIDGhost[lb_employee_travelList.SelectedIndex];
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
                    missionStartDate = str[1].Substring(0,10);
                    missionEndDate = str[2].Substring(0,10);

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
                    tripStartDate = str[6].Substring(0,10);
                    tripEndDate = str[7].Substring(0,10);

                    breakfasts = Convert.ToInt32(str[8]);
                    lunches = Convert.ToInt32(str[9]);
                    dinners = Convert.ToInt32(str[10]); 

                }

                /* Kalkyl av totalsumma */

                DateTime st = Convert.ToDateTime(tripStartDate);
                DateTime end = Convert.ToDateTime(tripEndDate);
                TimeSpan span = end - st;
                tripTotalDays = Convert.ToInt32(span.TotalDays);


                int reduceBreakfasts = 0;
                int reduceLunches = 0;
                int reduceDinners = 0;
                int prePayment = 0; 

                reduceBreakfasts = breakfasts * breakfastCost;
                reduceLunches = lunches * lunchCost;
                reduceDinners = dinners * dinnerCost;
                prePayment = DataAccess.getPrePayOfTrip(id); 
                totalsum = (tripTotalDays * traktamente) -reduceBreakfasts -reduceLunches -reduceDinners - prePayment;  

                /* PDF-CODE */

                
                Document myDocument = new Document(PageSize.A4);
                try
                {
                    PdfWriter.GetInstance(myDocument, new FileStream(@"..\..\iTextSharp\EmployeeReport.pdf", FileMode.Create));
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Dokumentet körs redan, stäng det."); 
                }

                myDocument.Open();

                iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsHead.jpg");
                header.ScaleToFit(myDocument.PageSize.Width, 110f);
                myDocument.Add(header);

                iTextSharp.text.Image line = iTextSharp.text.Image.GetInstance(@"..\..\Images\vitsLine.jpg");
                line.ScaleToFit(myDocument.PageSize.Width, 25f);

                iTextSharp.text.Font footFont = FontFactory.GetFont("Century Gothic", 10);

                string format = "{0,-20} {1,-20} {2, -25} {3, -20} {4, -20}";
                string format3 = "{0,-90} {1,-30} {2, -30} ";
                string format4 = "{0,-81} {1,-30} {2, -30} ";
                string format5 = "{0,-92} {1,-30} {2, -40} ";

                // Alla miljoner paragrafer 

                Paragraph consName = new Paragraph("Konsultnamn: " + consultName);
                Paragraph consNumber = new Paragraph("Anställningsnummer: " + employeeNumber);
                Paragraph consEmail = new Paragraph("Emailadress: " + email);
                Paragraph consPhone = new Paragraph("Telefonnummer: " + phone);

                Paragraph mission = new Paragraph("Uppdrag: " + missionName);
                Paragraph missiondate = new Paragraph("Datum: " + missionStartDate.Substring(0,10) + " -- " + missionEndDate.Substring(0,10));

                Paragraph country = new Paragraph("Destination: " + land + ", Färdsätt: " + transit);
                Paragraph prepay = new Paragraph("Förskottsutbetalning: " + prePayment + " kr"); 
                Paragraph destination = new Paragraph(string.Format(format3, "Datum", "Antal", "Pris"));
                Paragraph misc = new Paragraph(string.Format(format4, tripStartDate + " -- " + tripEndDate, tripTotalDays, traktamente));
                Paragraph BF = new Paragraph(string.Format(format5, "Frukostar:", breakfasts, breakfastCost));
                Paragraph lurre = new Paragraph(string.Format(format5, "Luncher:", lunches, lunchCost));
                Paragraph middag = new Paragraph(string.Format(format5, "Middagar:", dinners, dinnerCost));
                Paragraph sumOfTrip = new Paragraph(string.Format(format5, "", "Totalsumma", totalsum + " Kr"));

                Paragraph reciept;
                

                string exists;
                List<List<string>> otherCurrencies = new List<List<string>>(); 

                myDocument.Add(consName);
                myDocument.Add(consNumber);
                myDocument.Add(consEmail);
                myDocument.Add(consPhone);

                myDocument.Add(line);
                myDocument.Add(mission);
                myDocument.Add(missiondate);
                myDocument.Add(line);

                myDocument.Add(country);
                myDocument.Add(prepay);
                myDocument.Add(destination);
                myDocument.Add(misc);
                myDocument.Add(BF);
                myDocument.Add(lurre);
                myDocument.Add(middag);

                myDocument.Add(line);
                myDocument.Add(sumOfTrip);

                /* För att loopa ut alla kvitton som tillhör specifik resa. */

                result = DataAccess.getReportReceiptInformation(id);
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

                    if (str[4].ToString() != "SEK")
                    {
                        List<string> theCurrency = new List<string>();
                        theCurrency.Add(str[3].ToString());
                        theCurrency.Add(str[4].ToString());

                        otherCurrencies.Add(theCurrency); 
                    }
                    else
                    {
                        totalrecieptSum += Convert.ToInt32(str[3]);
                    }
                   
                    reciept = new Paragraph(string.Format(format, str[0].ToString(), str[1].ToString(), str[2].ToString(), str[3].ToString() + " " + str[4].ToString(), exists));
                    myDocument.Add(reciept);
                     
                }

                // Räkna om valutor till svenska kronor

                foreach (List<string> str in otherCurrencies)
                {


                    if (str[1].Equals("EUR"))
                    {
                        int toAdd = Convert.ToInt32(str[0]) * 9;
                        totalrecieptSum += toAdd;

                    }
                    else if (str[1].Equals("USD"))
                    {
                        double toAdd = Convert.ToInt32(str[0]) * 6.5;
                        totalrecieptSum += (int)toAdd;

                    }
                    else if (str[1].Equals("GBP"))
                    {
                        double toAdd = Convert.ToInt32(str[0]) * 10.9;
                        totalrecieptSum += (int)toAdd;

                    }
                    else if (str[1].Equals("NOK"))
                    {
                        double toAdd = Convert.ToInt32(str[0]) * 1.1;
                        totalrecieptSum += (int)toAdd;
                    }
                    else if (str[1].Equals("DKK"))
                    {
                        double toAdd = Convert.ToInt32(str[0]) * 1.2;
                        totalrecieptSum += (int)toAdd;

                    }

                }

                Paragraph recieptSumma = new Paragraph(string.Format(format5, "", "Totalsumma: ", totalrecieptSum + " Kr"));
               

                myDocument.Add(line);
                myDocument.Add(recieptSumma);

                Paragraph costofTrip = new Paragraph(string.Format(format5, "", "Resan totalt: ", (totalrecieptSum + totalsum) + " Kr"));
                myDocument.Add(costofTrip); 

                Paragraph currs = new Paragraph("Rådande växelkurser som tagits med i uträkningen", footFont);
                Paragraph euro = new Paragraph("EUR - rådande växelkurs: 9.00 SEK", footFont);
                Paragraph usd = new Paragraph("USD - rådande växelkurs: 6.50 SEK", footFont);
                Paragraph gbp = new Paragraph("GBP - rådande växelkurs: 10.90 SEK", footFont);
                Paragraph nok = new Paragraph("NOK - rådande växelkurs: 1.10 SEK", footFont); 
                Paragraph dkk = new Paragraph("DKK - rådande växelkurs: 1.20 SEK", footFont);

                myDocument.Add(currs);
                myDocument.Add(euro);
                myDocument.Add(usd);
                myDocument.Add(gbp);
                myDocument.Add(nok);
                myDocument.Add(dkk);
                


                /* KÖR PDF */
                myDocument.Close();
                System.Diagnostics.Process.Start(@"..\..\iTextSharp\EmployeeReport.pdf");
            }
        }

        private int GetNumberOfTimespanDays(string value)
        {
            int timeSpandays = 0;

            if (value.Equals("Vecka"))
            {
                timeSpandays = 7;
            }
            else if (value.Equals("Månad"))
            {
                timeSpandays = 30;
            }
            else if (value.Equals("Kvartal"))
            {
                timeSpandays = 90;
            }
            else if (value.Equals("År"))
            {
                timeSpandays = 365;
            }

            return timeSpandays;
        
        }

        private void report_employee_pdf_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf-cyan.png";
            report_employee_pdf.BackgroundImage = System.Drawing.Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_pdf, "Klicka för att skriva ut pdf"); 
        }

        private void report_employee_pdf_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf.png";
            report_employee_pdf.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void report_employee_excel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel-cyan.png";
            report_employee_excel.BackgroundImage = System.Drawing.Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_excel, "Klicka för att skriva ut som excel"); 
        }

        private void report_employee_excel_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel.png";
            report_employee_excel.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void report_employee_system_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system-cyan.png";
            report_employee_system.BackgroundImage = System.Drawing.Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_employee_system, "Klicka för att skriva ut internt"); 
        }

        private void report_employee_system_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system.png";
            report_employee_system.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void report_all_pdf_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf-cyan.png";
            report_all_pdf.BackgroundImage = System.Drawing.Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_pdf, "Klicka för att skriva ut pdf"); 
        }

        private void report_all_pdf_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-pdf.png";
            report_all_pdf.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

      

        private void report_all_excel_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel.png";
            report_all_excel.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void report_all_system_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system-cyan.png";
            report_all_system.BackgroundImage = System.Drawing.Image.FromFile(path);

            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_system, "Klicka för att skriva ut internt"); 
        }

        private void report_all_system_MouseLeave(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-system.png";
            report_all_system.BackgroundImage = System.Drawing.Image.FromFile(path);
        }

        private void report_all_excel_MouseEnter(object sender, EventArgs e)
        {
            string path = @"..\..\Images\icon-report-excel-cyan.png";
            report_all_excel.BackgroundImage = System.Drawing.Image.FromFile(path);


            ToolTip tp = new ToolTip();
            tp.InitialDelay = 100;
            tp.SetToolTip(report_all_excel, "Klicka för att skriva ut som excel"); 
        }

        private void report_employee_excel_Click(object sender, EventArgs e)
        {

            List<List<string>> result = new List<List<string>>();

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
            int tripTotalDays = 0; 

            int breakfasts = 0;
            int lunches = 0;
            int dinners = 0;

            int totalsum = 0;
            int totalrecieptSum = 0;
            int allTripTotalSum = 0; 

            /* Slut på variabler */

            if (lb_employee_travelList.SelectedItem.ToString().Equals("Ingen resa") || lb_employee_travelList.SelectedIndex == -1)
            {
            }
            else
            {
                // Tilldela variabler värden ifrån databasen
                int id = tripIDGhost[lb_employee_travelList.SelectedIndex];
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
                    missionStartDate = str[1].Substring(0, 10);
                    missionEndDate = str[2].Substring(0, 10);

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
                    tripStartDate = str[6].Substring(0, 10);
                    tripEndDate = str[7].Substring(0, 10);

                    breakfasts = Convert.ToInt32(str[8]);
                    lunches = Convert.ToInt32(str[9]);
                    dinners = Convert.ToInt32(str[10]);

                }

                /* Kalkyl av totalsumma */

                DateTime st = Convert.ToDateTime(tripStartDate);
                DateTime end = Convert.ToDateTime(tripEndDate);
                TimeSpan span = end - st;
                tripTotalDays = Convert.ToInt32(span.TotalDays);


                int reduceBreakfasts = 0;
                int reduceLunches = 0;
                int reduceDinners = 0;
                int prePayment = 0;

                reduceBreakfasts = breakfasts * breakfastCost;
                reduceLunches = lunches * lunchCost;
                reduceDinners = dinners * dinnerCost;
                prePayment = DataAccess.getPrePayOfTrip(id);
                totalsum = (tripTotalDays * traktamente) - reduceBreakfasts - reduceLunches - reduceDinners - prePayment;  
               
                
                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                             
                
                Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)xla.ActiveSheet;

                xla.Visible = true;

                ws.Cells[1, 1].EntireRow.Font.Bold = true;
                ws.Cells[4, 1].EntireRow.Font.Bold = true;
                ws.Cells[7, 1].EntireRow.Font.Bold = true;
                ws.Cells[10, 1].EntireRow.Font.Bold = true;
                ws.Cells[19, 1].EntireRow.Font.Bold = true;
                ws.Columns["A:D"].ColumnWidth = 20;
                ws.get_Range("A:D").Cells.HorizontalAlignment =
                 Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                ws.Cells[1, 1] = "Konsultnamn";
                ws.Cells[1, 2] = "Anställningsnummer";
                ws.Cells[1, 3] = "Epost";
                ws.Cells[1, 4] = "telefon";

                ws.Cells[2, 1] = consultName;
                ws.Cells[2, 2] = employeeNumber;
                ws.Cells[2, 3] = email;
                ws.Cells[2, 4] = phone;

                ws.Cells[4, 1] = "Uppdragsnamn";
                ws.Cells[4, 2] = "Startdatum";
                ws.Cells[4, 3] = "Slutdatum";
           

                ws.Cells[5, 1] = missionName;
                ws.Cells[5, 2] = missionStartDate;
                ws.Cells[5, 3] = missionEndDate;

                ws.Cells[7, 1] = "Land";
                ws.Cells[7, 3] = "Färdsätt";
                ws.Cells[8, 1] = land;
                ws.Cells[8, 3] = transit;


                ws.Cells[10, 1] = "Datum";
                ws.Cells[10, 3] = "Antal";
                ws.Cells[10, 4] = "Pris";
                ws.Cells[11, 1] = tripStartDate + " -- " + tripEndDate;
                ws.Cells[11, 3] = tripTotalDays;
                ws.Cells[11, 4] = traktamente;

                ws.Cells[13, 1] = "Frukostar";
                ws.Cells[15, 1] = "Luncher";
                ws.Cells[17, 1] = "Middagar";

                ws.Cells[13, 3] = breakfasts;
                ws.Cells[13, 4] = breakfastCost;
                ws.Cells[15, 3] = lunches;
                ws.Cells[15, 4] = lunchCost;
                ws.Cells[17, 3] = dinners;
                ws.Cells[17, 4] = dinnerCost;

                ws.Cells[19, 1] = "Datum";
                ws.Cells[19, 2] = "Typ";
                ws.Cells[19, 3] = "Kvittonummer";
                ws.Cells[19, 4] = "Summa";
                ws.Cells[19, 5] = "Kvitto";


                 List<List<string>> kvitton = DataAccess.getReportReceiptInformation(id);

                int row = 21;
                 foreach (List<string> str in kvitton)
                {

                    ws.Cells[row, 1] = str[0].ToString().Substring(0,10);
                    ws.Cells[row, 2] = str[1].ToString();
                    ws.Cells[row, 3] = str[2].ToString().Substring(0,11);
                    ws.Cells[row, 4] = str[3].ToString() + " " + str[4].ToString() ;
                    totalrecieptSum += Convert.ToInt32(str[3]);
                    if (str[5].ToString().Equals("0"))
                    {
                        ws.Cells[row, 5] = "Kvitto Finns";
                    }
                    else

                    {
                        ws.Cells[row, 5] = "Kvitto Finns inte";
                    }
                    row++;
                
                }

                 ws.Cells[row +1, 4] = "Totalsumma:";
                 ws.Cells[row +1, 5] = totalrecieptSum;
                 
                
            }
        
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

        private void txt_trip_vacationDays_MouseClick(object sender, MouseEventArgs e)
        {
            txt_trip_vacationDays.Text = ""; 
        }

        private void txt_trip_recieptType_MouseClick(object sender, MouseEventArgs e)
        {
            txt_trip_recieptType.Text = ""; 
        }

        private void txt_trip_recieptNumber_MouseClick(object sender, MouseEventArgs e)
        {
            txt_trip_recieptNumber.Text = ""; 
        }

        private void txt_trip_recieptAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_trip_recieptAmount.Text = ""; 
        }
        

      
    }
}
