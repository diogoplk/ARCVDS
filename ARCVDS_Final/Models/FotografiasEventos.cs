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
        public int id_Fotografia {
            get;set;
        }

        public string Imagem1 {
            get;set;
        }

        public string Imagem2 {
            get; set;
        }
        public string Imagem3 {
            get; set;
        }
        public string Imagem4 {
            get; set;
        }

        [ForeignKey("Evento")]
        public int EventosFK {
            get;set;
        }

        public virtual Eventos Evento {
            get;set;
        }

    }
}