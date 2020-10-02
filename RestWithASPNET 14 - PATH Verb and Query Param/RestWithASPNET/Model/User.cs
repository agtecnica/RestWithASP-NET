using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long? Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("accesskey")]
        public string AccessKey { get; set; }
    }
}
