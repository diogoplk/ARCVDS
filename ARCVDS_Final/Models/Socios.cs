using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Socios {

        public Socios() {

        }

        [Required]
        [Key]
        [ForeignKey("Pessoa_ID_Socio")]
        public int id_SocioFK { get; set; }

        public virtual Pessoas Pessoa_ID_Socio { get; set; }
    }
}