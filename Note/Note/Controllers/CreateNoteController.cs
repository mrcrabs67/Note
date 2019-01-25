using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Note.ViewModels;
using Note.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Note.Controllers
{
    public class CreateNoteController : Controller
    {
        private NoteContext db;

        public HomeController(NoteContext context)
        {
            
                db = context;
            
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Notes.ToListAsync());
        }
        
        
    }
}