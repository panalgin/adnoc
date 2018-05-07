using DataEntryApp.Properties;
using System;

namespace DataEntryApp
{
    public static class Utility
    {
        internal static void ConfigureConnectionString(EventEntities context)
        {
            Settings.Default.Reload();

            var server = Settings.Default.Server;
            var catalog = Settings.Default.Catalog;
            var user = Settings.Default.Username;
            var password = Settings.Default.Password;


            context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString.Replace("{Server}", server).
                Replace("{Catalog}", catalog).
                Replace("{User}", user).
                Replace("{Password}", password);
        }
    }
}