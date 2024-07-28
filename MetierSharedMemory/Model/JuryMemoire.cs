using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Model
{
    public class JuryMemoire
    {
        [Key]
        [Column(Order = 1)]
        public int? idMemoire { get; set; }
        [ForeignKey("idMemoire")]
        public virtual Memoire Memoires { get; set; }

        [Key]
        [Column(Order = 2)]
        public int? idJury { get; set; }
        [ForeignKey("idJury")]
        public virtual jury Jury { get; set; }
    }
}