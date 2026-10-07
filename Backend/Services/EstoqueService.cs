using System;
using System.Collections.Generic;
public class EstoqueService
{
    public ProdutoEstoque BuscarProduto(List<ProdutoEstoque> produtos, int codigoProduto)
    {
        var produto = produtos.FirstOrDefault(produto => produto.CodigoProduto == codigoProduto) ?? throw new KeyNotFoundException($"O código do produto {codigoProduto} não foi encontrado no estoque.");

        return produto;
    }

    public int MovimentacaoDeEstoque(MovimentacaoEstoque movimentacao, ProdutoEstoque produto)
    {
        if (movimentacao.Tipo == "Entrada")
        {
            return produto.Estoque += movimentacao.Quantidade;
        }
        else if (movimentacao.Tipo == "Saída" && movimentacao.Quantidade <= produto.Estoque)
        {
            return produto.Estoque -= movimentacao.Quantidade;
        }
        else if (movimentacao.Tipo == "Saída" && movimentacao.Quantidade > produto.Estoque) 
        {
            throw new InvalidOperationException("Quantidade solicitada para saída maior que o estoque disponível.");
        }
        else {
            throw new ArgumentException($"O tipo de movimentação {movimentacao.Tipo} não existe no sistema");
        }
    }
}

// Movimentação 1
// Produto: 101
// Tipo: Entrada
// Quantidade: 20
// Descrição: "Compra de mercadoria"