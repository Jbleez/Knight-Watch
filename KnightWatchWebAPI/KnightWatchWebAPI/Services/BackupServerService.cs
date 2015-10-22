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
    public class BackupServerService
    {
        public BackupServerService()
        {

        }

        public BackupServer getCurrentBackupServerData()
        {
            BackupServer backup = new BackupServer();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select server, drive, file_system, space_bytes, freespace_bytes from [backup] where [date] = (select max([date]) from [backup])";

                SqlCommand command = new SqlCommand(sqlQuery, conn);


                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        backup.serverIP = commandReader["server"].ToString();
                        backup.drive = commandReader["drive"].ToString();
                        backup.fileSystem = commandReader["file_system"].ToString();
                        backup.totalSpace = Int64.Parse(commandReader["space_bytes"].ToString());
                        backup.freeSpace = Int64.Parse(commandReader["freespace_bytes"].ToString());
                    }
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return backup;
        }

        public BackupServer getBackupServerDataBeforeDate(Int64 markTicks)
        {
            BackupServer backup = new BackupServer();

            DateTime date = new DateTime(markTicks);

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();

                string sqlQuery = "select server, drive, file_system, space_bytes, freespace_bytes from [backup] where [date] = (select max([date]) from [backup] where date < @markDate) ";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter mark_d = command.Parameters.AddWithValue("@markDate", date);

                using (SqlDataReader commandReader = command.ExecuteReader()) //enables reading multiple db rows in the result set
                {

                    while (commandReader.Read())
                    {

                        backup.serverIP = commandReader["server"].ToString();
                        backup.drive = commandReader["drive"].ToString();
                        backup.fileSystem = commandReader["file_system"].ToString();
                        backup.totalSpace = Int64.Parse(commandReader["space_bytes"].ToString());
                        backup.freeSpace = Int64.Parse(commandReader["freespace_bytes"].ToString());
                    }
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();

            return backup;
        }
    }
}