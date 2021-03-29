using CrudProjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjection.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Odamon.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Odam odam)
        {
            db.Odamon.Add(odam);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int ? Id)
        {
            if (Id != null)
            {
                Odam odam = await db.Odamon.FirstOrDefaultAsync(p => p.Id == Id);
                if (odam != null)
                    return View(odam);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                Odam odam = await db.Odamon.FirstOrDefaultAsync(p => p.Id == Id);
                if (odam != null)
                    return View(odam);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Odam odam)
        {
            db.Odamon.Update(odam);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? Id)
        {
            if (Id != null)
            {
                Odam odam = await db.Odamon.FirstOrDefaultAsync(p => p.Id == Id);
                if (odam != null)
                    return View(odam);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id != null)
            {
                Odam odam = new Odam { Id=Id.Value };
                db.Entry(odam).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                #region
                //Odam odam = await db.Odamon.FirstOrDefaultAsync(p => p.Id == Id);
                //if (odam != null)
                //{
                //    db.Odamon.Remove(odam);
                //    await db.SaveChangesAsync();
                //    return RedirectToAction("Index");
                //}
                #endregion
            }
            return NotFound();

        }
    }
}
