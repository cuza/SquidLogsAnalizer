using System;
using System.IO;
using UMCC.GRedes;

namespace SquidLogsAnalizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] adsDomains = File.ReadAllLines("blacklists/ads/domains");
            string[] adsUrls = File.ReadAllLines("blacklists/ads/urls");
            string[] dialersDomains = File.ReadAllLines("blacklists/dialers/domains");
            string[] dialersUrls = File.ReadAllLines("blacklists/dialers/urls");
            string[] gamesDomains = File.ReadAllLines("blacklists/games/domains");
            string[] gamesUrls = File.ReadAllLines("blacklists/games/urls");
            string[] pornDomains = File.ReadAllLines("blacklists/porn/domains");
            string[] pornUrls = File.ReadAllLines("blacklists/porn/urls");
            string[] proxyDomains = File.ReadAllLines("blacklists/proxy/domains");
            string[] proxyUrls = File.ReadAllLines("blacklists/proxy/urls");
            string[] socialnetworkingDomains = File.ReadAllLines("blacklists/socialnetworking/domains");
            string[] socialnetworkingUrls = File.ReadAllLines("blacklists/socialnetworking/urls");
            string[] virusinfectedDomains = File.ReadAllLines("blacklists/virusinfected/domains");
            string[] virusinfectedUrls = File.ReadAllLines("blacklists/virusinfected/urls");
            string[] webmailDomains = File.ReadAllLines("blacklists/webmail/domains");
            string[] webmailUrls = File.ReadAllLines("blacklists/webmail/urls");

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
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "ads");
                            }
                        }
                    }
                    foreach (var blacklist in adsUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "ads");
                            }
                        }
                    }
                    foreach (var blacklist in dialersDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "dialers");
                            }
                        }
                    }
                    foreach (var blacklist in dialersUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "dialers");
                            }
                        }
                    }
                    foreach (var blacklist in gamesDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "games");
                            }
                        }
                    }
                    foreach (var blacklist in gamesUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "games");
                            }
                        }
                    }
                    foreach (var blacklist in pornDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "porn");
                            }
                        }
                    }
                    foreach (var blacklist in pornUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "porn");
                            }
                        }
                    }
                    foreach (var blacklist in proxyDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "proxy");
                            }
                        }
                    }
                    foreach (var blacklist in proxyUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "proxy");
                            }
                        }
                    }
                    foreach (var blacklist in socialnetworkingDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "social netoworks");
                            }
                        }
                    }
                    foreach (var blacklist in socialnetworkingUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "socila networks");
                            }
                        }
                    }
                    foreach (var blacklist in virusinfectedDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "virus");
                            }
                        }
                    }
                    foreach (var blacklist in virusinfectedUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "virus");
                            }
                        }
                    }
                    foreach (var blacklist in webmailDomains)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "webmail");
                            }
                        }
                    }
                    foreach (var blacklist in webmailUrls)
                    {
                        if (!(blacklist.StartsWith("#")) && blacklist != "")
                        {
                            if (log.DestinationHost.Contains(blacklist) && log.SquidAction.Contains("DIRECT"))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + "webmail");
                            }
                        }
                    }
                }
                line = tr.ReadLine();
            }
            tr.Close();
        }
    }
}