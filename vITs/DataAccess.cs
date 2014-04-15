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



    }
}
