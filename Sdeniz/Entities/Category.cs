using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sdeniz.Entities;


public class Category
{
    public int Id { get; set; }

    [Display(Name = "Kategori Adı"), StringLengthAttribute(100)]
    public string Name { get; set; }

    [Display(Name = "Kategori Açıklaması")]
    public string? Description { get; set; }

    [Display(Name = "Kategori Resmi"), StringLengthAttribute(100)]
    public string? Image { get; set; }

    [Display(Name = "Durum")] 
    public bool IsActive { get; set; }
    
    [Display(Name = "Eklenme Tarihi")] public DateTime? CreateDate { get; set; } = DateTime.Now;

    public List<Post>? Posts { get; set; }
}