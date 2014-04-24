using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 
using System.Windows.Forms; 

namespace vITs
{
    public static class DataAccess
    {
        private static string connString = @"Data Source=fwxy0mr0y4.database.windows.net;Initial Catalog=vITs;Persist Security Info=True;User ID=vits-team@fwxy0mr0y4;Password=Hatakka1337";
        private static SqlConnection con = new SqlConnection(connString); 
        private static SqlCommand cmd;
        private static string query;
        public static List<List<string>> gettimespanusermissions(int userid)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Missions.MissionName as MName, Missions.StartDate as MStartDate, Missions.EndDate as MEndDate from Missions, Trip where Trip.Mission=Missions.id and trip.StaffID = '"+userid+"'";

                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["MName"].ToString());
                    miniList.Add(rdr["MStartDate"].ToString());
                    miniList.Add(rdr["MEndDate"].ToString());
               


                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        public static List<List<string>> gettimespanuserinformation(int userid)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Staff.FirstName as FName, Staff.LastName as LName, Staff.ID as StaffID, Staff.Email as Staffmail, Staff.Phone as Staffphone from Staff where Staff.ID = '"+ userid+"'";
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["FName"].ToString());
                    miniList.Add(rdr["LName"].ToString());
                    miniList.Add(rdr["StaffID"].ToString());
                    miniList.Add(rdr["Staffmail"].ToString());
                    miniList.Add(rdr["Staffphone"].ToString());
                  

                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        public static List<List<string>> getReportReceiptInformation(int tripID)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Receipts.Date as Date, Receipts.Type as Type, Receipts.Number as Number, Receipts.Sum as Sum, Receipts.Currency as Curr, Receipts.Exist as Exist from Receipts where TripID =" + tripID; 
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["Date"].ToString());
                    miniList.Add(rdr["Type"].ToString());
                    miniList.Add(rdr["Number"].ToString());
                    miniList.Add(rdr["Sum"].ToString());
                    miniList.Add(rdr["Curr"].ToString());
                    miniList.Add(rdr["Exist"].ToString());

                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        public static List<List<string>> getReportDestinationInformation(int tripID)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Destinations.Country as Land, Destinations.Traktamente as Trakt, Destinations.Breakfast as BFCost, Destinations.Lunch as LunchCost, Destinations.Dinner as DinnerCost, Trip.Transit as Transit, Trip.StartDate as StartDate, Trip.EndDate as EndDate, Trip.AmountOfBreakfasts as BF, Trip.AmountOfLunches as Lunch, Trip.AmountOfDinners as Dinners from Trip join Destinations on Trip.Destination = Destinations.ID where Trip.ID =" + tripID + ""; 
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["Land"].ToString());
                    miniList.Add(rdr["Trakt"].ToString());
                    miniList.Add(rdr["BFCost"].ToString());
                    miniList.Add(rdr["LunchCost"].ToString());
                    miniList.Add(rdr["DinnerCost"].ToString());
                    
                    miniList.Add(rdr["Transit"].ToString());
                    miniList.Add(rdr["StartDate"].ToString());
                    miniList.Add(rdr["EndDate"].ToString());
                    miniList.Add(rdr["BF"].ToString());
                    miniList.Add(rdr["Lunch"].ToString());
                    miniList.Add(rdr["Dinners"].ToString());


                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message); 
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        public static List<List<string>> getReportMissionInformation(int tripID)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Missions.MissionName as MName, Missions.StartDate as MStartDate, Missions.EndDate as MEndDate from Missions, Trip where Missions.ID = (Select Trip.Mission where Trip.ID = "+ tripID +")"; 
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["MName"].ToString());
                    miniList.Add(rdr["MStartDate"].ToString());
                    miniList.Add(rdr["MEndDate"].ToString());


                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }


        public static List<List<string>> getReportEmployeeInformation(int tripID)
        {

            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Staff.FirstName as FName, Staff.LastName as LName, Staff.ID as StaffID, Staff.Email as Staffmail, Staff.Phone as Staffphone from Staff where Staff.ID = (Select StaffID from Trip where Trip.ID =" + tripID + ")"; 
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["Fname"].ToString());
                    miniList.Add(rdr["LName"].ToString());
                    miniList.Add(rdr["StaffID"].ToString());
                    miniList.Add(rdr["Staffmail"].ToString());
                    miniList.Add(rdr["Staffphone"].ToString());


                    returnValue.Add(miniList);
                }


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        public static List<List<string>> getEmployeeTrips(int userID)
        {
            
            List<List<string>> returnValue = new List<List<string>>();

            try
            {
                con.Open();
                query = "Select Trip.ID, Destinations.Country, Trip.StartDate + ' -- ' + Trip.EndDate as Dates from Destinations join Trip on Destinations.ID = Trip.Destination where Destinations.ID in (SELECT Destination from Trip WHERE StaffID = "+ userID +")";
                cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    List<string> miniList = new List<string>();

                    miniList.Add(rdr["ID"].ToString()); 
                    miniList.Add(rdr["Country"].ToString()); 
                    miniList.Add(rdr["Dates"].ToString());
                   

                    returnValue.Add(miniList); 
                }


            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }

        /* Skicka tillbaka ID:t för senast tillagda resan. */

        public static int getIdentityOfLastTrip()
        {
            int returnValue = 999; 

            try
            {
                con.Open();
                query = "SELECT top 1 ID FROM Trip ORDER BY ID DESC";
                returnValue = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {


            }
            finally
            {
                con.Close(); 
            }

            return returnValue;
        }

        /* Lägger till ett kvitto till en specifik resa. Tar en lista som parameter och aktuellt ID för vald resa. */

        public static void addReceipt(List<Receipt> receiptList, int id)
        {

            try
            {
                con.Open();

                foreach (Receipt re in receiptList)
                {
                    query = "INSERT into Receipts (Date, Type, Number, Sum, Currency, TripID, Exist) VALUES ('"+ re.date +"', '"+ re.type +"', '"+ re.number +"', "+ re.sum +", '"+ re.currency +"', "+ id +", "+ re.recieptExist +")";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery(); 
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString()); 
            }
            finally
            {
                con.Close();

            }



        }

        


        public static string requestFullName(int userID)
        {
            string returnValue = null; 
            query = "SELECT FirstName +' '+ LastName as Name FROM Staff where ID ="+ userID +""; 
            
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                returnValue = cmd.ExecuteScalar().ToString(); 

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            finally
            {
                con.Close(); 
            }

            return returnValue; 

        }

        public static int requestStaffLevel(int userID)
        {
            int returnValue = 999; 
            query = @"SELECT Level from Staff WHERE ID = "+ userID +""; 
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                returnValue = (int)cmd.ExecuteScalar(); 

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message.ToString()); 
            }
            finally
            {
                con.Close(); 
            }

            return returnValue; 

        }

        public static int validateUserLogIn(int userID, string password)
        {
            int returnValue = 999;
            cmd = new SqlCommand("ValidateUser", con); 

            try
            {
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new[] 
                {
                    new SqlParameter("@ID", userID),
                    new SqlParameter("@Password", password) 
                });

                returnValue = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }

            return returnValue; 

        }


        /* Godkänner en icke-godkänd resa. Tar trip-id som parameter. */

        public static void approveOfTrip(string tripId)
        {
            try
            {
                con.Open();

                query = "update Trip set Approved = 1 where ID = " + tripId;
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();

            }
        }


        /* Nekar en icke-godkänd resa. Tar trip-id som parameter. */

        public static void denyTrip(string tripId)
        {
            try
            {
                con.Open();

                query = "update Trip set Approved = 2 where ID = " + tripId;
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();

            }
        }


        /*Fyll länderlista*/
        public static List<string> FillCountryList()
        {
            List<string> countryList = new List<string>();

            try
            {
                con.Open();

                query = "SELECT Country FROM Destinations";
                cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        countryList.Add(reader[0].ToString());
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
            return countryList;
        }


        /*Fyll uppdragslista*/
        public static List<string> FillQuestList()
        {
            List<string> questList = new List<string>();

            try
            {
                con.Open();

                query = "SELECT MissionName FROM Missions";
                cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questList.Add(reader[0].ToString());
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
            return questList;
        }



        /*Hämta ID för uppdrag*/
        public static int getMissionID(string mission)
        {
            int missionID = 0;

            try
            {
                con.Open();

                query = "SELECT ID FROM Missions WHere MissionName = '" + mission + "'";
                cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        missionID = int.Parse(reader[0].ToString());
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
            return missionID;
        }

        /*Hämta Destination ID*/
        public static int getDestinationID(string destination)
        {
            int destinationID = 0;

            try
            {
                con.Open();

                query = "SELECT ID FROM Destinations WHere Country = '" + destination + "'";
                cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        destinationID = int.Parse(reader[0].ToString());
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
            return destinationID;
        }




        public static int getTraktamente(string land)
        {
            int returnValue = 0;

            try
            {
                con.Open();
                query = @"SELECT Traktamente FROM Destinations WHERE Country ='" + land + "'";

                cmd = new SqlCommand(query, con);

                returnValue = (int)cmd.ExecuteScalar();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }

            return returnValue;
        }


        /*Lägger till en resa*/
        public static void addTrip(int destination, string startdate, string enddate, string transit, int mission, int breakfast, int lunch, int dinner, int vacationdays, int id)
        {
            try
            {
                con.Open();
                query = "INSERT into Trip (Destination, StartDate, EndDate, Transit, Mission, [Break], StaffID, AmountOfBreakfasts, AmountOfLunches, AmountOfDinners) VALUES (@Destination, @StartDate, @EndDate, @Transit, @Mission, @Break, @StaffID, @AmountOfBreakfasts, @AmountOfLunches, @AmountOfDinners) ";

                using (cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.Add(new SqlParameter("StartDate", startdate));
                    cmd.Parameters.Add(new SqlParameter("EndDate", enddate));
                    cmd.Parameters.Add(new SqlParameter("Transit", transit));
                    cmd.Parameters.Add(new SqlParameter("Destination", destination));
                    cmd.Parameters.Add(new SqlParameter("AmountOfBreakfasts", breakfast));
                    cmd.Parameters.Add(new SqlParameter("AmountOfLunches", lunch));
                    cmd.Parameters.Add(new SqlParameter("AmountOfDinners", dinner));
                    cmd.Parameters.Add(new SqlParameter("Mission", mission));
                    cmd.Parameters.Add(new SqlParameter("Break", vacationdays));
                    cmd.Parameters.Add(new SqlParameter("StaffID", id));


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }


        /*Lägger till ett uppdrag*/

        public static void addMission(string missionName, string description, string startdate, string enddate, int costcenter)
        {
            try
            {
                con.Open();
                query = "Insert into Missions (MissionName, Description, StartDate, EndDate, costcenter) VALUES (@MissionName, @Description, @StartDate, @EndDate, @costcenter)";


                using (cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.Add(new SqlParameter("MissionName", missionName));
                    cmd.Parameters.Add(new SqlParameter("Description", description));
                    cmd.Parameters.Add(new SqlParameter("StartDate", startdate));
                    cmd.Parameters.Add(new SqlParameter("EndDate", enddate));
                    cmd.Parameters.Add(new SqlParameter("costcenter", costcenter));

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }
  
        /*Hämtar uppdragsinformation*/

        public static List<string[]> getMissionDetails()
        {
            List<string[]> returnValue = new List<string[]>();
            query = "Select * From Missions";
           
            try
            {
                con.Open();
                

                cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] arr = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()};

                        returnValue.Add(arr);
                    }
                }
               
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }

            return returnValue;
        }

        /*Redigerar uppdrag*/

        public static void updateMission()
        {

        }

        /* Hämta alla icke godkända resor */

        public static List<string[]> getTrips()
        {
            List<string[]> returnValue = new List<string[]>();
            query = "SELECT * FROM Trip WHERE Approved <> 1";

            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /* ID, Destination, StartDate, EndDate, Transit, Mission, Break, StaffID, AmmountOfBreakfast, AmmountOfLunches, AmmountOfDinners, Approved */

                        string[] arr = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString() };

                        returnValue.Add(arr);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }


        /* Returnerar en lista med alla icke-godkända förskottsbetalningars resor. */

        public static List<string[]> requestUnApprovedPrePays()
        {
            List<string[]> returnValue = new List<string[]>();
            query = "SELECT Trip.ID,PrePay.Advance,Missions.[Description],Missions.MissionName FROM Trip INNER JOIN PrePay ON Trip.ID = PrePay.TripID INNER JOIN Missions ON Missions.ID = Trip.Mission WHERE PrePay.Approved = 0;";

            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /* TripID, Förskott, Uppdragsbeskrivning */

                        string[] arr = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };

                        returnValue.Add(arr);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }


        /* Godkänner en icke-godkänd förskottsbetalning. Tar trip-id som parameter. */

        public static void approveOfPrePay(string tripId)
        {
            try
            {
                con.Open();

                query = "update PrePay set Approved = 1 where TripID = " + tripId;
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();

            }
        }


        /* Nekar en oförändrad förskottsbetalning. Tar trip-id som parameter. */

        public static void denyPrePay(string tripId)
        {
            try
            {
                con.Open();

                query = "update PrePay set Approved = 2 where TripID = " + tripId;
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();

            }
        }


        /* Returnerar en lista med alla användare. */

        public static List<string[]> requestUserList()
        {
            List<string[]> returnValue = new List<string[]>();
            query = "SELECT * FROM Staff";

            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] arr = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString() };

                        returnValue.Add(arr);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

            return returnValue;
        }


        /* Uppdatera en användares data */

        public static void updateUser(int userID, string firstname, string lastname, string phone, string email, string address, string password, string birthdate)
        {

            try
            {
                con.Open();
                query = "update Staff set FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email, [Address] = @Address, [Password] = @Password, Birthdate = @Birthdate where ID = " + userID;
                
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("FirstName", firstname));
                    cmd.Parameters.Add(new SqlParameter("LastName", lastname));
                    cmd.Parameters.Add(new SqlParameter("Phone", phone));
                    cmd.Parameters.Add(new SqlParameter("Email", email));
                    cmd.Parameters.Add(new SqlParameter("Address", address));
                    cmd.Parameters.Add(new SqlParameter("Password", password));
                    cmd.Parameters.Add(new SqlParameter("Birthdate", birthdate));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }


        /* Lägg till en ny användare */

        public static void createUser(string firstname, string lastname, int level, string phone, string email, string address, string password, string birthdate)
        {
            try
            {
                con.Open();
                query = "insert into Staff (FirstName, LastName, [Level], Phone, Email, [Address], [Password], Birthdate) values (@FirstName, @LastName, @Level, @Phone, @Email, @Address, @Password, @Birthdate)";

                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("FirstName", firstname));
                    cmd.Parameters.Add(new SqlParameter("LastName", lastname));
                    cmd.Parameters.Add(new SqlParameter("Level", level));
                    cmd.Parameters.Add(new SqlParameter("Phone", phone));
                    cmd.Parameters.Add(new SqlParameter("Email", email));
                    cmd.Parameters.Add(new SqlParameter("Address", address));
                    cmd.Parameters.Add(new SqlParameter("Password", password));
                    cmd.Parameters.Add(new SqlParameter("Birthdate", birthdate));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }


        /* Ta bort vald användare */

        public static void deleteUser(int userID)
        {
            try
            {
                con.Open();
                query = "delete from Staff where ID = " + userID;

                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }


        /* Testa om databaskopplingen fungerar. */

        public static void dbTest()
        {
            try
            {
                con.Open();
                MessageBox.Show("Databaskopplingen fungerar.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            finally
            {
                con.Close();
            }
        }



    }
}
