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

        /* Returnerar en lista med alla icke-godkända resor */

        public static List<string> requestUnApprovedTrips()
        {
            List<string> returnValue = new List<string>();
            query = "select ID from Trip where Approved = 0";

            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnValue.Add(reader[0].ToString());
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

        public static int getTraktamente(string land)
        {
            int returnValue = 0;

            try 
            {
                con.Open();
                query = @"SELECT Traktamente FROM Destinations WHERE Country ='"+land+"'";

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

        public static void addTrip(string startdate, string enddate, string transit, int breakfast, int lunch, int dinner, int mission, string vacationdays, int advance, int traktamente)
        {
            try
            {
                con.Open();
                query = "INSERT into Trip (StartDate, EndDate, Transit, Breakfast, Lunch, Dinner, Mission, Break, Advance, Traktamente) VALUES ( ) ";

                using (cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.Add(new SqlParameter("StartDate", startdate));
                    cmd.Parameters.Add(new SqlParameter("EndDate", enddate));
                    cmd.Parameters.Add(new SqlParameter("Transit", transit));
                    cmd.Parameters.Add(new SqlParameter("Breakfast", breakfast));
                    cmd.Parameters.Add(new SqlParameter("Lunch", lunch));
                    cmd.Parameters.Add(new SqlParameter("Dinner", dinner));
                    cmd.Parameters.Add(new SqlParameter("Mission", mission));
                    cmd.Parameters.Add(new SqlParameter("Break", vacationdays));
                    cmd.Parameters.Add(new SqlParameter("Advance", advance));
                    cmd.Parameters.Add(new SqlParameter("Traktamente", traktamente));

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
