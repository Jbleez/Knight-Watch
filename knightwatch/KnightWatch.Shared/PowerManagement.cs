using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KnightWatch
{

    class PowerManagement
    {
        PDUData pdu = new PDUData();

        public PowerManagement()
        {
            pdu.read(1000);
        }

        public PDUData GetCurrentPDUData()
        {
            return pdu;
        }

    }

    class Fan
    {
        FanSpeed fanSpeed;
        FanCooling fanCooling;
        FanTemp fanTemp;

        public Fan(int number)
        {
            this.fanSpeed = new FanSpeed(number, 2000);
            this.fanCooling = new FanCooling(number, 2000);
            this.fanTemp = new FanTemp(number, 2000);
        }

        public FanSpeed getSpeed()
        {
            return fanSpeed;
        }
        public FanCooling getCooling()
        {
            return fanCooling;
        }
        public FanTemp getTemp()
        {
            return fanTemp;
        }

    }

    [DataContract]
    internal class FanSpeed : JSONReader
    {

        [DataMember]
        public double speed { set { this._speed = value; this.initialized = true; } get { return this._speed; } }
        private double _speed = 0.0;

        public bool initialized = false;

        int fanNumber = 0;

        public FanSpeed(int number, int refresh = 10000)
        {
            this.fanNumber = number;
            this.read(refresh);
        }

        override public string webURI()
        {
            return "api/PowerManagement/GetCurrentFanSpeed?fanNumber=" + this.fanNumber;
        }
        override public string dummyReply()
        {
            return "1";
        }
        override public void parse(string reply)
        {
            this.speed = Convert.ToDouble(reply);
        }

    }

    [DataContract]
    internal class FanCooling : JSONReader
    {

        [DataMember]
        public double coolDemand { set { this._coolDemand = value; this.initialized = true; } get { return this._coolDemand; } }
        private double _coolDemand = 0.0;

        [DataMember]
        public double coolOutput { set { this._coolOutput = value; this.initialized = true; } get { return this._coolOutput; } }
        private double _coolOutput = 0.0;

        [DataMember]
        public double ratio { set { this._ratio = value; this.initialized = true; } get { return this._ratio; } }
        private double _ratio = 0.0;

        public bool initialized = false;

        int fanNumber = 0;

        public FanCooling(int number, int refresh = 10000)
        {
            this.fanNumber = number;
            this.read(refresh);
        }

        override public string webURI()
        {
            return "api/PowerManagement/GetCurrentCoolingData?fanNumber=" + this.fanNumber;
        }
        override public string dummyReply()
        {
            return "{}";
        }
        override public void parse(string reply)
        {
            FanCooling temp = new FanCooling(this.fanNumber);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FanCooling));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (FanCooling)ser.ReadObject(stream1);

            this.coolDemand = temp.coolDemand;
            this.ratio = temp.ratio;
            this.coolOutput = temp.coolOutput;
        }

    }

    [DataContract]
    internal class FanTemp : JSONReader
    {

        [DataMember]
        public double supplyAirTemp { set { this._supplyAirTemp = value; this.initialized = true; } get { return this._supplyAirTemp; } }
        private double _supplyAirTemp = 0.0;

        [DataMember]
        public double returnAirTemp { set { this._returnAirTemp = value; this.initialized = true; } get { return this._returnAirTemp; } }
        private double _returnAirTemp = 0.0;

        [DataMember]
        public double rackInTemp { set { this._rackInTemp = value; this.initialized = true; } get { return this._rackInTemp; } }
        private double _rackInTemp = 0.0;

        public bool initialized = false;

        int fanNumber = 0;

        public FanTemp(int number, int refresh = 10000)
        {
            this.fanNumber = number;
            this.read(refresh);
        }

        override public string webURI()
        {
            return "api/PowerManagement/GetCurrentTemperatureData?fanNumber=" + this.fanNumber;
        }
        override public string dummyReply()
        {
            return "{}";
        }
        override public void parse(string reply)
        {
            FanTemp temp = new FanTemp(this.fanNumber);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FanTemp));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (FanTemp)ser.ReadObject(stream1);

            this.supplyAirTemp = temp.supplyAirTemp;
            this.returnAirTemp = temp.returnAirTemp;
            this.rackInTemp = temp.rackInTemp;
        }

    }

    [DataContract]
    internal class PDUData : JSONReader
    {

        [DataMember]
        public double module1load1 { set { this._module1load1 = value; this.initialized = true; } get { return this._module1load1; } }
        private double _module1load1 = 0.0;
        [DataMember]
        public double module1load2 { set { this._module1load2 = value; this.initialized = true; } get { return this._module1load2; } }
        private double _module1load2 = 0.0;
        [DataMember]
        public double module1load3 { set { this._module1load3 = value; this.initialized = true; } get { return this._module1load3; } }
        private double _module1load3 = 0.0;
        [DataMember]
        public double module2load1 { set { this._module2load1 = value; this.initialized = true; } get { return this._module2load1; } }
        private double _module2load1 = 0.0;
        [DataMember]
        public double module2load2 { set { this._module2load2 = value; this.initialized = true; } get { return this._module2load2; } }
        private double _module2load2 = 0.0;
        [DataMember]
        public double module2load3 { set { this._module2load3 = value; this.initialized = true; } get { return this._module2load3; } }
        private double _module2load3 = 0.0;
        [DataMember]
        public double module3load1 { set { this._module3load1 = value; this.initialized = true; } get { return this._module3load1; } }
        private double _module3load1 = 0.0;
        [DataMember]
        public double module3load2 { set { this._module3load2 = value; this.initialized = true; } get { return this._module3load2; } }
        private double _module3load2 = 0.0;
        [DataMember]
        public double module3load3 { set { this._module3load3 = value; this.initialized = true; } get { return this._module3load3; } }
        private double _module3load3 = 0.0;
        [DataMember]
        public double module4load1 { set { this._module4load1 = value; this.initialized = true; } get { return this._module4load1; } }
        private double _module4load1 = 0.0;
        [DataMember]
        public double module4load2 { set { this._module4load2 = value; this.initialized = true; } get { return this._module4load2; } }
        private double _module4load2 = 0.0;
        [DataMember]
        public double module4load3 { set { this._module4load3 = value; this.initialized = true; } get { return this._module4load3; } }
        private double _module4load3 = 0.0;
        [DataMember]
        public double module5load1 { set { this._module5load1 = value; this.initialized = true; } get { return this._module5load1; } }
        private double _module5load1 = 0.0;
        [DataMember]
        public double module5load2 { set { this._module5load2 = value; this.initialized = true; } get { return this._module5load2; } }
        private double _module5load2 = 0.0;
        [DataMember]
        public double module5load3 { set { this._module5load3 = value; this.initialized = true; } get { return this._module5load3; } }
        private double _module5load3 = 0.0;
        [DataMember]
        public double module6load1 { set { this._module6load1 = value; this.initialized = true; } get { return this._module6load1; } }
        private double _module6load1 = 0.0;
        [DataMember]
        public double module6load2 { set { this._module6load2 = value; this.initialized = true; } get { return this._module6load2; } }
        private double _module6load2 = 0.0;
        [DataMember]
        public double module6load3 { set { this._module6load3 = value; this.initialized = true; } get { return this._module6load3; } }
        private double _module6load3 = 0.0;

        public bool initialized = false;

        override public string webURI()
        {
            return "api/PowerManagement/GetCurrentPDUData/";
        }
        override public string dummyReply()
        {
            return "{}";
        }
        override public void parse(string reply)
        {
            PDUData temp = new PDUData();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PDUData));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (PDUData)ser.ReadObject(stream1);

            this.module1load1 = temp.module1load1;
            this.module1load2 = temp.module1load2;
            this.module1load3 = temp.module1load3;
            this.module2load1 = temp.module2load1;
            this.module2load2 = temp.module2load2;
            this.module2load3 = temp.module2load3;
            this.module3load1 = temp.module3load1;
            this.module3load2 = temp.module3load2;
            this.module3load3 = temp.module3load3;
            this.module4load1 = temp.module4load1;
            this.module4load2 = temp.module4load2;
            this.module4load3 = temp.module4load3;
            this.module5load1 = temp.module5load1;
            this.module5load2 = temp.module5load2;
            this.module5load3 = temp.module5load3;
            this.module6load1 = temp.module6load1;
            this.module6load2 = temp.module6load2;
            this.module6load3 = temp.module6load3;

        }

    }
}
