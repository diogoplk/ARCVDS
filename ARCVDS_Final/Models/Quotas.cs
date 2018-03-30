using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Quotas {

        public Quotas() {
            this.ListaPagamentos = new HashSet<Pagamentos>();
        }

        [Required]
        [Key]
        public int id_Quota { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ano da Quota")]
        public DateTime ano_Quota { get; set; }

        /**********************/
        [ForeignKey("Pessoa")]
        public int PessoaFK { get; set; }
        public virtual Pessoas Pessoa { get; set; }

        /*************************/
        public virtual ICollection<Pagamentos> ListaPagamentos { get; set; }

    }
}