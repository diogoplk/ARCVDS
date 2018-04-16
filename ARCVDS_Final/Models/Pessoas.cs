using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Pessoas {

        public Pessoas() {
            this.ListaPagamentos = new HashSet<Pagamentos>();
            this.ListaQuotas = new HashSet<Quotas>();
            //N/M
            this.Beneficios = new HashSet<Beneficios>();
            this.ListaEventos = new HashSet<Eventos>();
        }

        [Required]
        [Key]
        public int Pessoa_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime data_Nascimento { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Morada Completa")]
        public string Morada { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Código Postal")]
        public string Codigo_Postal { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Foto { get; set; }

        [Required]
        [StringLength(13)]
        [Display(Name = "Telefone")]
        public string numeroTelefone { get; set; }

        [Required]
        [StringLength(13)]
        [Display(Name = "Telemóvel")]
        public string numeroTelemovel { get; set; }

        /********1/N*****Pagamentos**********/
        /*******************************************************************/
        public virtual ICollection<Pagamentos> ListaPagamentos { get; set; }

        /********1/N*****Quotas**********/
        /*******************************************************************/

        public virtual ICollection<Quotas> ListaQuotas { get; set; }

        /********N/M******Beneficios*********/
        /*******************************************************************/

        public virtual ICollection<Beneficios> Beneficios { get; set; }

        public virtual ICollection<Eventos> ListaEventos {
            get;set;
        }

    }
}