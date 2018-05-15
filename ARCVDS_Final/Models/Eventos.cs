using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Eventos {

        public Eventos() {
            this.Pessoas = new HashSet<Pessoas>();
            //this.ListaFotos = new HashSet<FotografiasEventos> ();
            this.ListaFotos = new HashSet<FotografiasEventos> ();
        }

        [Required]
        [Key]
        public int id_Evento { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Nome do Evento")]
        public string nome_Evento {
            get;set;
        }

        [Required]
        [StringLength(255)]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Dia")]
        public DateTime Dia_Evento { get; set; }
        /*
        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Hora")]
        public DateTime Hora_Evento { get; set; }
        */
        [Required]
        [StringLength(30)]
        [Display(Name = "Patrocinadores")]
        public string nome_Patrocinador { get; set; }

        public virtual ICollection<Pessoas> Pessoas { get; set;}

        //public virtual ICollection<FotografiasEventos> ListaFotos { get; set; }

        public virtual ICollection<FotografiasEventos> ListaFotos { get; set; }

    }
}