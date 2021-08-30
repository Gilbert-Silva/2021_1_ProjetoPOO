using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class NCategoria {
  private NCategoria() { }
  static NCategoria obj = new NCategoria();
  public static NCategoria Singleton { get => obj; }

  private Categoria[] categorias = new Categoria[10];
  private int nc;

  public void Abrir() {
    Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    categorias = f.Abrir("./categorias.xml");
    nc = categorias.Length;
    //XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
    //StreamReader f = new StreamReader("./categorias.xml", //Encoding.Default);
    //categorias = (Categoria[]) xml.Deserialize(f);
    //f.Close();
    //nc = categorias.Length;
  }

  public void Salvar() {
    Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    f.Salvar("./categorias.xml", Listar());
    //XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
    //StreamWriter f = new StreamWriter("./categorias.xml", false, //Encoding.Default);
    //xml.Serialize(f, Listar());
    //f.Close();
  }

  public Categoria[] Listar() {
    // Retorna um vetor com as categorias cadastradas
    Categoria[] c = new Categoria[nc];
    Array.Copy(categorias, c, nc);
    return c;
  }

  public Categoria Listar(int id) {
    // Localiza no vetor a categoria com o id informado
    for (int i = 0; i < nc; i++)
      if (categorias[i].GetId() == id) return categorias[i];
    return null;  
  }

  public void Inserir(Categoria c) {
    // Insere uma nova categoria no vetor
    if (nc == categorias.Length) {
      Array.Resize(ref categorias, 2 * categorias.Length);
    }
    categorias[nc] = c;
    nc++;
  } 

  public void Atualizar(Categoria c) {
    // Localiza no vetor a categoria que possui o id informado no parametro c
    Categoria c_atual = Listar(c.GetId());
    // Se não encontrar a categoria com o Id, retorna sem alterar
    if (c_atual == null) return;
    // Altera os dados da categoria
    c_atual.SetDescricao(c.GetDescricao());
  } 

  private int Indice(Categoria c) {
    // Retorna o índice da categoria no vetor
    for (int i = 0; i < nc; i++)
      if (categorias[i] == c) return i;
    return -1;      
  }

  public void Excluir(Categoria c) {
    // Verifica se a categoria está cadastrada
    int n = Indice(c);
    // Se não encontrar a categoria, retorna sem alterar
    if (n == -1) return;
    // Desloca as categorias no vetor para substituir o índice da categoria excluída
    for (int i = n; i < nc - 1; i++)
      categorias[i] = categorias[i + 1];
    // Decrementa o contador de categorias
    nc--;
    // Recupera a lista de produtos da categoria
    Produto[] ps = c.ProdutoListar();
    // Apaga a categoria dos produtos da categoria excluída
    foreach(Produto p in ps) p.SetCategoria(null); 
  } 
}
