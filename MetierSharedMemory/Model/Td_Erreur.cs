using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Model
{
    public class Td_Erreur
    {
        [Key]
        public int id { get; set; }
        public Nullable<System.DateTime> DataErreur { get; set; }
        [MaxLength(200)]
        public string DescriptionErreur { get; set; }
        [MaxLength(100)]
        public string TitreErreur { get; set; }
    }
}