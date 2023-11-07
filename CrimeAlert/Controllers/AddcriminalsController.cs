using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrimeAlert.Models;
using Microsoft.AspNetCore.Authorization;

namespace CrimeAlert.Controllers
{
    [Authorize]
    public class AddcriminalsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AddcriminalsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Addcriminals
        [Route("AddCriminal")]
        public async Task<IActionResult> Index()
        {
            string userName = (Request.Cookies["UserName"]);
            var a = _context.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return _context.Admin_AddCriminals != null ?
                          View(await _context.Admin_AddCriminals.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.Admin_AddCriminals'  is null.");
        }

        // GET: Addcriminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Admin_AddCriminals == null)
            {
                return NotFound();
            }

            var admin_addcriminals = await _context.Admin_AddCriminals
                .FirstOrDefaultAsync(m => m.case_ID == id);
            if (admin_addcriminals == null)
            {
                return NotFound();
            }
            string userName = (Request.Cookies["UserName"]);
            var a = _context.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return View(admin_addcriminals);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addcriminals/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("case_ID,Crime,CriminalName,Gender,Age,CrimeDescription,Status")] admin_addcriminals admin_addcriminals, IFormFile imageFile)
        {
            if ((ModelState.IsValid) && (imageFile.Length > 0) && (imageFile != null))
            {
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads" , imageFile.FileName);
                string[] FilePathArray = FilePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                string NewFilePath = "~/" + string.Join("/", FilePathArray[^2..^0]);
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                admin_addcriminals.PictureUrl = NewFilePath;
                _context.Add(admin_addcriminals);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(admin_addcriminals);
        }

        // GET: Addcriminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Admin_AddCriminals == null)
            {
                return NotFound();
            }

            var admin_addcriminals = await _context.Admin_AddCriminals.FindAsync(id);
            if (admin_addcriminals == null)
            {
                return NotFound();
            }
            return View(admin_addcriminals);
        }

        // POST: Addcriminals/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("case_ID,Crime,CriminalName,Gender,Age,CrimeDescription,Status")] admin_addcriminals admin_addcriminals)
        {
            if (id != admin_addcriminals.case_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin_addcriminals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!admin_addcriminalsExists(admin_addcriminals.case_ID))
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
            return View(admin_addcriminals);
        }

        // GET: Addcriminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Admin_AddCriminals == null)
            {
                return NotFound();
            }

            var admin_addcriminals = await _context.Admin_AddCriminals
                .FirstOrDefaultAsync(m => m.case_ID == id);
            if (admin_addcriminals == null)
            {
                return NotFound();
            }

            return View(admin_addcriminals);
        }

        // POST: Addcriminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Admin_AddCriminals == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Admin_AddCriminals'  is null.");
            }
            var admin_addcriminals = await _context.Admin_AddCriminals.FindAsync(id);
            if (admin_addcriminals != null)
            {
                _context.Admin_AddCriminals.Remove(admin_addcriminals);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool admin_addcriminalsExists(int id)
        {
            return (_context.Admin_AddCriminals?.Any(e => e.case_ID == id)).GetValueOrDefault();
        }
    }
}
