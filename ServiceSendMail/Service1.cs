using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceSendMail
{
    public partial class Service1 : ServiceBase
    {
        private static System.Timers.Timer aTimer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            try
            {

                WriteLogSystem("test", DateTime.Now.ToString());

            }
            catch (Exception ex)
            {

            }

            //Thread.Sleep(300000);
            aTimer.Start();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            WriteLogSystem("Arret du service SenMail", string.Format("Le service est arrété à {0}", DateTime.Now));
        }


        /// <summary>
        /// Cette methode Permet de loger dans le systeme
        /// </summary>
        /// <param name="erreur">Message erreur</param>
        /// <param name="libelle">Titre erreur</param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Send Mail: ";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}
