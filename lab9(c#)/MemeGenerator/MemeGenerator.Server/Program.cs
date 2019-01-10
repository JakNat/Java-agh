using System;
using Autofac;
using NetworkCommsDotNet;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MemeGenerator.Client.Server
{
    class Program
    {
        static void Main(string[] args)
        {


            //LoggingConfiguration logConfig = new LoggingConfiguration();
            //ConsoleTarget consoleTarget = new ConsoleTarget();
            //consoleTarget.Layout = "${date:format=HH\\:mm\\:ss} [${threadid} - ${level}] - ${message}";
            //logConfig.AddTarget("console", consoleTarget);
            //logConfig.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
            //var logger = NLog.LogManager.GetCurrentClassLogger();
            //NetworkComms.EnableLogging();

            NetworkComms.Logger.Info("ddd");
            //build our container
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            
            //taking our server from container
            var server = container.Resolve<ServerApp>();

            //register all requests
            server.RegisterIncomingPackerHandlers();

            server.StartListening();
           
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
            server.ShutDown();
        }   
    }
}