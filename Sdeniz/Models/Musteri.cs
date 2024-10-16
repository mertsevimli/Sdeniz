namespace Sdeniz.Entities;

public class Musteri 
{
    public int Id { get; set; }
    public int UrunId { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public string IdNo { get; set; }
    public string Email { get; set; }
    public string Adres { get; set; }
    public string Telefon { get; set; }
    public virtual Urun Urun { get; set; }
}