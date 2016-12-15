using System;
using System.IO;
using UMCC.GRedes;

namespace SquidLogsAnalizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] adsDomains = File.ReadAllLines("blacklist/ads/domains");
            string[] adsUrls = File.ReadAllLines("blacklist/ads/urls");
            string[] dialersDomains = File.ReadAllLines("blacklist/dialers/domains");
            string[] dialersUrls = File.ReadAllLines("blacklist/dialers/urls");
            string[] gamesDomains = File.ReadAllLines("blacklist/games/domains");
            string[] gamesUrls = File.ReadAllLines("blacklist/games/urls");
            string[] pornDomains = File.ReadAllLines("blacklist/porn/domains");
            string[] pornUrls = File.ReadAllLines("blacklist/porn/urls");
            string[] proxyDomains = File.ReadAllLines("blacklist/proxy/domains");
            string[] proxyUrls = File.ReadAllLines("blacklist/proxy/urls");
            string[] socialnetworkingDomains = File.ReadAllLines("blacklist/socialnetworking/domains");
            string[] socialnetworkingUrls = File.ReadAllLines("blacklist/socialnetworking/urls");
            string[] virusinfectedDomains = File.ReadAllLines("blacklist/virusinfected/domains");
            string[] virusinfectedUrls = File.ReadAllLines("blacklist/virusinfected/urls");
            string[] webmailDomains = File.ReadAllLines("blacklist/webmail/domains");
            string[] webmailUrls = File.ReadAllLines("blacklist/webmail/urls");

            Console.WriteLine("UMCC Squid Log Analaizer");

            TextReader tr = new StreamReader("access.log");
            String line = tr.ReadLine();

            while (line != null)
            {
                Log log = Log.GetLogFromLine(line);

                if (log.Username != "-")
                {
                    foreach (var blacklist in adsDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in adsUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in dialersDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in dialersUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in gamesDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in gamesUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in pornDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in pornUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in proxyDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in proxyUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in socialnetworkingDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in socialnetworkingUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in virusinfectedDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in virusinfectedUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in webmailDomains)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                    foreach (var blacklist in webmailUrls)
                    {
                        if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                        {
                            Console.WriteLine(log.Username + " " + log.HostIp + " " + log.HttpMethod + " " +
                                              log.DestinationHost + " " + log.SquidAction);
                        }
                    }
                }
                line = tr.ReadLine();
            }
            tr.Close();
        }
    }
}