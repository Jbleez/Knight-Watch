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
    public class NetworkStatusController : ApiController
    {
        private NetworkStatusService networkStatusService;
        private String domainController1Server =  "192.168.70.60";
        private String domainController2Server = "192.168.70.61";
        private String webServer = "168.28.189.98";
        private String ESXiData1Server = "192.168.71.120";
        private String ESXiData2Server = "192.168.71.121";
        private String ESXiData3Server = "192.168.71.122";
        private String ESXiData4Server = "192.168.71.123";
        private String ESXiData5Server = "192.168.71.124";
        private String ESXiData6Server = "192.168.71.125";
        private String ESXiData7Server = "192.168.71.126";
        private String ESXiData8Server = "192.168.71.127";
        private String ESXiData9Server = "192.168.71.128";
        private String backupServer = "192.168.70.35";


        public NetworkStatusController()
        {
            networkStatusService = new NetworkStatusService();
        }

        [ActionName("GetCurrentNetworkStatus")]
        public ArrayList GetCurrentNetworkStatus()
        {
            ArrayList result = new ArrayList();

            result.Add(networkStatusService.getCurrentNetworkStatus(domainController1Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(domainController2Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(webServer));
            result.Add(networkStatusService.getCurrentNetworkStatus(backupServer));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData1Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData2Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData3Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData4Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData5Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData6Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData7Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData8Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData9Server));

            return result;

        }

        [ActionName("PostCurrentNetworkStatus")]
        public ArrayList PostCurrentNetworkStatus()
        {
            ArrayList result = new ArrayList();

            result.Add(networkStatusService.getCurrentNetworkStatus(domainController1Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(domainController2Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(webServer));
            result.Add(networkStatusService.getCurrentNetworkStatus(backupServer));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData1Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData2Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData3Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData4Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData5Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData6Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData7Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData8Server));
            result.Add(networkStatusService.getCurrentNetworkStatus(ESXiData9Server));

            return result;

        }

        [ActionName("GetNetworkStatusBeforeDate")]
        public ArrayList GetNetworkStatusBeforeDate(Int64 markTicks)
        {
            ArrayList result = new ArrayList();
            //markTicks = new DateTime(2014, 10, 26, 22, 0, 0, DateTimeKind.Local).Ticks;
            result.Add(networkStatusService.getNetworkStatusBeforeDate(domainController1Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(domainController2Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(webServer, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(backupServer, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData1Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData2Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData3Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData4Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData5Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData6Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData7Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData8Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData9Server, markTicks));

            return result;

        }

        [ActionName("PostNetworkStatusBeforeDate")]
        public ArrayList PostNetworkStatusBeforeDate(Int64 markTicks)
        {
            ArrayList result = new ArrayList();

            result.Add(networkStatusService.getNetworkStatusBeforeDate(domainController1Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(domainController2Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(webServer, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(backupServer, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData1Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData2Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData3Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData4Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData5Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData6Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData7Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData8Server, markTicks));
            result.Add(networkStatusService.getNetworkStatusBeforeDate(ESXiData9Server, markTicks));

            return result;

        }
    }
}