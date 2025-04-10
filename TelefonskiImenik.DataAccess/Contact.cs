namespace TelefonskiImenik.DataAccess
{
    public class Contact(int id, string naziv, string stevilka)
    {
        public int Id { get; set; } = id;
        public string Naziv { get; set; } = naziv;
        public string Stevilka { get; set; } = stevilka;
    }
}
