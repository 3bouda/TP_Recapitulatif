namespace TP_Recapitulatif.Models
{
    public class Ouvrage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}