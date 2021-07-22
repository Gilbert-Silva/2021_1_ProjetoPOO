using System;

class NCategoria {
  private Categoria[] categorias = new Categoria[10];
  private int nc;

  public Categoria[] Listar() {
    Categoria[] c = new Categoria[nc];
    Array.Copy(categorias, c, nc);
    return c;
  }

  public Categoria Listar(int id) {
    for (int i = 0; i < nc; i++)
      if (categorias[i].GetId() == id) return categorias[i];
    return null;  
  }

  public void Inserir(Categoria c) {
    if (nc == categorias.Length) {
      Array.Resize(ref categorias, 2 * categorias.Length);
    }
    categorias[nc] = c;
    nc++;
  } 

  public void Atualizar(Categoria c) {
    // Localizar no vetor a categoria que possui o id informado no parametro categoria
    Categoria c_atual = Listar(c.GetId());
    if (c_atual == null) return;
    // Alterar os dados da minha categoria
    c_atual.SetDescricao(c.GetDescricao());
  } 

  private int Indice(Categoria c) {
    for (int i = 0; i < nc; i++)
      if (categorias[i] == c) return i;
    return -1;      
  }

  public void Excluir(Categoria c) {
    // Verifica se a categoria está cadastrada
    int n = Indice(c);
    if (n == -1) return;
    for (int i = n; i < nc - 1; i++)
      categorias[i] = categorias[i + 1];
    nc--;
    // Recuperar a lista de produtos da categoria
    Produto[] ps = c.ProdutoListar();
    foreach(Produto p in ps) p.SetCategoria(null); 
  } 

}
