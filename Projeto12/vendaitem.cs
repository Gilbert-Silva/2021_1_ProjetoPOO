using System;

public class VendaItem {
  // Atributos do item de VendaItem
  private int qtd;
  private double preco;
  // Associação entre VendaItem e Produto
  private Produto produto;
  private int produtoId;

  // propriedades do item de venda
  public int Qtd { get => qtd; set => qtd = value; }
  public double Preco { get => preco; set => preco = value; }
  public int ProdutoId { get => produtoId; set => produtoId = value; }
  public VendaItem() { }

  public VendaItem(int qtd, Produto produto) {
    this.qtd = qtd;
    this.preco = produto.GetPreco();
    this.produto = produto;
    this.produtoId = produto.GetId();
  }
  public void SetQtd(int qtd) {
    this.qtd = qtd;
  }
  public void SetPreco(double preco) {
    this.preco = preco;
  }
  public void SetProduto(Produto produto) {
    this.produto = produto;
    this.produtoId = produto.GetId();
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
