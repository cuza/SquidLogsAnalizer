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
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss"));
        }

        //public static SqliteConnection Connection;
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
                //Connection = new SqliteConnection("Data Source=" + dbPath);

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
                //Connection.Open();
                foreach (var command in commands)
                {
                    using (var c = SinglentonConnection.Connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var rowcount = c.ExecuteNonQuery();
                        Console.WriteLine("\tExecuted " + command);
                    }
                }
                var con = SinglentonConnection.Connection.CreateCommand();

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
                var c = SinglentonConnection.Connection.CreateCommand();

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
            //Connection.Close();
        }

        public static void ProcessLog(string route)
        {
            var blackLists = new Dictionary<string, List<string>>()
            {
                {"adsDomains", File.ReadAllLines("blacklists/ads/domains").ToList()}, 
                {"adsUrls", File.ReadAllLines("blacklists/ads/urls").ToList()}, 
                {"dialersDomains", File.ReadAllLines("blacklists/dialers/domains").ToList()}, 
                {"dialersUrls", File.ReadAllLines("blacklists/dialers/urls").ToList()},
                {"gamesDomains", File.ReadAllLines("blacklists/games/domains").ToList()}, 
                {"gamesUrls", File.ReadAllLines("blacklists/games/urls").ToList()}, 
                {"pornDomains", File.ReadAllLines("blacklists/porn/domains").ToList()}, 
                {"pornUrls", File.ReadAllLines("blacklists/porn/urls").ToList()},
                {"proxyDomains", File.ReadAllLines("blacklists/proxy/domains").ToList()}, 
                {"proxyUrls", File.ReadAllLines("blacklists/proxy/urls").ToList()}, 
                {"socialnetworkingDomains", File.ReadAllLines("blacklists/socialnetworking/domains").ToList()}, 
                {"socialnetworkingUrls", File.ReadAllLines("blacklists/socialnetworking/urls").ToList()},
                {"virusinfectedDomains", File.ReadAllLines("blacklists/virusinfected/domains").ToList()}, 
                {"virusinfectedUrls", File.ReadAllLines("blacklists/virusinfected/urls").ToList()}, 
                {"webmailDomains", File.ReadAllLines("blacklists/webmail/domains").ToList()}, 
                {"webmailUrls", File.ReadAllLines("blacklists/webmail/urls").ToList()}
            };

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

                /*if (log.Username != "-")
                {
                    foreach (var blacklist in blackLists)
                    {
                        var listName = blacklist.Key;
                        var list = blacklist.Value;

                        if (list.Any() && !list[0].StartsWith("#"))
                        {
                            if (list.Any(blacklistItem => log.DestinationHost.Contains(blacklistItem) && log.SquidAction.Contains("DIRECT")))
                            {
                                Console.WriteLine(log.Username + " " + log.HostIp + " " + " " +
                                                  log.DestinationHost + " " + listName);
                            }
                        }
                    }
                }*/
                AddData(log);
                line = tr.ReadLine();
            }
            tr.Close();
            Console.WriteLine("Log fully processed. Have a good day 😀");
        }
    }
}