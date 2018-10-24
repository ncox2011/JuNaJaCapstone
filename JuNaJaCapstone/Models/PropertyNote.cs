using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuNaJaCapstone.Models
{
    public class PropertyNote
    {
        [Key]
        public int NoteId { get; set; }

        [Display(Name = "Notes")]
        public string NoteText { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Note Date")]
        public DateTime? DateNoted { get; set; }

        public int? PropertyId { get; set; }
        public Property Property { get; set; }

    }
}
