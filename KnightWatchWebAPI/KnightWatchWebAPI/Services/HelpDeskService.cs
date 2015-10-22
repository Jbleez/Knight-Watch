using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using KnightWatchWebAPI.Models;
using System.Web.Http;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace KnightWatchWebAPI.Services
{
    public class HelpDeskService
    {
        
        public HelpDeskService()
        {

        }


        public ArrayList getNumberOfTicketsByCurrentPriority()
        {
           
            ArrayList result = new ArrayList();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                //heskEventLog.WriteEntry("Successful log to Hesk Module - local Sql Server DB");

                string sqlQuery = "select ticket_priority from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);


                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {
                    
                    while (commandReader.Read())
                    {
                        
                        result.Add(commandReader["ticket_priority"]);
                        
                    }
                }


            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            
            return result;

        }


        public bool getCriticalNotification()
        {


            bool notification = false;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

               
                string sqlQuery = "select ticket_status, ticket_prority from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {
                    

                    while (commandReader.Read())
                    {
                        if (commandReader.GetInt32(0) == 0 && commandReader.GetInt32(1) == 0)
                        {
                            notification = true;
                            break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            

            return notification;
        }


        public ArrayList getNumberOfTicketsByCurrentStatus(){


            ArrayList result = new ArrayList();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select ticket_status from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_status"]);

                    }
                }

            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            
            return result;
        }


        public ArrayList getNumberOfTicketsByCurrentCategory()
        {
            ArrayList result = new ArrayList();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select ticket_category from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_category"]);

                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            
            return result;
        }

        public int getNumberOfTicketsPerCurrentStatusPerCurrentPriority(int status, int priority)
        {
            int result = 0;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_status=" + status + " and ticket_priority =" + priority +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
              
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            
            return result;
        }

        public int getNumberOfTicketsPerCurrentCategoryPerCurrentPriority(int category, int priority)
        {
            int result = 0;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category=" + category + " and ticket_priority =" + priority +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            //heskEventLog.WriteEntry("Closing connection to Hesk Module - local SQL SERVER DB");
            return result;
        }

        public int getNumberOfTicketsPerCurrentCategoryPerCurrentStatus(int category, int status)
        {
            int result = 0;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            try
            {
               
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                //heskEventLog.WriteEntry("Successful log to Hesk Module - local Sql Server DB");

                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category=" + category + " and ticket_status =" + status +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            
            return result;
        }

        public int getNumberOfTicketsPerCurrentCategoryPerCurrentPriorityPerStatus(int category, int priority, int status)
        {
            int result=0;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category=" + category + " and ticket_priority =" + priority +
                    " and ticket_status =" + status + "and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            conn.Close();
           
            return result;
        }


        public ArrayList getNumberOfTicketsByPastCategory(Int64 startTicks, Int64 endTicks)
        {
            ArrayList result = new ArrayList();

            DateTime startDate = new DateTime(startTicks);

            var start = startDate.Date;

            DateTime endDate = new DateTime(endTicks);

            var end = endDate.Date;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select ticket_category from ticket_state ts where date_of_change between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", startDate);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", endDate);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_category"]);

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;
        }

        public ArrayList getNumberOfTicketsByPastPriority(Int64 startTicks, Int64 endTicks)
        {

            ArrayList result = new ArrayList();

            DateTime startDate = new DateTime(startTicks);

            var start = startDate.Date;

            DateTime endDate = new DateTime(endTicks);

            var end = endDate.Date;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                //heskEventLog.WriteEntry("Successful log to Hesk Module - local Sql Server DB");

                string sqlQuery = "select ticket_priority from ticket_state ts where date_of_change between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", startDate);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", endDate);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_priority"]);

                    }
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;

        }

        public ArrayList getNumberOfTicketsByPastStatus(Int64 startTicks, Int64 endTicks)
        {


            ArrayList result = new ArrayList();

            DateTime startDate = new DateTime(startTicks);

            var start = startDate.Date;

            DateTime endDate = new DateTime(endTicks);

            var end = endDate.Date;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select ticket_status from ticket_state ts where date_of_change between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", startDate);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", endDate);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_status"]);

                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return result;
        }

        public ArrayList getNumberOfTicketsByPriorityBeforeDate(Int64 Ticks)
        {

            ArrayList result = new ArrayList();

            DateTime date = new DateTime(Ticks);


            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                //heskEventLog.WriteEntry("Successful log to Hesk Module - local Sql Server DB");

                string sqlQuery = "select ticket_priority from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_priority"]);

                    }
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;

        }


        public ArrayList getNumberOfTicketsByStatusBeforeDate(Int64 markTicks)
        {


            ArrayList result = new ArrayList();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            DateTime date = new DateTime(markTicks);
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select ticket_status from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_status"]);

                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return result;
        }


        public ArrayList getNumberOfTicketsByCategoryBeforeDate(Int64 markTicks)
        {
            ArrayList result = new ArrayList();

            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select ticket_category from ticket_state ts where date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        result.Add(commandReader["ticket_category"]);

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;
        }

        public int getNumberOfTicketsPerStatusPerPriorityBeforeDate(int status, int priority, Int64 markTicks)
        {
            int result = 0;
            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_status=" + status + " and ticket_priority =" + priority +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return result;
        }

        public int getNumberOfTicketsPerCategoryPerPriorityBeforeDate(int category, int priority, Int64 markTicks)
        {
            int result = 0;
            DateTime date = new DateTime(markTicks);
            
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category= " + category + " and ticket_priority = " + priority +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();
            //heskEventLog.WriteEntry("Closing connection to Hesk Module - local SQL SERVER DB");
            return result;
        }

        public int getNumberOfTicketsPerCategoryPerStatusBeforeDate(int category, int status, Int64 markTicks)
        {
            int result = 0;

            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                //heskEventLog.WriteEntry("Successful log to Hesk Module - local Sql Server DB");

                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category=" + category + " and ticket_status =" + status +
                    " and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;
        }

        public int getNumberOfTicketsPerCategoryPerPriorityPerStatusBeforeDate(int category, int priority, int status, Int64 markTicks)
        {
            int result = 0;

            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                string sqlQuery = "select count(state_id) as numberOfT from ticket_state ts where ticket_category=" + category + " and ticket_priority =" + priority +
                    " and ticket_status =" + status + "and date_of_change = (select last_change_date from ticket t where t.reference_ticket_id = ts.ticket_id) and date_of_change < @markDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                SqlDataReader commandReader = command.ExecuteReader();

              
                while (commandReader.Read())
                {
                    result = commandReader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return result;
        }
    }

}