using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ignis 
{ 
    public class IdentityUser 
    { 
        public string id { get; set; }

        public IList<int> ListaNrosEnteros { get; set; }

    }
}
