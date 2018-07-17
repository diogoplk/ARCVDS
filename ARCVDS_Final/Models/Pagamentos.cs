﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Pagamentos {

        public Pagamentos() {

        }

        [Key]
        [Required]
        public int id_Pagamento { get; set; }

        [Required]
        [Display(Name = "Valor Pagamento")]
        public int Valor_Pagamento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Pagamento")]
        public DateTime? data_Pagamento { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime ultima_Ano_Pago { get; set; }

        public string Email { get; set; }
        
        [ForeignKey("Quota")]
        public int QuotaFK { get; set; }
        public virtual Quotas Quota { get; set; }
        
    }
}