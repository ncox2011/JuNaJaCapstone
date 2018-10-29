using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuNaJaCapstone.Models
{
    public class PropertyNoteCreateViewModel
    {
        public PropertyNote Note { get; set; }

        public PropertyNoteCreateViewModel(PropertyNote notes ) {
            Note = notes;
                }

    }
}
