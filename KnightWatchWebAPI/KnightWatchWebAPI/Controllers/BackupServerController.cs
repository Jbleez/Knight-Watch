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
    public class BackupServerController : ApiController
    {
        private BackupServerService backupService;

        public BackupServerController()
        {
            backupService = new BackupServerService();
        }

        [ActionName("GetCurrentBackupServerData")]
        public BackupServer GetCurrentBackupServerData()
        {
            return this.backupService.getCurrentBackupServerData();

        }

        [ActionName("PostCurrentBackupServerData")]
        public BackupServer PostCurrentBackupServerData()
        {
            return this.backupService.getCurrentBackupServerData();

        }

        [ActionName("GetBackupServerDataBeforeDate")]
        public BackupServer GetBackupServerDataBeforeDate(Int64 markTicks)
        {
            return this.backupService.getBackupServerDataBeforeDate(markTicks);

        }

        [ActionName("PostBackupServerDataBeforeDate")]
        public BackupServer PostBackupServerDataBeforeDate(Int64 markTicks)
        {
            return this.backupService.getBackupServerDataBeforeDate(markTicks);

        }
    }
}