using System;

class MainClass {
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();
  public static void Main() {
    int op = 0;
    Console.WriteLine ("----- Aplicativo de Vendas ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : CategoriaListar(); break;
          case 2 : CategoriaInserir(); break;
          case 3 : CategoriaAtualizar(); break;
          case 4 : CategoriaExcluir(); break;
          case 5 : ProdutoListar(); break;
          case 6 : ProdutoInserir(); break;
          case 7 : ProdutoAtualizar(); break;
          case 8 : ProdutoExcluir(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("Bye.....");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Categoria - Listar");
    Console.WriteLine("2 - Categoria - Inserir");
    Console.WriteLine("3 - Categoria - Atualizar");
    Console.WriteLine("4 - Categoria - Excluir");
    Console.WriteLine("5 - Produto - Listar");
    Console.WriteLine("6 - Produto - Inserir");
    Console.WriteLine("7 - Produto - Atualizar");
    Console.WriteLine("8 - Produto - Excluir");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static void CategoriaListar() {
    Console.WriteLine("----- Lista de Categorias -----");
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0) {
      Console.WriteLine("Nenhuma categoria cadastrada");
      return;
    }
    foreach(Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }
  public static void CategoriaInserir() {
    Console.WriteLine("----- Inserção de Categorias -----");
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Inserção da categoria
    ncategoria.Inserir(c);
  }
  public static void CategoriaAtualizar() {
    Console.WriteLine("----- Atualização de Categorias -----");
    CategoriaListar();
    Console.Write("Informe o código da categoria a ser atulizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Inserção da categoria
    ncategoria.Atualizar(c);
  }
  public static void CategoriaExcluir() {
    Console.WriteLine("----- Exclusão de Categorias -----");
    CategoriaListar();
    Console.Write("Informe o código da categoria a ser excluida: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar a categoria com esse id
    Categoria c = ncategoria.Listar(id);
    // Exclui a categoria do cadastro
    ncategoria.Excluir(c);
  }
  public static void ProdutoListar() {
    Console.WriteLine("----- Lista de Produtos -----");
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0) {
      Console.WriteLine("Nenhum produto cadastrado");
      return;
    }
    foreach(Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();  
  }
  public static void ProdutoInserir() {
    Console.WriteLine("----- Inserção de Produtos -----");
    Console.Write("Informe um código para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do produto: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("Informe o código da categoria do produto: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Seleciona a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);    
    // Instanciar a classe de Produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    // Inserção da produto
    nproduto.Inserir(p);
  }
  public static void ProdutoAtualizar() {
    Console.WriteLine("----- Atualização de Produtos -----");
    ProdutoListar();
    Console.Write("Informe o código do produto a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do produto: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("Informe o código da categoria do produto: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Seleciona a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);    
    // Instanciar a classe de Produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    // Atualizar o produto
    nproduto.Atualizar(p);
  }
  public static void ProdutoExcluir() {
    Console.WriteLine("----- Exclusão de Produtos -----");
    ProdutoListar();
    Console.Write("Informe o código do produto a ser excluido: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o porduto com esse id
    Produto p = nproduto.Listar(id);
    // Exclui a categoria do cadastro
    nproduto.Excluir(p);
  }
}
