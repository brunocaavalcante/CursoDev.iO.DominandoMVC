using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Business.Models.Financas;
using App.Business.Interfaces.Financas;
using AutoMapper;

namespace Presentation.Areas.Financas.Controllers
{
    [Area("Financas")]
    public class ContasController : Controller
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContasController(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        // GET: Financas/Contas
        public async Task<IActionResult> Index()
        {
            return View(await _contaRepository.ObterTodos());
        }

        // GET: Financas/Contas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var conta = _contaRepository.ObterPorId(id);

            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Financas/Contas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Financas/Contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Conta conta)
        {
            if (ModelState.IsValid)
            {
                conta.Id = Guid.NewGuid();
                await _contaRepository.Adicionar(conta);

                return RedirectToAction(nameof(Index));
            }
            return View(conta);
        }

        // GET: Financas/Contas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
                return NotFound();

            var conta = await _contaRepository.ObterPorId(id);
            if (conta == null)
                return NotFound();

            return View(conta);
        }

        // POST: Financas/Contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Conta conta)
        {
            if (id != conta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _contaRepository.Atualizar(conta);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.Id))
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
            return View(conta);
        }

        // GET: Financas/Contas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // POST: Financas/Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var conta = await _context.Contas.FindAsync(id);
            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(Guid id)
        {
            return  _contaRepository.ObterPorId(id) != null;
        }
    }
}
