using System;
using System.IO;
using Mono.Data.Sqlite;

namespace SquidLogsAnalizer;
public sealed class SinglentonConnection
{
    private static readonly SinglentonConnection _instance = new SinglentonConnection();
    private static SqliteConnection _connection;
    private bool _exists;
    private string dbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "adodemo.db3");

    private SinglentonConnection()
    {
        _connection = new SqliteConnection("Data Source=" + dbPath);
        _connection.Open();
    }

    public static SqliteConnection Connection
    {
        get { return _connection; }
    }

}