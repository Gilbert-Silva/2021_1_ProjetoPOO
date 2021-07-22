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

  public void Atualizar(Produto p) {
    // Atualização dos dados de uma produto
    // p - id - demais atributos - novos dados desse produto
    Produto p_atual = Listar(p.GetId());
    if (p_atual == null) return;
    // Alterar todos os demais atributos do produto
    p_atual.SetDescricao(p.GetDescricao());
    p_atual.SetQtd(p.GetQtd());
    p_atual.SetPreco(p.GetPreco());
    // Exclui o produto da categoria atual    
    if (p_atual.GetCategoria() != null) {
      p_atual.GetCategoria().ProdutoExcluir(p_atual);
    }
    // Atualizar a categoria do produto
    p_atual.SetCategoria(p.GetCategoria());
    // Inserir o produto na nova categoria
    if (p_atual.GetCategoria() != null)
      p_atual.GetCategoria().ProdutoInserir(p_atual);
  }

  private int Indice(Produto p) {
    for(int i = 0; i < np; i++)
      if (produtos[i] == p) return i;
    return -1;  
  }

  public void Excluir(Produto p) {
    // Verificar se o produto existe
    int n = Indice(p);
    if (n == -1) return;
    // Remove o produto do vetor
    for (int i = n; i < np - 1; i++)
      produtos[i] = produtos[i + 1];
    np--;
    // Remover o produto de sua categoria
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoExcluir(p);  
  }
}
