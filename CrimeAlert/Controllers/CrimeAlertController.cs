using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrimeAlert.Models;
using Microsoft.AspNetCore.Authorization;
using Hangfire;
using Hangfire.Common;
using Hangfire.Storage;
using Microsoft.AspNetCore.SignalR;

namespace CrimeAlert.Controllers
{
    [Authorize]
    public class CrimeAlertController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IBackgroundJobClient _backgroundJobs;

        public CrimeAlertController(ApplicationDBContext context, IBackgroundJobClient backgroundJobs)
        {
            _context = context;
            _backgroundJobs = backgroundJobs;
        }

        // GET: CrimeAlert
        [Route("CrimeAlert")]
        public async Task<IActionResult> Index(string alert)
        {
            string userName = (Request.Cookies["UserName"]);
            var a = _context.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;

            ViewData["alert"] = alert;
            return _context.User_Crimealerts != null ?
             View(await _context.User_Crimealerts.ToListAsync()) :
             Problem("Entity set 'ApplicationDBContext.User_Crimealerts'  is null.");

        }

        // GET: CrimeAlert/Details
        [Route("CrimeAlert_details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User_Crimealerts == null)
            {
                return NotFound();
            }

            var user_crimeAlert = await _context.User_Crimealerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_crimeAlert == null)
            {
                return NotFound();
            }

            return View(user_crimeAlert);
        }

        // GET: CrimeAlert/Create
        public IActionResult Create()
        {

            string userName = (Request.Cookies["UserName"]);
            var a = _context.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;


            return View(new user_crimeAlert());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(user_crimeAlert user_crimeAlert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_crimeAlert);
                await _context.SaveChangesAsync();
                string alertMessage = "Alert: New Crime Alert has been generated !";
                ViewData["AlertMessage"] = alertMessage;
                return RedirectToAction(nameof(Index), new { Alert = ViewData["AlertMessage"] });
            }

            return View(user_crimeAlert);
        }

        // GET: CrimeAlert/Edit/5
        [HttpGet]
        [Route("CrimeAlert_edit")]
        [Route("CrimeAlertController/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User_Crimealerts == null)
            {
                return NotFound();
            }

            var user_crimeAlert = await _context.User_Crimealerts.FindAsync(id);
            if (user_crimeAlert == null)
            {
                return NotFound();
            }
            return View(user_crimeAlert);
        }

        // POST: CrimeAlert/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Id,CrimeType,Location,Gender,Time,CrimeDescription")] user_crimeAlert user_crimeAlert)
        {
            if (id != user_crimeAlert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_crimeAlert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!user_crimeAlertExists(user_crimeAlert.Id))
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
            return View(user_crimeAlert);
        }

        // GET: CrimeAlert/Delete/5
        [Route("CrimeAlert_delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User_Crimealerts == null)
            {
                return NotFound();
            }

            var user_crimeAlert = await _context.User_Crimealerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_crimeAlert == null)
            {
                return NotFound();
            }

            return View(user_crimeAlert);
        }

        // POST: CrimeAlert/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User_Crimealerts == null)
            {
                return Problem("Entity set 'ApplicationDBContext.User_Crimealerts'  is null.");
            }
            var user_crimeAlert = await _context.User_Crimealerts.FindAsync(id);
            if (user_crimeAlert != null)
            {
                _context.User_Crimealerts.Remove(user_crimeAlert);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool user_crimeAlertExists(int id)
        {
            return (_context.User_Crimealerts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
