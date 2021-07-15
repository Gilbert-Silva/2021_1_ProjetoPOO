using System;

class MainClass {
  public static void Main() {
    Categoria c1 = new Categoria(1, "Mouse");
    Categoria c2 = new Categoria(2, "Fonte");
    Console.WriteLine(c1);
    Console.WriteLine(c2);

    Produto p1 = new Produto(1, "Mouse Bluetooth", 10, 150);
    Produto p2 = new Produto(2, "Mouse Usb", 15, 60);
    Produto p3 = new Produto(3, "Fonte Atx", 20, 300);
    Produto p4 = new Produto(4, "Teclado Usb", 20, 100);    
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);
  }
}

class Categoria {
  private int id;
  private string descricao;
  public Categoria(int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public override string ToString() {
    return id + " - " + descricao;
  }
}

class Produto {
  private int id;
  private string descricao;
  private int qtd;
  private double preco;
  public Produto(int id, string descricao, int qtd, double preco) {
    this.id = id;
    this.descricao = descricao;
    this.qtd = qtd > 0 ? qtd : 0;
    this.preco = preco > 0 ? preco : 0;
  }
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
  public override string ToString() {
    return id + " - " + descricao + " - estoque: " + qtd + " - preço: " + preco.ToString("0.00");
  }
}

