using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;
using EntityFramework.Servicos.Database;

namespace EntityFramework.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DbContexto _context;

        public ClientesController(DbContexto context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return _context.Clientes != null ? 
                          View(await _context.Clientes.ToListAsync()) :
                          Problem("Entity set 'DbContexto.Clientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Observacoes")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            return View(clienteModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Observacoes")] ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.Id))
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
            return View(clienteModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'DbContexto.Clientes'  is null.");
            }
            var clienteModel = await _context.Clientes.FindAsync(id);
            if (clienteModel != null)
            {
                _context.Clientes.Remove(clienteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
