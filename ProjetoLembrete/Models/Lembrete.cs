using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLembrete.Models
{
   public class Lembrete
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "O titulo do lembrete é obrigatório", AllowEmptyStrings = false)]
      public string Titulo { get; set; }
      public string Descricao { get; set; }

      [DataType(DataType.Date, ErrorMessage = "Data invalida")]
      public DateTime Data { get; set; }

      public override string ToString()
      {
         return "Lembrete Cadastrado Com sucesso!"+ "\nTitulo: " + Titulo +
            "\nDescrição: "+ Descricao + "\nData:" + Data;
      }
   }
}