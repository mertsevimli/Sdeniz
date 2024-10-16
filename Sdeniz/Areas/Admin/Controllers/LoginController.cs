using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Sdeniz.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sdeniz.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataBaseContext _context;

        public LoginController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                // Kullanıcıyı email ve şifreye göre bul
                var kullanici = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.IsActive);

                if (kullanici == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
                else
                {
                    // Kullanıcıya ait haklar oluşturuluyor
                    var haklar = new List<Claim>() 
                    { 
                        new Claim(ClaimTypes.Email, kullanici.Email) 
                    };

                    var kullaniciKimligi = new ClaimsIdentity(haklar, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);

                    // Kullanıcı kimliği doğrulanıyor ve oturum başlatılıyor
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    // Yönlendirme (Admin veya Home)
                    if (kullanici.IsAdmin)
                    {
                        return RedirectToAction("Index","Main" ,"Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index","Main" ,"Home");
                    }
                }
            }
            catch (Exception hata)
            {
                // Hata loglanacak
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }

      
        
    }
}