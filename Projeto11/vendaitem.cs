using System;

class VendaItem {
  // Atributos do item de VendaItem
  private int qtd;
  private double preco;
  // Associação entre VendaItem e Produto
  private Produto produto;
  public VendaItem(int qtd, Produto produto) {
    this.qtd = qtd;
    this.preco = produto.GetPreco();
    this.produto = produto;
  }
  public void SetQtd(int qtd) {
    this.qtd = qtd;
  }
  public void SetPreco(double preco) {
    this.preco = preco;
  }
  public void SetProduto(Produto produto) {
    this.produto = produto;
  }
  public int GetQtd() {
    return qtd;
  }
  public double GetPreco() {
    return preco;
  }
  public Produto GetProduto() {
    return produto;
  }
  public override string ToString() {
    return produto.GetDescricao() + " - Qtd:" + qtd + " - Preço: " + preco.ToString("c2");
  }
}
