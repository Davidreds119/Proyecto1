using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_1.Models;

namespace Prueba_1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Cliente2025Context _context;

        public ClientesController(Cliente2025Context context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.pkclientes == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
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
        public async Task<IActionResult> Create([Bind("pkclientes,nombre,apellido,apellido2,cedula")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }
        public async Task<IActionResult> CreateAJAX([FromBody] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return Json("Exito");
            }
            return Json("false");
        }
        public async Task<IActionResult> CargarInfo()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Json(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pkclientes,nombre,apellido,apellido2,cedula")] Clientes clientes)
        {
            if (id != clientes.pkclientes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.pkclientes))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.pkclientes == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportarXml()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var xml = new System.Text.StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.AppendLine("<clientes>");
            foreach (var c in clientes)
            {
                xml.AppendLine($"  <cliente>");
                xml.AppendLine($"    <pkclientes>{c.pkclientes}</pkclientes>");
                xml.AppendLine($"    <nombre>{System.Security.SecurityElement.Escape(c.nombre)}</nombre>");
                xml.AppendLine($"    <apellido>{System.Security.SecurityElement.Escape(c.apellido)}</apellido>");
                xml.AppendLine($"    <apellido2>{System.Security.SecurityElement.Escape(c.apellido2)}</apellido2>");
                xml.AppendLine($"    <cedula>{System.Security.SecurityElement.Escape(c.cedula)}</cedula>");
                xml.AppendLine($"  </cliente>");
            }
            xml.AppendLine("</clientes>");
            var bytes = System.Text.Encoding.UTF8.GetBytes(xml.ToString());
            return File(bytes, "application/xml", "clientes.xml");
        }

        public async Task<IActionResult> ExportarJson()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var json = System.Text.Json.JsonSerializer.Serialize(clientes);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "clientes.json");
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.pkclientes == id);
        }
    }
}
