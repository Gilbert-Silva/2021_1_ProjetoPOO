using System;
using System.Collections.Generic;

class NVenda {
  private List<Venda> vendas = new List<Venda>();

  public List<Venda> Listar() {
    // Retorna uma lista com as vendas cadastradas
    return vendas;
  }

  public List<Venda> Listar(Cliente c) {
    // Retorna uma lista com as vendas cadastradas do cliente c
    List<Venda> vs = new List<Venda>();
    foreach(Venda v in vendas)
      if (v.GetCliente() == c) vs.Add(v);
    return vs;
  }

  public Venda ListarCarrinho(Cliente c) {
    // Retorna uma lista com as vendas cadastradas do cliente c
    foreach(Venda v in vendas)
      if (v.GetCliente() == c && v.GetCarrinho()) return v;
    return null;
  }

  public void Inserir(Venda v, bool carrinho) {
    // Gera o id da vendas
    int max = 0;
    foreach (Venda obj in vendas)
      if (obj.GetId() > max) max = obj.GetId();
    v.SetId(max + 1);
    // Inserir a nova na lista de vendas
    vendas.Add(v);
    // Define o atributo carrinho
    v.SetCarrinho(carrinho);
  }

  public List<VendaItem> ItemListar(Venda v) {
    // Retorna os itens da vendas
    return v.ItemListar();
  }

  public void ItemInserir(Venda v, int qtd, Produto p) {
    // Inserir um item na vendas
    v.ItemInserir(qtd, p);
  }  

  public void ItemExcluir(Venda v) {
    // Remover todos os itens da venda
    v.ItemExcluir();
  }
}
