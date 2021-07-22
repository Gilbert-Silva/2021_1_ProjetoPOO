using System;

class NProduto {
  private Produto[] produtos = new Produto[10];
  private int np;

  public Produto[] Listar() {
    Produto[] p = new Produto[np];
    Array.Copy(produtos, p, np);
    return p;
  }

  public Produto Listar(int id) {
    for (int i = 0; i < np; i++)
      if (produtos[i].GetId() == id) return produtos[i];
    return null;  
  }

  public void Inserir(Produto p) {
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
    // Recuperar a categoria do produto que está sendo inserido
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoInserir(p);
  } 

}
