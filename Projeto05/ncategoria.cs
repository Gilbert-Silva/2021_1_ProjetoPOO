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

}