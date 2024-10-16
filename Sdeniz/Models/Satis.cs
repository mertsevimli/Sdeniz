namespace Sdeniz.Entities;

public class Satis 
{
    public int Id { get; set; }
    public int UrunId { get; set; }
    public int MusteriId { get; set; }
    public decimal SatisFiyati { get; set; }
    public DateTime SatisTarihi { get; set; }
    public virtual Musteri Musteri { get; set; }
}