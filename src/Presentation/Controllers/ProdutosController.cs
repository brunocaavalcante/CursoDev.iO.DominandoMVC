using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Business.Interfaces;
using App.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ProdutosController(
            IProdutoRepository context,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper
            )
        {
            _produtoRepository = context;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }
        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View( _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObeterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return View(produtoViewModel);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = ObeterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewModel));
            return RedirectToAction("Index");

        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await ObeterProduto(id);
                
            if (produtoViewModel == null) return NotFound();
            
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await ObeterProduto(id);

            if (produtoViewModel == null) return NotFound();

            await _produtoRepository.Remover(id);

            return View("Index");
        }

        private async Task<ProdutoViewModel> ObeterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObeterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }
        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produtoViewModel;
        }
    }
}
