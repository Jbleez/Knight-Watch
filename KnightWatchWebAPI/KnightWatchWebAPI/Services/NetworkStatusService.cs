using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using KnightWatchWebAPI.Models;
using System.Configuration;
using System.Collections;

namespace KnightWatchWebAPI.Services
{
    public class NetworkStatusService
    {
        public NetworkStatusService()
        {

        }

        public NetworkStatus getCurrentNetworkStatus(String serverIp)
        {
            NetworkStatus ns = new NetworkStatus();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select server_IP_address, status from Network_Status where server_IP_address = @ip and date_of_entry = (select max(date_of_entry) from Network_Status where server_IP_address = @ip)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter ip = command.Parameters.AddWithValue("@ip", serverIp);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        ns.serverIP = commandReader["server_IP_address"].ToString();
                        ns.status = commandReader["status"].ToString();
                        
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return ns;
        }

        public NetworkStatus getNetworkStatusBeforeDate(String serverIp, Int64 markTicks)
        {
            NetworkStatus ns = new NetworkStatus();

            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select server_IP_address, status from Network_Status where server_IP_address = @ip and date_of_entry = (select max(date_of_entry) from Network_Status where server_IP_address = @ip and date_of_entry < @markDate)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter ip = command.Parameters.AddWithValue("@ip", serverIp);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        ns.serverIP = commandReader["server_IP_address"].ToString();
                        ns.status = commandReader["status"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return ns;
        }
    }
}