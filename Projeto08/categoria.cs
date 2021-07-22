using System;

class Categoria {
  private int id;
  private string descricao;
  private Produto[] produtos = new Produto[10];
  private int np;
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
  public Produto[] ProdutoListar() {
    Produto[] c = new Produto[np];
    Array.Copy(produtos, c, np);
    return c;
  }
  public void ProdutoInserir(Produto p) {
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
  }
  private int ProdutoIndice(Produto p) {
    for (int i = 0; i < np; i++)
      if (produtos[i] == p) return i;
    return -1;  
  }
  public void ProdutoExcluir(Produto p) {
    int n = ProdutoIndice(p);
    if (n == -1) return;
    for (int i = n; i < np - 1; i++)
      produtos[i] = produtos[i + 1];
    np--;  
  }
  public override string ToString() {
    return id + " - " + descricao + " - Nº produtos: " + np;
  }
}
