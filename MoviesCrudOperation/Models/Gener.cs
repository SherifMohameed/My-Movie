using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCrudOperation.Models
{
    public class Gener
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenerId { get; set; }

        [Required,StringLength(100,MinimumLength =3)]
        public string Name { get; set; }
    }
}
