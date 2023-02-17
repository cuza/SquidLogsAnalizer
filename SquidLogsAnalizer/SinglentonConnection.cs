using System;
using System.IO;
using Mono.Data.Sqlite;

namespace SquidLogsAnalizer;
public sealed class SinglentonConnection
{
    private static readonly SinglentonConnection _instance = new SinglentonConnection();
    private static SqliteConnection _connection;
    private bool _exists;

    private SinglentonConnection()
    {
        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "adodemo.db3");
        _exists = File.Exists(dbPath);
        if (!_exists)
        {
            SqliteConnection.CreateFile(dbPath);
            _connection = new SqliteConnection("Data Source=" + dbPath);
        }
    }

    public static SqliteConnection Connection
    {
        get { return _connection; }
    }

}