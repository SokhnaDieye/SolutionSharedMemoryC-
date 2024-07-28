using MetierSharedMemory.Model;
using MetierSharedMemory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        Logger log = new Logger();
        BdSharedMemory2Context db = new BdSharedMemory2Context();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        /// <summary>
        /// cette methode permet l'enregistrement d'un membre jury
        /// </summary>
        /// <param name="jury"> membre jury</param>
        /// <returns>true si ok, sinon false</returns>
        public bool AddJury(jury jury)
        {
            try
            {
                db.Jury.Add(jury);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-AddJury", ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// cette methode permet la modification d'un membre jury
        /// </summary>
        /// <param name="jury">jury</param>
        /// <returns>true si ok,sinon false</returns>

        public bool EditJury(jury jury)
        {
            try
            {
                var lejury = db.Jury.Find(jury.IdPersonne);
                if (lejury != null)
                {
                    lejury.Nom = jury.Nom;
                    lejury.Prenom = jury.Prenom;
                    lejury.Grade = jury.Grade;
                    lejury.Specialite = jury.Specialite;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-EditJury", ex.ToString());
                return false;
            }
            return false;
        }
        /// <summary>
        /// cette methode permet la suppression d'un membre jury
        /// </summary>
        /// <param name="juryId">jury</param>
        /// <returns>true si ok,sinon false</returns>
        public bool DeleteJury(int? juryId)
        {
            try
            {
                var lejury = db.Jury.Find(juryId);
                if (lejury != null)
                {
                    db.Jury.Remove(lejury);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-DeleteJury", ex.ToString());
                return false;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<jury> GetJury()
        {
            return db.Jury.ToList();
        }
        /// <summary>
        /// cette methode permet de lister un membre jury
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <param name="Specialite"></param>
        /// <returns></returns>
        public List<jury> GetsJury(string Nom, string Prenom, string Specialite)
        {
            var liste = db.Jury.ToList();
            if (!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a => a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Specialite))
            {
                liste = liste.Where(a => a.Specialite.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }
            return liste;
        }

    }
}
