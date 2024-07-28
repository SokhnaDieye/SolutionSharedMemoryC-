using MetierSharedMemory.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Utils
{
    public class Logger
    {
        BdSharedMemory2Context db = new BdSharedMemory2Context();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TitreErreur"></param>
        /// <param name="erreur"></param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DataErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 1000 ? erreur.Substring(0, 1000) : erreur;
                db.Td_Erreur.Add(log);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="erreur"></param>
        /// <param name="libelle"></param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "App Gestion Memoir";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}