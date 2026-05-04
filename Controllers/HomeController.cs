using Chert_s_nim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Chert_s_nim;
using Microsoft.EntityFrameworkCore;

namespace Chert_s_nim.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Engine()
        {
            return View(await db.Engines.ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                EngineData? engine = await db.Engines.FirstOrDefaultAsync(p => p.Id == id);
                if (engine != null) return View(engine);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EngineData engine)
        {
            db.Engines.Add(engine);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                {
                    EngineData engine = new EngineData { Id = id.Value };
                    db.Entry(engine).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EngineData engine)
        {
            db.Engines.Update(engine);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
