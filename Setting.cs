using core.Helper;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Timers;
using core.Control;

namespace core
{
    public class Setting
    {

        public Setting()
        {
            setupLoger();
            SetTimer();
        }
        private void setupLoger()
        {

            var config = new NLog.Config.LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;

        }
        private  void SetTimer()
        {
            // Create a timer with a two second interval.
            Utils.Timer = new Timer(Utils.TryAgainInterval);

            // Hook up the Elapsed event for the timer. 
            Utils.Timer.Elapsed += OnTimedEvent;
            Utils.Timer.AutoReset = true;
            Utils.Timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("one entrrupt timer:" + Utils.Timer.Interval);
            Console.WriteLine("one entrrupt timer:" + Utils.Timer.Interval);
            var state =InFoControl.sendData();
            if (state == true)
                Utils.Timer.Interval = Utils.timerInterval;
            else
                Utils.Timer.Interval = Utils.TryAgainInterval;

        }
    }
}
