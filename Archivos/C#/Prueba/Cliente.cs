using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ignis 
{ 
    public class Cliente
    { 
        public string id { get; set; }

        public IList<int> ListaNrosEnteros { get; set; }

    }
}
