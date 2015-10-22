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
    public class PowerManagementService
    {
        public PowerManagementService()
        {

        }

        public double getCurrentFanSpeed(int fanNumber)
        {
            //fan speed is in percentage
            Double fanSpeed = 0;

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select fan_speed from Fan f where fan_number = @fan_number and entry_date = (select max(entry_date) from Fan where fan_number =@fan_number) and entry_time = (select max(entry_time) from fan f1 where f1.entry_date = f.entry_date and fan_number = @fan_number)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);
                SqlDataReader commandReader = command.ExecuteReader();
                
                while (commandReader.Read())
                {
                    fanSpeed = Double.Parse(commandReader["fan_speed"].ToString());
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();


            return fanSpeed;
        }

        
        public ArrayList getPastFanSpeed(int fanNumber, Int64 startTicks, Int64 endTicks)
        {
            //fan speed is in percentage
            Double fanSpeed = 0;

            DateTime startDate = new DateTime(startTicks);

            var start = startDate.Date;

            DateTime endDate = new DateTime(endTicks);

            var end = endDate.Date;

            ArrayList result = new ArrayList();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select fan_speed, entry_date, entry_time from Fan f where fan_number = @fan_number and entry_date between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", start);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", end);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {

                    while (commandReader.Read())
                    {
                        fanSpeed = Double.Parse(commandReader["fan_speed"].ToString());


                        String dateOnly = commandReader["entry_date"].ToString();

                        String timeOnly = commandReader["entry_time"].ToString();

                        DateTime d = DateTime.Parse(dateOnly.Substring(0,dateOnly.IndexOf(" ")) + "  " + timeOnly);
                        //result.Add(d);
                         if (DateTime.Compare(d, startDate) >= 0 && DateTime.Compare(d, endDate) <= 0)
                         {
                             result.Add(fanSpeed); 
                         }


                        
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


        public CoolingData getCurrentCoolingData(int fanNumber)
        {
            CoolingData cooling = new CoolingData();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select cool_demand, cool_output from Fan f where fan_number = @fan_number and entry_date = (select max(entry_date) from Fan where fan_number =@fan_number) and entry_time = (select max(entry_time) from fan f1 where f1.entry_date = f.entry_date and fan_number = @fan_number)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    cooling.coolDemand = Double.Parse(commandReader["cool_demand"].ToString());

                    cooling.coolOutput = Double.Parse(commandReader["cool_output"].ToString());

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            cooling.ratio = cooling.coolDemand / cooling.coolOutput;

            return cooling;
        }

        public ArrayList getPastCoolingData(int fanNumber, Int64 startTicks, Int64 endTicks)
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


                String sqlQuery = "select cool_demand, cool_output, entry_date, entry_time from Fan f where fan_number = @fan_number and entry_date between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", start);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", end);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {

                    while (commandReader.Read())
                    {
                        String dateOnly = commandReader["entry_date"].ToString();

                        String timeOnly = commandReader["entry_time"].ToString();

                        DateTime d = DateTime.Parse(dateOnly.Substring(0, dateOnly.IndexOf(" ")) + "  " + timeOnly);
                        //result.Add(d);
                        if (DateTime.Compare(d, startDate) >= 0 && DateTime.Compare(d, endDate) <= 0)
                        {

                            CoolingData cooling = new CoolingData();

                            cooling.coolDemand = Double.Parse(commandReader["cool_demand"].ToString());

                            cooling.coolOutput = Double.Parse(commandReader["cool_output"].ToString());

                            cooling.ratio = cooling.coolDemand / cooling.coolOutput;

                            result.Add(cooling);
                        }
                        

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

        public Temperatures getCurrentTemperatureData(int fanNumber)
        {
            Temperatures temp = new Temperatures();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select supply_air_temp, return_air_temp,  rack_in_temp from Fan f where fan_number = @fan_number and entry_date = (select max(entry_date) from Fan where fan_number =@fan_number) and entry_time = (select max(entry_time) from fan f1 where f1.entry_date = f.entry_date and fan_number = @fan_number)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    temp.supplyAirTemp = Double.Parse(commandReader["supply_air_temp"].ToString());

                    temp.returnAirTemp = Double.Parse(commandReader["return_air_temp"].ToString());

                    temp.rackInTemp = Double.Parse(commandReader["rack_in_temp"].ToString());

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return temp;
        }

        public ArrayList getPastTemperatureData(int fanNumber, Int64 startTicks, Int64 endTicks)
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


                String sqlQuery = "select supply_air_temp, return_air_temp,  rack_in_temp, entry_date, entry_time from Fan f where fan_number = @fan_number and entry_date between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter fanNumb = command.Parameters.AddWithValue("@fan_number", fanNumber);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", start);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", end);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {

                    while (commandReader.Read())
                    {
                        String dateOnly = commandReader["entry_date"].ToString();

                        String timeOnly = commandReader["entry_time"].ToString();

                        DateTime d = DateTime.Parse(dateOnly.Substring(0, dateOnly.IndexOf(" ")) + "  " + timeOnly);

                        if (DateTime.Compare(d, startDate) >= 0 && DateTime.Compare(d, endDate) <= 0)
                        {
                            Temperatures temp = new Temperatures();

                            temp.supplyAirTemp = Double.Parse(commandReader["supply_air_temp"].ToString());

                            temp.returnAirTemp = Double.Parse(commandReader["return_air_temp"].ToString());

                            temp.rackInTemp = Double.Parse(commandReader["rack_in_temp"].ToString());

                            result.Add(temp);
                        }
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

        public PDU getCurrentPDUData()
        {
            PDU pdu = new PDU();

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select module1_load1, module1_load2, module1_load3, module2_load1, module2_load2, module2_load3, "+
                                    "module3_load1, module3_load2, module3_load3, module4_load1, module4_load2, module4_load3, " +
                                    "module5_load1, module5_load2, module5_load3, module6_load1, module6_load2, module6_load3 from PDU p where entry_date = (select max(entry_date) from PDU) and entry_time = (select max(entry_time) from PDU p1 where p1.entry_date = p.entry_date)";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    pdu.module1load1 = Double.Parse(commandReader["module1_load1"].ToString());

                    pdu.module1load2 = Double.Parse(commandReader["module1_load2"].ToString());

                    pdu.module1load3 = Double.Parse(commandReader["module1_load3"].ToString());

                    pdu.module2load1 = Double.Parse(commandReader["module2_load1"].ToString());

                    pdu.module2load2 = Double.Parse(commandReader["module2_load2"].ToString());

                    pdu.module2load3 = Double.Parse(commandReader["module2_load3"].ToString());

                    pdu.module3load1 = Double.Parse(commandReader["module3_load1"].ToString());

                    pdu.module3load2 = Double.Parse(commandReader["module3_load2"].ToString());

                    pdu.module3load3 = Double.Parse(commandReader["module3_load3"].ToString());

                    pdu.module4load1 = Double.Parse(commandReader["module4_load1"].ToString());

                    pdu.module4load2 = Double.Parse(commandReader["module4_load2"].ToString());

                    pdu.module4load3 = Double.Parse(commandReader["module4_load3"].ToString());

                    pdu.module5load1 = Double.Parse(commandReader["module5_load1"].ToString());

                    pdu.module5load2 = Double.Parse(commandReader["module5_load2"].ToString());

                    pdu.module5load3 = Double.Parse(commandReader["module5_load3"].ToString());

                    pdu.module6load1 = Double.Parse(commandReader["module6_load1"].ToString());

                    pdu.module6load2 = Double.Parse(commandReader["module6_load2"].ToString());

                    pdu.module6load3 = Double.Parse(commandReader["module6_load3"].ToString());
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return pdu;
        }

        public ArrayList getPastPDUData(Int64 startTicks, Int64 endTicks)
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


                String sqlQuery = "select module1_load1, module1_load2, module1_load3, module2_load1, module2_load2, module2_load3, " +
                                    "module3_load1, module3_load2, module3_load3, module4_load1, module4_load2, module4_load3, " +
                                    "module5_load1, module5_load2, module5_load3, module6_load1, module6_load2, module6_load3, entry_date, entry_time from PDU p where entry_date between @startDate and @endDate";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", start);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", end);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {

                    while (commandReader.Read())
                    {
                        String dateOnly = commandReader["entry_date"].ToString();

                        String timeOnly = commandReader["entry_time"].ToString();

                        DateTime d = DateTime.Parse(dateOnly.Substring(0, dateOnly.IndexOf(" ")) + "  " + timeOnly);

                        if (DateTime.Compare(d, startDate) >= 0 && DateTime.Compare(d, endDate) <= 0)
                        {

                            PDU pdu = new PDU();

                            pdu.module1load1 = Double.Parse(commandReader["module1_load1"].ToString());

                            pdu.module1load2 = Double.Parse(commandReader["module1_load2"].ToString());

                            pdu.module1load3 = Double.Parse(commandReader["module1_load3"].ToString());

                            pdu.module2load1 = Double.Parse(commandReader["module2_load1"].ToString());

                            pdu.module2load2 = Double.Parse(commandReader["module2_load2"].ToString());

                            pdu.module2load3 = Double.Parse(commandReader["module2_load3"].ToString());

                            pdu.module3load1 = Double.Parse(commandReader["module3_load1"].ToString());

                            pdu.module3load2 = Double.Parse(commandReader["module3_load2"].ToString());

                            pdu.module3load3 = Double.Parse(commandReader["module3_load3"].ToString());

                            pdu.module4load1 = Double.Parse(commandReader["module4_load1"].ToString());

                            pdu.module4load2 = Double.Parse(commandReader["module4_load2"].ToString());

                            pdu.module4load3 = Double.Parse(commandReader["module4_load3"].ToString());

                            pdu.module5load1 = Double.Parse(commandReader["module5_load1"].ToString());

                            pdu.module5load2 = Double.Parse(commandReader["module5_load2"].ToString());

                            pdu.module5load3 = Double.Parse(commandReader["module5_load3"].ToString());

                            pdu.module6load1 = Double.Parse(commandReader["module6_load1"].ToString());

                            pdu.module6load2 = Double.Parse(commandReader["module6_load2"].ToString());

                            pdu.module6load3 = Double.Parse(commandReader["module6_load3"].ToString());

                            result.Add(pdu);
                        }
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


        public PowerStrip getCurrentPowerstripData(int powerstripNumber)
        {
            PowerStrip powerStrip = new PowerStrip();
           
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["KnightWatchDBConnection"].ConnectionString;

                conn.ConnectionString = connectionString;

                conn.Open();


                String sqlQuery = "select power_kw, max_power_kw, energy_kwh from powerstrip p where powerstrip_number = @powerstripnumber and  entry_date = (select max(entry_date) from powerstrip where powerstrip_number = @powerstripnumber) and entry_time = (select max(entry_time) from powerstrip p1 where p1.entry_date = p.entry_date and powerstrip_number = @powerstripnumber)";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter powerstripNumb = command.Parameters.AddWithValue("@powerstripnumber", powerstripNumber);

                SqlDataReader commandReader = command.ExecuteReader();

                while (commandReader.Read())
                {
                    powerStrip.power = Double.Parse(commandReader["power_kw"].ToString());

                    powerStrip.max_power = Double.Parse(commandReader["max_power_kw"].ToString());

                    powerStrip.energy = Double.Parse(commandReader["energy_kwh"].ToString());

                    
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            conn.Close();

            return powerStrip;

        }

        public ArrayList getPastPowerstripData(int powerstripNumber, Int64 startTicks, Int64 endTicks)
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


                String sqlQuery = "select power_kw, max_power_kw, energy_kwh, entry_date, entry_time from powerstrip p where powerstrip_number = @powerstripnumber and  entry_date between @startDate and @endDate";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                SqlParameter powerstripNumb = command.Parameters.AddWithValue("@powerstripnumber", powerstripNumber);

                SqlParameter start_d = command.Parameters.AddWithValue("@startDate", start);

                SqlParameter end_d = command.Parameters.AddWithValue("@endDate", end);

                using (SqlDataReader commandReader = command.ExecuteReader())
                {

                    while (commandReader.Read())
                    {
                        String dateOnly = commandReader["entry_date"].ToString();

                        String timeOnly = commandReader["entry_time"].ToString();

                        DateTime d = DateTime.Parse(dateOnly.Substring(0, dateOnly.IndexOf(" ")) + "  " + timeOnly);

                        if (DateTime.Compare(d, startDate) >= 0 && DateTime.Compare(d, endDate) <= 0)
                        {

                            PowerStrip powerStrip = new PowerStrip();

                            powerStrip.power = Double.Parse(commandReader["power_kw"].ToString());

                            powerStrip.max_power = Double.Parse(commandReader["max_power_kw"].ToString());

                            powerStrip.energy = Double.Parse(commandReader["energy_kwh"].ToString());

                            result.Add(powerStrip);
                        }

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
    }
}