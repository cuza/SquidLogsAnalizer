using System;
using System.Collections.Generic;

namespace SquidLogsAnalizer
{
    public class Log
    {
        private string _username;
        private string _hostIp;
        private string _httpMethod;
        private string _statusCode;
        private string _destinationHost;
        private string _squidAction;
        private string _mimeType;

        public Log(string username, string hostIp, string httpMethod, string statusCode, string destinationHost,
            string squidAction, string mimeType)
        {
            _username = username;
            _hostIp = hostIp;
            _httpMethod = httpMethod;
            _statusCode = statusCode;
            _destinationHost = destinationHost;
            _squidAction = squidAction;
            _mimeType = mimeType;
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string HostIp
        {
            get { return _hostIp; }
            set { _hostIp = value; }
        }

        public string HttpMethod
        {
            get { return _httpMethod; }
            set { _httpMethod = value; }
        }

        public string StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        public string DestinationHost
        {
            get { return _destinationHost; }
            set { _destinationHost = value; }
        }

        public string SquidAction
        {
            get { return _squidAction; }
            set { _squidAction = value; }
        }

        public string MimeType
        {
            get { return _mimeType; }
            set { _mimeType = value; }
        }

        public static Log GetLogFromLine(String line)
        {
            line.Trim();
            string[] tempArray = line.Split(' ');
            List<string> logElements = new List<string>();
            foreach (var element in tempArray)
            {
                if (element != "")
                {
                    logElements.Add(element);
                }
            }
            Log log = new Log(
                logElements[7],         //  username
                logElements[2],         //  host Ip
                logElements[5],         //  Http Method
                logElements[3],         //  Http status Code
                logElements[6],         //  destinnation Host
                logElements[8],         //  squid Action
                logElements[9]);        //  mimeType

            return log;
        }
    }
}