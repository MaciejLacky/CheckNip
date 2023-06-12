using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckNip.DB;
using CheckNip.DB.Models;
using CheckNip.Models;

namespace CheckNip.Controllers
{
    public class SubjectController : Controller
    {
        private readonly CheckNipContext _context;

        public SubjectController(CheckNipContext context)
        {
            _context = context;
        }

        // GET: SubjectDbs
        public async Task<IActionResult> Index()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects);
        }

        // GET: SubjectDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {            
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjectDb = await _context.Subjects.Include(a => a.AccountNumbers).Include(r => r.Representatives).Include(p=>p.Partners)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectDb == null)
            {
                return NotFound();
            }

            return View(subjectDb);
        }

          
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subjectDb = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectDb == null)
            {
                return NotFound();
            }

            return View(subjectDb);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subjects == null)
            {
                return Problem("Entity set 'CheckNipContext.Subjects'  is null.");
            }
            var subjectDb = await _context.Subjects.FindAsync(id);
            if (subjectDb != null)
            {
                _context.Subjects.Remove(subjectDb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectDbExists(int id)
        {
          return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
