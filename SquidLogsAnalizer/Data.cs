using System;
using System.IO;
using Mono.Data.Sqlite;

namespace SquidLogsAnalizer
{
    public class Data
    {
        private SqliteConnection _connection;

        public SqliteConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public Data(SqliteConnection connection)
        {
            _connection = connection;
        }
    }
}