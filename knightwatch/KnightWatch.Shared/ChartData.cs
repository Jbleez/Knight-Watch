using System;
using System.Collections.Generic;
using System.Text;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace KnightWatch
{
    public class ChartData
    {

        public string Name { get; set; }
        public int Amount { get; set; }
        public int fanSpeed { get; set; }
        public double date { get; set; }
        public double supplyTemp { get; set; }
        public double outputTemp { get; set; }
           public double coolingDemand { get; set; }
           public double coolingInput { get; set; }
           public double superheat { get; set; }

        public ChartData(string i, int amount)
        {
            Name = i;
            Amount = amount;
        }
        public ChartData()
        {
        }
        public ChartData(int fanspeed )
        {
            this.fanSpeed = fanspeed;
        }
        public ChartData(double i, double a)
        {
            date = i;
            superheat = a;
        }


        public void  ChartDataST(int time, double s)
        {
            this.date = time;
            supplyTemp = s;
        }
        public void ChartDataOT(int time, double s)
        {
            this.date = time;
           outputTemp = s;
        }
        public void  ChartDataCD(int time, double s)
        {
            this.date = time;
            coolingDemand= s;
        }
        public void ChartDataCI(int time, double s)
        {
            this.date = time;
            coolingInput = s;
        }
        public void ChartDataSH(int time, double s)
        {
            this.date = time;
            superheat = s;
        }


 

    }
}
