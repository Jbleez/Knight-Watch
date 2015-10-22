using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace KnightWatchWebAPI.Services
{
    public class FTPService
    {   
        public FTPService()
        {

        }

        public StreamReader getResponse(string uri, string userName, string password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // Creates credential for ftp.
            request.Credentials = new NetworkCredential(userName, password);

            // gets the response of ftp
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return reader;
        }

    }
}