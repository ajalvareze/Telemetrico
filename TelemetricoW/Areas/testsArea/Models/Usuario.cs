using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetricoW.Areas.testsArea.Models
{
    [Table("usuario", Schema="telemetricoSchema")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }
    }
}
