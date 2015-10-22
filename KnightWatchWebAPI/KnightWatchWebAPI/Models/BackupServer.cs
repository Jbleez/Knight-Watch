using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class BackupServer
    {
        public String serverIP { get; set; }
        public String drive { get; set; }
        public String fileSystem { get; set; }
        public Int64 totalSpace { get; set; }
        public Int64 freeSpace { get; set; }
       
    }
}