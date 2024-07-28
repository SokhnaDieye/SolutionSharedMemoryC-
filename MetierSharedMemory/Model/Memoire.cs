using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Model
{
    public class Memoire
    {
        [Key]
        public int idMemoire { get; set; }
        [MaxLength(300, ErrorMessage = "Taille max est de 300"), Required(ErrorMessage = "*")]
        [Display(Name = "Titre")]
        public string Titre { get; set; }
        [Required(ErrorMessage = "*")]
        public int Annee { get; set; }
        [MaxLength(10, ErrorMessage = "Taille max est de 10")]
        [Display(Name = "Statut")]
        public string Statut { get; set; }
        [MaxLength(80, ErrorMessage = "Taille max est de 80"), Required(ErrorMessage = "*")]
        [Display(Name = "Auteur")]
        public string Auteur { get; set; }
        [MaxLength(30, ErrorMessage = "Taille max est de 30"), Required(ErrorMessage = "*")]
        [Display(Name = "FileName")]
        public string FileName { get; set; }
        [MaxLength(10, ErrorMessage = "Taille max est de 10"), Required(ErrorMessage = "*")]
        [Display(Name = "Extension")]
        public string Extension { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "*")]
        [Display(Name = "Date de publication")]
        public DateTime? DatePublication { get; set; }
    }
}