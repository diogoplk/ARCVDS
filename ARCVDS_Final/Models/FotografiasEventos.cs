using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class FotografiasEventos {

        [Key]
        [Required]
        public int id_Fotografia {get;set;}

        public string Imagens {get;set;}

        [ForeignKey("Evento")]
        public int EventoFK { get; set; }
        public virtual Eventos Evento { get; set; }
    }
}