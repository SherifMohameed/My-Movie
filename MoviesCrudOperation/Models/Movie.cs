using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCrudOperation.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required,StringLength(250,MinimumLength =3)]
        public string Title { get; set; }
        public int Year { get; set; }
        [Range(1,10)]
        public float Rate { get; set; }
        [Required,StringLength(2500,MinimumLength =100)]
        public string Story { get; set; }
        [StringLength(2500)]
        [Display(Name ="Upload Your Poster")]
        public string Poster { get; set; }

        [StringLength(2500)]
        [Display(Name = "Upload Your Trailer")]
        public string Trailer { get; set; }

        [Display(Name = "Gener")]
        public int GenerId { get; set; }
        public virtual IEnumerable<Gener> Geners { get; set; }
    }
}
