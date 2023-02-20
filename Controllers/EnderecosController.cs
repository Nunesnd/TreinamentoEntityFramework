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
    public class EnderecosController : Controller
    {
        private readonly DbContexto _context;

        public EnderecosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
              return _context.Enderecos != null ? 
                          View(await _context.Enderecos.ToListAsync()) :
                          Problem("Entity set 'DbContexto.Enderecos'  is null.");
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] EnderecoModel enderecoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoModel);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos.FindAsync(id);
            if (enderecoModel == null)
            {
                return NotFound();
            }
            return View(enderecoModel);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] EnderecoModel enderecoModel)
        {
            if (id != enderecoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoModelExists(enderecoModel.Id))
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
            return View(enderecoModel);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enderecos == null)
            {
                return Problem("Entity set 'DbContexto.Enderecos'  is null.");
            }
            var enderecoModel = await _context.Enderecos.FindAsync(id);
            if (enderecoModel != null)
            {
                _context.Enderecos.Remove(enderecoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoModelExists(int id)
        {
          return (_context.Enderecos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
