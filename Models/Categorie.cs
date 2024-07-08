using System.Collections.Generic;

namespace TP_Recapitulatif.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ouvrage> Ouvrages { get; set; }
    }
}