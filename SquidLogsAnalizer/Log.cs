using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private DateTime _dateTime;
        private ulong _bytes;

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

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public ulong Bytes
        {
            get { return _bytes; }
            set { _bytes = value; }
        }

        public Log(string username, string hostIp, string httpMethod, string statusCode, string destinationHost,
            string squidAction, string mimeType, DateTime dateTime, ulong bytes)
        {
            _username = username;
            _hostIp = hostIp;
            _httpMethod = httpMethod;
            _statusCode = statusCode;
            _destinationHost = destinationHost;
            _squidAction = squidAction;
            _mimeType = mimeType;
            _dateTime = dateTime;
            _bytes = bytes;
        }

        public static Log GetLogFromLine(String line)
        {
            //This is for file access log first line is empty
            if(line == "" || String.IsNullOrEmpty(line))
            {
                var lines = File.ReadAllLines("access.log");
                File.WriteAllLines("access.log", lines.Skip(1).ToArray());
            }
            line.Trim();
            var logElements = new List<string>(line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));
            var log = new Log(
                logElements[7], //  username
                logElements[2], //  host Ip
                logElements[5], //  Http Method
                logElements[3], //  Http status Code
                logElements[6], //  destinnation Host
                logElements[8], //  squid Action
                logElements[9], //  mimeType
                UnixTimeStampToDateTime(long.Parse(logElements[0].Split('.')[0])), //  datetime
                ulong.Parse(logElements[4])); //  bytes recieved
            return log;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}