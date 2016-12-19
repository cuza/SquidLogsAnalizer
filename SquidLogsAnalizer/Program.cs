using System;
using System.IO;
using UMCC.GRedes;

namespace SquidLogsAnalizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var route = args[0];
                AnalizeLog(route);
            }
            else
            {
                AnalizeLog("access.log");
            }
        }

        public static void AnalizeLog(string route)
        {
            var adsDomains = File.ReadAllLines("blacklists/ads/domains");
            var adsUrls = File.ReadAllLines("blacklists/ads/urls");
            var dialersDomains = File.ReadAllLines("blacklists/dialers/domains");
            var dialersUrls = File.ReadAllLines("blacklists/dialers/urls");
            var gamesDomains = File.ReadAllLines("blacklists/games/domains");
            var gamesUrls = File.ReadAllLines("blacklists/games/urls");
            var pornDomains = File.ReadAllLines("blacklists/porn/domains");
            var pornUrls = File.ReadAllLines("blacklists/porn/urls");
            var proxyDomains = File.ReadAllLines("blacklists/proxy/domains");
            var proxyUrls = File.ReadAllLines("blacklists/proxy/urls");
            var socialnetworkingDomains = File.ReadAllLines("blacklists/socialnetworking/domains");
            var socialnetworkingUrls = File.ReadAllLines("blacklists/socialnetworking/urls");
            var virusinfectedDomains = File.ReadAllLines("blacklists/virusinfected/domains");
            var virusinfectedUrls = File.ReadAllLines("blacklists/virusinfected/urls");
            var webmailDomains = File.ReadAllLines("blacklists/webmail/domains");
            var webmailUrls = File.ReadAllLines("blacklists/webmail/urls");

            Console.WriteLine("UMCC Squid Log Analaizer");
            try
            {
                TextReader tr = new StreamReader(route);
                var line = tr.ReadLine();

                while (line != null)
                {
                    var log = Log.GetLogFromLine(line);

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
                Console.WriteLine("Log fully analized. Have a good day 😀");
            }
            catch (Exception)
            {
                Console.WriteLine("acces.log file not found");
            }
        }
    }
}