using System;
using System.Collections.Generic;
using System.IO; // Dosya işlemleri için eklenmeli
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http; // IFormFile kullanımı için gerekli
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sdeniz.Data;
using Sdeniz.Entities;

namespace Sdeniz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly DataBaseContext _context;

        public CategoriesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    // Dosyanın yükleneceği dizini oluşturma
                    string klasor = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Img");
                    
                    // Klasör yoksa oluştur
                    if (!Directory.Exists(klasor))
                    {
                        Directory.CreateDirectory(klasor);
                    }

                    // Dosyanın kaydedileceği tam yol
                    string dosyaYolu = Path.Combine(klasor, Image.FileName);

                    // Asenkron olarak dosyayı kaydet
                    using var stream = new FileStream(dosyaYolu, FileMode.Create);
                    await Image.CopyToAsync(stream);

                    // Veritabanına dosya adını kaydet
                    category.Image = Image.FileName;
                }

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Category category,IFormFile? Image)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        // Dosyanın yükleneceği dizini oluşturma
                        string klasor = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Img");
                    
                        // Klasör yoksa oluştur
                        if (!Directory.Exists(klasor))
                        {
                            Directory.CreateDirectory(klasor);
                        }

                        // Dosyanın kaydedileceği tam yol
                        string dosyaYolu = Path.Combine(klasor, Image.FileName);

                        // Asenkron olarak dosyayı kaydet
                        using var stream = new FileStream(dosyaYolu, FileMode.Create);
                        await Image.CopyToAsync(stream);

                        // Veritabanına dosya adını kaydet
                        category.Image = Image.FileName;
                    }
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}