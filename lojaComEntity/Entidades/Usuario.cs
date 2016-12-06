using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Entidades
{
    public class Usuario
    {
        [Key]
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
