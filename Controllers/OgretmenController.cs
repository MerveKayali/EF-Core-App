using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    public class OgretmenController: Controller
    {
         private readonly DataContext _context;
        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogretmenler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen ogretmen)
        {
            _context.Ogretmenler.Add(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }

         [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var ogrtmn = await _context.Ogretmenler.FindAsync(id);

            if(ogrtmn == null)
            {
                return NotFound();
            }
            return View(ogrtmn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, Ogretmen model)
        {
            if(id!= model.OgretmenId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Ogretmenler.Any(o=>o.OgretmenId==model.OgretmenId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();            
            }

            var ogretmen =await _context.Ogretmenler.FindAsync(id);
            if(ogretmen==null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var ogretmen=await _context.Ogretmenler.FindAsync(id);
            if(ogretmen==null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
         
    }
}