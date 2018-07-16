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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Ano da Quota")]
        public DateTime ano_Quota { get; set; }


        [Required]
        [Display(Name ="Valor da Quota")]
        public int Valor_Quota { get; set; }

        [Required]
        [Display(Description ="Quantidade paga/meses")]
        public string Descricao {
            get;set;
        }

        public string Email { get; set; }

        [Required]
        [Display(Description = ("Quota paga ou não paga"),Name = "Quota Paga?")]
        public Boolean Paga {get;set;}

        /**********************/
        [ForeignKey("Pessoa")]
        public int PessoaFK { get; set; }
        public virtual Pessoas Pessoa { get; set; }

        /*************************/
        public virtual ICollection<Pagamentos> ListaPagamentos { get; set; }
          
    }
}