using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KnightWatchWebAPI.Models;
using KnightWatchWebAPI.Services;
using System.Collections;

namespace KnightWatchWebAPI.Controllers
{
    public class PowerManagementController : ApiController
    {
        private PowerManagementService powerService;

        public PowerManagementController()
        {
            this.powerService = new PowerManagementService();
        }

        [ActionName("GetCurrentFanSpeed")]
        public double GetCurrentFanSpeed(int fanNumber)
        {
            return this.powerService.getCurrentFanSpeed(fanNumber);

        }

        [ActionName("PostCurrentFanSpeed")]
        public double PostCurrentFanSpeed(int fanNumber)
        {
            return this.powerService.getCurrentFanSpeed(fanNumber);
        }

        [ActionName("GetCurrentCoolingData")]
        public CoolingData GetCurrentCoolingData(int fanNumber)
        {
            return this.powerService.getCurrentCoolingData(fanNumber);

        }

        [ActionName("PostCurrentCoolingData")]
        public CoolingData PostCurrentCoolingData(int fanNumber)
        {
            return this.powerService.getCurrentCoolingData(fanNumber);
        }

        [ActionName("GetCurrentTemperatureData")]
        public Temperatures GetCurrentTemperatureData(int fanNumber)
        {
            return this.powerService.getCurrentTemperatureData(fanNumber);

        }

        [ActionName("PostCurrentTemperatureData")]
        public Temperatures PostCurrentTemperatureData(int fanNumber)
        {
            return this.powerService.getCurrentTemperatureData(fanNumber);
        }

        [ActionName("GetCurrentPDUData")]
        public PDU GetCurrentPDUData()
        {
            return this.powerService.getCurrentPDUData();

        }

        [ActionName("PostCurrentPDUData")]
        public PDU PostCurrentPDUData()
        {
            return this.powerService.getCurrentPDUData();
        }

        [ActionName("GetCurrentPowerstripData")]
        public PowerStrip GetCurrentPowerstripData(int stripNumber)
        {
            return this.powerService.getCurrentPowerstripData(stripNumber);

        }

        [ActionName("PostCurrentPowerstripData")]
        public PowerStrip PostCurrentPowerstripData(int stripNumber)
        {
            return this.powerService.getCurrentPowerstripData(stripNumber);

        }

        [ActionName("GetPastFanSpeed")]
        public ArrayList GetPastFanSpeed(int fanNumber, Int64 startTicks, Int64 endTicks)
        {
            //DateTime start = new DateTime(2014, 09, 30);

            //DateTime end = new DateTime(2014, 10, 1);


            return this.powerService.getPastFanSpeed(fanNumber, startTicks, endTicks);

        }

        [ActionName("PostPastFanSpeed")]
        public ArrayList PostPastFanSpeed(int stripNumber, Int64 startTicks, Int64 endTicks)
        {
            
            return this.powerService.getPastFanSpeed(stripNumber, startTicks, endTicks);

        }

        [ActionName("GetPastCoolingData")]
        public ArrayList GetPastCoolingData(int fanNumber, Int64 startTicks, Int64 endTicks)
        {
            //DateTime start = new DateTime(2014, 09, 30);

            //DateTime end = new DateTime(2014, 10, 1);
            return this.powerService.getPastCoolingData(fanNumber, startTicks, endTicks);

        }

        [ActionName("PostPastCoolingData")]
        public ArrayList PostPastCoolingData(int fanNumber, Int64 startTicks, Int64 endTicks)
        {

            return this.powerService.getPastCoolingData(fanNumber, startTicks, endTicks);

        }

        [ActionName("GetPastTemperatureData")]
        public ArrayList GetPastTemperatureData(int fanNumber, Int64 startTicks, Int64 endTicks)
        {
            //DateTime start = new DateTime(2014, 09, 30);

            //DateTime end = new DateTime(2014, 10, 1);
            return this.powerService.getPastTemperatureData(fanNumber, startTicks, endTicks);

        }

        [ActionName("PostPastTemperatureData")]
        public ArrayList PostPastTemperatureData(int fanNumber, Int64 startTicks, Int64 endTicks)
        {

            return this.powerService.getPastTemperatureData(fanNumber, startTicks, endTicks);

        }

        [ActionName("GetPastPDUData")]
        public ArrayList GetPastPDUData(Int64 startTicks, Int64 endTicks)
        {
            //DateTime start = new DateTime(2014, 09, 30);

            //DateTime end = new DateTime(2014, 10, 1);
            return this.powerService.getPastPDUData(startTicks, endTicks);

        }

        [ActionName("PostPastPDUData")]
        public ArrayList PostPastPDUData(Int64 startTicks, Int64 endTicks)
        {

            return this.powerService.getPastPDUData(startTicks, endTicks);

        }

        [ActionName("GetPastPowerstripData")]
        public ArrayList GetPastPowerstripData(int stripNumber, Int64 startTicks, Int64 endTicks)
        {
            //DateTime start = new DateTime(2014, 09, 30);

            //DateTime end = new DateTime(2014, 10, 1);
            return this.powerService.getPastPowerstripData(stripNumber, startTicks, endTicks);

        }

        [ActionName("PostPastPowerstripData")]
        public ArrayList PostPastPowerstripData(int stripNumber, Int64 startTicks, Int64 endTicks)
        {

            return this.powerService.getPastPowerstripData(stripNumber, startTicks, endTicks);

        }
        /*
         
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
         */
    }
}