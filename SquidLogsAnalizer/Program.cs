using System;
using System.IO;
using UMCC.GRedes;

namespace SquidLogsAnalizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("UMCC Squid Log Analaizer");

            TextReader tr = new StreamReader("access.log");
            string line = tr.ReadLine();
            Log log = Log.GetLogFromLine(line);
            if (log.Username != "")
            {
                Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                  log.DestinationHost + " " + log.SquidAction);
            }

            while (line != null)
            {
                line = tr.ReadLine();
                if (line != null)
                {
                    log = Log.GetLogFromLine(line);
                    if (log.Username != "")
                    {
                        Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                          log.DestinationHost + " " + log.SquidAction);
                    }
                }
            }
            tr.Close();
        }
    }
}