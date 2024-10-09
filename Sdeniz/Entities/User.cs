using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sdeniz.Entities;

public class User
{
    public int Id { get; set; }

    [Display(Name = "Adı"), StringLengthAttribute(50)]
    public string Name { get; set; }

    [Display(Name = "Soyadı"), StringLengthAttribute(50)]
    public string Surname { get; set; }

    [StringLengthAttribute(50), EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Şifre"), StringLengthAttribute(50)]
    public string Password { get; set; }

    [Display(Name = "Kullanıcı Adı"), StringLengthAttribute(50)]
    public string? UserName { get; set; }

    [Display(Name = "Durum")] public bool IsActive { get; set; }
    [Display(Name = "Admin")] public bool IsAdmin { get; set; }
    [Display(Name = "Eklenme Tarihi")] public DateTime? CreateDate { get; set; } = DateTime.Now;
    
}