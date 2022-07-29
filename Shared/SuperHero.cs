using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Shared
{
    public class SuperHero
    {
        public int Id { get;set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Hero Name")]
        public string HeroName { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Comic Name")]
        public int ComicId { get; set; }
        [ForeignKey(nameof(ComicId))]
        public virtual Comic Comic { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public int MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }

    }
}
