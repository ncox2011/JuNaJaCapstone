using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuNaJaCapstone.Models
{
    public class PropertyImage
    {
        [Key]
        public int ImageId { get; set; }

        public string ImgURL { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
