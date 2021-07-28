using System;

class Categoria {
  // Atributos da categoria
  private int id;
  private string descricao;
  // Vetor de produtos de uma categoria - Associação entre Categoria e Produto
  private Produto[] produtos = new Produto[10];
  private int np;
  // Construtor
  public Categoria(int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  // Métodos de acesso
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
  // Métodos da associação entre Categoria e Produto
  public Produto[] ProdutoListar() {
    // Lista os produtos de uma categoria
    Produto[] c = new Produto[np];
    Array.Copy(produtos, c, np);
    return c;
  }
  public void ProdutoInserir(Produto p) {
    // Insere um produto em uma categoria
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
  }
  private int ProdutoIndice(Produto p) {
    // Recupera o índice de um produto no vetor
    for (int i = 0; i < np; i++)
      if (produtos[i] == p) return i;
    return -1;  
  }
  public void ProdutoExcluir(Produto p) {
    // Exclui um produto da categoria
    int n = ProdutoIndice(p);
    if (n == -1) return;
    for (int i = n; i < np - 1; i++)
      produtos[i] = produtos[i + 1];
    np--;  
  }
  // Retorna um texto com dados do objeto
  public override string ToString() {
    return id + " - " + descricao + " - Nº produtos: " + np;
  }
}
