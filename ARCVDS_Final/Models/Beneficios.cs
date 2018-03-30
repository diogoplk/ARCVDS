using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Beneficios {

        public Beneficios () {
            this.Pessoa = new HashSet<Pessoas>();
        }

        [Required]
        [Key]
        public int id_Beneficio { get; set; }

        [Required]
        [StringLength(20)]
        public string Categoria { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Breve Descricao")]
        public string Descricao { get; set; }
        /*************************/
        /**********************************************/
        public virtual ICollection<Pessoas> Pessoa { get; set; }

    }
}