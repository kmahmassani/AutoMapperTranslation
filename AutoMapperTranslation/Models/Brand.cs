using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslationPOC.Attributes;

namespace TranslationPOC.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Translatable]
        public string Name { get; set; }
        
        [Translatable]
        public string Description { get; set; }
    }
}
