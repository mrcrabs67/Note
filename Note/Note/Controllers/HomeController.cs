using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Note.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Note.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }



        public ActionResult Index(string name)
        {
            if (User.Identity.IsAuthenticated)
            {


                var Notes = db.Notes;

                IQueryable<Notes> note = Notes;

                note = note.Where(p => p.UserName==User.Identity.Name);

                foreach (var s in note)
                {
                    Console.Write(s);
                }

                if (!String.IsNullOrEmpty(name))
                {
                    note = note.Where(p => p.NameNote.Contains(name));
                }

                return View(note);
            }
            else
            {
                return View();
            }

        }

        public IActionResult CreateNote()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Notes note = await db.Notes.FirstOrDefaultAsync(p => p.Id == id);
                if (note != null)
                    return View(note);
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Notes note)
        {
            //note.UserName = User.Identity.Name;
            Icon icon = new Icon();
            note.Icon = icon.GetIconTask(note.NameNote).Result;

            note.UserName = User.Identity.Name;

            
            db.Notes.Add(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Notes note = await db.Notes.FirstOrDefaultAsync(p => p.Id == id);
                if (note != null)
                    return View(note);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Notes note = await db.Notes.FirstOrDefaultAsync(p => p.Id == id);
                if (note != null)
                {
                    db.Notes.Remove(note);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
