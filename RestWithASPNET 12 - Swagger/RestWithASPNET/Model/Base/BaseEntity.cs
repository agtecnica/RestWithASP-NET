using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithASPNET.Model.Base
{
    //Contrato entre os atributos e a estruta da tabela
    [DataContract]
    public class BaseEntity
    {

        [Column("id")]
        public long? Id { get; set; }
    }
}
