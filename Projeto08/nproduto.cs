using System;

class NProduto {
  private Produto[] produtos = new Produto[10];
  private int np;

  public Produto[] Listar() {
    // Retorna um vetor com os produtos cadastrados
    Produto[] p = new Produto[np];
    Array.Copy(produtos, p, np);
    return p;
  }

  public Produto Listar(int id) {
    // Localiza no vetor o produto com o id informado
    for (int i = 0; i < np; i++)
      if (produtos[i].GetId() == id) return produtos[i];
    return null;  
  }

  public void Inserir(Produto p) {
    // Insere um novo produto no vetor
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
    // Recupera a categoria do produto que está sendo inserido
    Categoria c = p.GetCategoria();
    // Se o produto tem uma categoria, insere ele nessa categoria
    if (c != null) c.ProdutoInserir(p);
  } 

  public void Atualizar(Produto p) {
    // Localiza no vetor o produto que possui o id informado no parametro p
    // Se não encontrar o produto com o Id, retorna sem alterar
    Produto p_atual = Listar(p.GetId());
    if (p_atual == null) return;
    // Alterar os dados do produto
    p_atual.SetDescricao(p.GetDescricao());
    p_atual.SetQtd(p.GetQtd());
    p_atual.SetPreco(p.GetPreco());
    // Exclui o produto de sua categoria atual
    if (p_atual.GetCategoria() != null) 
      p_atual.GetCategoria().ProdutoExcluir(p_atual);
    // Atualiza a categoria do produto
    p_atual.SetCategoria(p.GetCategoria());
    // Insere o produto na nova categoria
    if (p_atual.GetCategoria() != null)
      p_atual.GetCategoria().ProdutoInserir(p_atual);
  }

  private int Indice(Produto p) {
    // Retorna o índice do produto no vetor
    for(int i = 0; i < np; i++)
      if (produtos[i] == p) return i;
    return -1;  
  }

  public void Excluir(Produto p) {
    // Verifica se o produto está cadastrado
    int n = Indice(p);
    // Se não encontrar o produto, retorna sem alterar
    if (n == -1) return;
    // Desloca os produtos no vetor para substituir o índice do produto excluído
    // Remove o produto do vetor
    for (int i = n; i < np - 1; i++)
      produtos[i] = produtos[i + 1];
    // Decrementa o contador de produtos
    np--;
    // Remove o produto de sua categoria
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoExcluir(p);  
  }
}
