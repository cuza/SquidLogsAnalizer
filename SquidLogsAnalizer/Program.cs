using System;
using System.Diagnostics;
using System.IO;
using Mono.Data.Sqlite;

namespace SquidLogsAnalizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (args.Length > 0)
            {
                var route = args[0];
                ProcessLog(route);
            }
            else
            {
                ProcessLog("./access.log");
            }
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
        }

        public static SqliteConnection Connection;
        public static void AddData(Log log)
        {
            // determine the path for the database file
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "adodemo.db3");

            bool exists = File.Exists(dbPath);

            if (!exists)
            {
                Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                SqliteConnection.CreateFile(dbPath);
                Connection = new SqliteConnection("Data Source=" + dbPath);

                var commands = new[]
                {
                    "PRAGMA foreign_keys = false;",
                    "DROP TABLE IF EXISTS [Log];",
                    "CREATE TABLE [Log] ([id] INTEGER NOT NULL,[username] TEXT,[host_ip] TEXT,[http_method] TEXT,[status_code] TEXT,[destination_host] TEXT,[squid_action] TEXT,[mime_type] TEXT,[datetime] DATETIME,[bytes_recieved] INTEGER,PRIMARY KEY([id]AUTOINCREMENT));",
                    "DROP TABLE IF EXISTS [incidencia];",
                    "CREATE TABLE [Incidencias] ([id] INTEGER NOT NULL,[log_id] INTEGER NOT NULL,[tipo] TEXT,[sancion] TEXT,PRIMARY KEY([id]AUTOINCREMENT),CONSTRAINT [log] FOREIGN KEY ([log_id]) REFERENCES [log] ([id]) ON DELETE CASCADE ON UPDATE CASCADE);",
                    "PRAGMA foreign_keys = true;"
                };
                // Open the database connection and create table with data
                Connection.Open();
                foreach (var command in commands)
                {
                    using (var c = Connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var rowcount = c.ExecuteNonQuery();
                        Console.WriteLine("\tExecuted " + command);
                    }
                }
                var con = Connection.CreateCommand();

                con.CommandText = "BEGIN;";
                var rowcount1 = con.ExecuteNonQuery();

                con.CommandText =
                    "INSERT INTO [Log] ([username],[host_ip],[http_method],[status_code],[destination_host],[squid_action],[mime_type],[datetime],[bytes_recieved]) VALUES ('" +
                    log.Username + "','" +
                    log.HostIp + "','" + log.HttpMethod + "','" + log.StatusCode +
                    "','" + log.DestinationHost + "','" + log.SquidAction + "','" +
                    log.MimeType + "','" + log.DateTime.ToLocalTime().ToString() + "'," +
                    log.Bytes + " );";
                rowcount1 = con.ExecuteNonQuery();

                con.CommandText = "COMMIT;";
                rowcount1 = con.ExecuteNonQuery();
            }
            else
            {
                //Console.WriteLine("Database already exists");
                // Open connection to existing database file
                Connection = new SqliteConnection("Data Source=" + dbPath);
                
                Connection.Open();
                
                var c = Connection.CreateCommand();

                c.CommandText = "BEGIN;";
                var rowcount1 = c.ExecuteNonQuery();

                c.CommandText =
                    "INSERT INTO [Log] ([username],[host_ip],[http_method],[status_code],[destination_host],[squid_action],[mime_type],[datetime],[bytes_recieved]) VALUES ('" +
                    log.Username + "','" +
                    log.HostIp + "','" + log.HttpMethod + "','" + log.StatusCode +
                    "','" + log.DestinationHost + "','" + log.SquidAction + "','" +
                    log.MimeType + "','" + log.DateTime.ToLocalTime().ToString() + "'," +
                    log.Bytes + " );";
                rowcount1 = c.ExecuteNonQuery();

                c.CommandText = "COMMIT;";
                rowcount1 = c.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public static void ProcessLog(string route)
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
            TextReader tr = null;
            try
            {
                tr = new StreamReader(route);
            }
            catch (Exception)
            {
                Console.WriteLine("access.log file not found ,presione enter para salir");
                Console.ReadKey();
                return;
            }
            var line = tr.ReadLine();

            while (line != null)
            {
                var log = Log.GetLogFromLine(line);

                if (log.Username != "-")
                {
                        /*foreach (var blacklist in adsDomains)
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
                        }*/
                }
                AddData(log);
                line = tr.ReadLine();
            }
            tr.Close();
            Console.WriteLine("Log fully processed. Have a good day 😀");
        }
    }
}