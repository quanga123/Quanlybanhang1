using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quanlybanhang.Models;

namespace Quanlybanhang.Controllers
{
    public class ChiTietHdsController : Controller
    {
        private readonly quanlybanhangContext _context;

        public ChiTietHdsController(quanlybanhangContext context)
        {
            _context = context;
        }

        // GET: ChiTietHds
        public async Task<IActionResult> Index()
        {
            var quanlybanhangContext = _context.ChiTietHd.Include(c => c.MaHdNavigation).Include(c => c.MaSpNavigation);
            return View(await quanlybanhangContext.ToListAsync());
        }

        // GET: ChiTietHds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHd
                .Include(c => c.MaHdNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.IdchitietHd == id);
            if (chiTietHd == null)
            {
                return NotFound();
            }

            return View(chiTietHd);
        }

        // GET: ChiTietHds/Create
        public IActionResult Create()
        {
            ViewData["MaHd"] = new SelectList(_context.HoaDon, "MaHd", "MaKh");
            ViewData["MaSp"] = new SelectList(_context.SanPham, "MaSp", "MaSp");
            return View();
        }

        // POST: ChiTietHds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHd,MaSp,SoLuong,IdchitietHd")] ChiTietHd chiTietHd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHd"] = new SelectList(_context.HoaDon, "MaHd", "MaKh", chiTietHd.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPham, "MaSp", "MaSp", chiTietHd.MaSp);
            return View(chiTietHd);
        }

        // GET: ChiTietHds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHd.FindAsync(id);
            if (chiTietHd == null)
            {
                return NotFound();
            }
            ViewData["MaHd"] = new SelectList(_context.HoaDon, "MaHd", "MaKh", chiTietHd.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPham, "MaSp", "MaSp", chiTietHd.MaSp);
            return View(chiTietHd);
        }

        // POST: ChiTietHds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHd,MaSp,SoLuong,IdchitietHd")] ChiTietHd chiTietHd)
        {
            if (id != chiTietHd.IdchitietHd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHdExists(chiTietHd.IdchitietHd))
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
            ViewData["MaHd"] = new SelectList(_context.HoaDon, "MaHd", "MaKh", chiTietHd.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPham, "MaSp", "MaSp", chiTietHd.MaSp);
            return View(chiTietHd);
        }

        // GET: ChiTietHds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHd
                .Include(c => c.MaHdNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.IdchitietHd == id);
            if (chiTietHd == null)
            {
                return NotFound();
            }

            return View(chiTietHd);
        }

        // POST: ChiTietHds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHd = await _context.ChiTietHd.FindAsync(id);
            _context.ChiTietHd.Remove(chiTietHd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHdExists(int id)
        {
            return _context.ChiTietHd.Any(e => e.IdchitietHd == id);
        }
    }
}
