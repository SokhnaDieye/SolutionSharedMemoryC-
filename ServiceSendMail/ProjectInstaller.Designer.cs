﻿namespace ServiceSendMail
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceNotification = new System.ServiceProcess.ServiceProcessInstaller();
            this.Notificayion = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceNotification
            // 
            this.ServiceNotification.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ServiceNotification.Password = null;
            this.ServiceNotification.Username = null;
            // 
            // Notificayion
            // 
            this.Notificayion.ServiceName = "Service1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ServiceNotification,
            this.Notificayion});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ServiceNotification;
        private System.ServiceProcess.ServiceInstaller Notificayion;
    }
}