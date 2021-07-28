using System;

class Produto {
  // Atributos do produto
  private int id;
  private string descricao;
  private int qtd;
  private double preco;
  // Categoria do produto - Associação entre Categoria e Produto
  private Categoria categoria;
  // Construtores
  public Produto(int id, string descricao, int qtd, double preco) {
    this.id = id;
    this.descricao = descricao;
    this.qtd = qtd > 0 ? qtd : 0;
    this.preco = preco > 0 ? preco : 0;
  }
  public Produto(int id, string descricao, int qtd, double preco, Categoria categoria) : this(id, descricao, qtd, preco) {
    this.categoria = categoria;
  }
  // Métodos de acesso
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public void SetQtd(int qtd) {
    this.qtd = qtd > 0 ? qtd : 0;
  }
  public void SetPreco(double preco) {
    this.preco = preco > 0 ? preco : 0;
  }
  public void SetCategoria(Categoria categoria) {
    this.categoria = categoria;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public int GetQtd() {
    return qtd;
  }
  public double GetPreco() {
    return preco;
  }
  public Categoria GetCategoria() {
    return categoria;
  }
  // Retorna um texto com dados do objeto
  public override string ToString() {
    if (categoria == null)
      return id + " - " + descricao + " - estoque: " + qtd + " - preço: " + preco.ToString("0.00");
    else  
      return id + " - " + descricao + " - estoque: " + qtd + " - preço: " + preco.ToString("0.00") + " - " + categoria.GetDescricao();
  }
}
