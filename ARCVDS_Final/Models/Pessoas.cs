using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Pessoas {

        public Pessoas() {
            //this.ListaPagamentos = new HashSet<Pagamentos>();
            this.ListaQuotas = new HashSet<Quotas>();
            //N/M
            this.ListaBeneficios = new HashSet<Beneficios>();
            this.ListaEventos = new HashSet<Eventos>();
        }

        [Required]
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[Index(IsUnique = true)]
        //[Display(Name = "Nº Sócio")]
        //public int NumeroSocio { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Completo")]
        [RegularExpression("[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+((-| )((da|de|do|das|dos) )?[A-ZÁÂÉÍÓÚ][a-záàâãäèéêëìíîïòóôõöùúûüç]+)+",ErrorMessage = "Erro")]
        public string Nome { get; set; }

        [Required]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display (Name = "Data Nascimento")]
        public DateTime data_Nascimento { get; set; }

        //[Required]
        [StringLength(1)]
        [RegularExpression ("[M]|[F]",ErrorMessage = "Insira F para Feminino, M para Masculino")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Morada Completa")]
        public string Morada { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Código Postal")]
        [RegularExpression("[0-9]{4}[-][0-9]{3} ([A-Z][a-z]+ [A-Z][a-z]+){1,3}",ErrorMessage = "Insere 4 número, 1 hifen, 3 número e a morada por escrito")]
        public string Codigo_Postal { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nacionalidade")]
        [RegularExpression("[A-z]+",ErrorMessage = "Nada")]
        public string Nacionalidade { get; set; }

        [Required]
        [StringLength(30)]
        [Index (IsUnique = true)]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$",ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(30)]
        public string Foto { get; set; }

        [Required]
        [StringLength(13)]
        [RegularExpression("[0-9]{9}",ErrorMessage = "Insere 9 algarismos")]
        [Display(Name = "Telefone")]
        public string numeroTelefone { get; set; }

        [Required]
        [StringLength(13)]
        [RegularExpression ("[0-9]{9}",ErrorMessage = "Insere 9 algarismos")]
        [Display(Name = "Telemóvel")]
        public string numeroTelemovel { get; set; }

        //[Required]
        [DisplayFormat (DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType (DataType.Date)]
        [Display(Name ="Data de Inscrição")]
        public DateTime dataEntradaClube { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        /********1/N*****Quotas**********/
        /*******************************************************************/

        public virtual ICollection<Quotas> ListaQuotas {
            get; set;
        }

        /********N/M******Beneficios*********/
        /*******************************************************************/

        public virtual ICollection<Beneficios> ListaBeneficios {
            get; set;
        }

        public virtual ICollection<Eventos> ListaEventos {get;set;}

    }
}