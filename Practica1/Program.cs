using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    internal static class Program
    {
        internal static IConfiguration Configuration = null;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

            var connectionString = Configuration.GetConnectionString("NorthwindConnectionString");

            try
            { 
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ThreadException += Application_ThreadException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Formularios());
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, "Unhandled exception");
            MessageBox.Show(e.Exception.Message, "Unespected Error");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                Exception exception = (Exception)e.ExceptionObject;
                Log.Error(exception, "Unhandled exception");
                MessageBox.Show(exception.Message, "Unespected Error");
            }
        
    }
}
