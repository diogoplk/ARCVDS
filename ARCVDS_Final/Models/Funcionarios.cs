using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ARCVDS_Final.Models {
    public class Funcionarios {

        public Funcionarios () {
            this.Evento = new HashSet<Eventos>();
        }

        [Key]
        [Required]
        [ForeignKey("Pessoa_ID_Funcionario")]
        public int id_FuncionarioFK { get; set; }

        public virtual Pessoas Pessoa_ID_Funcionario { get; set; }


        /**********N/M*****************/
        /*****************************************************/
        public virtual ICollection<Eventos> Evento { get; set; }

    }
}