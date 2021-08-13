using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass {
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();
  private static NCliente ncliente = new NCliente();
  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int op = 0;
    Console.WriteLine ("----- Aplicativo de Vendas ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1  : CategoriaListar(); break;
          case 2  : CategoriaInserir(); break;
          case 3  : CategoriaAtualizar(); break;
          case 4  : CategoriaExcluir(); break;
          case 5  : ProdutoListar(); break;
          case 6  : ProdutoInserir(); break;
          case 7  : ProdutoAtualizar(); break;
          case 8  : ProdutoExcluir(); break;
          case 9  : ClienteListar(); break;
          case 10 : ClienteInserir(); break;
          case 11 : ClienteAtualizar(); break;
          case 12 : ClienteExcluir(); break;
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
    Console.WriteLine("01 - Categoria - Listar");
    Console.WriteLine("02 - Categoria - Inserir");
    Console.WriteLine("03 - Categoria - Atualizar");
    Console.WriteLine("04 - Categoria - Excluir");
    Console.WriteLine("05 - Produto - Listar");
    Console.WriteLine("06 - Produto - Inserir");
    Console.WriteLine("07 - Produto - Atualizar");
    Console.WriteLine("08 - Produto - Excluir");
    Console.WriteLine("09 - Cliente - Listar");
    Console.WriteLine("10 - Cliente - Inserir");
    Console.WriteLine("11 - Cliente - Atualizar");
    Console.WriteLine("12 - Cliente - Excluir");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static void CategoriaListar() {
    Console.WriteLine("----- Lista de Categorias -----");
    // Lista as categorias
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
    // Instancia a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Insere a categoria
    ncategoria.Inserir(c);
  }
  public static void CategoriaAtualizar() {
    Console.WriteLine("----- Atualização de Categorias -----");
    CategoriaListar();
    Console.Write("Informe o código da categoria a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instancia a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Atualiza a categoria
    ncategoria.Atualizar(c);
  }
  public static void CategoriaExcluir() {
    Console.WriteLine("----- Exclusão de Categorias -----");
    CategoriaListar();
    Console.Write("Informe o código da categoria a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    // Procura a categoria com esse id
    Categoria c = ncategoria.Listar(id);
    // Exclui a categoria do cadastro
    ncategoria.Excluir(c);
  }
  public static void ProdutoListar() {
    Console.WriteLine("----- Lista de Produtos -----");
    // Lista os produtos
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
    // Instancia a classe de Produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    // Insere o produto
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
    // Instancia a classe de Produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    // Atualiza o produto
    nproduto.Atualizar(p);
  }
  public static void ProdutoExcluir() {
    Console.WriteLine("----- Exclusão de Produtos -----");
    ProdutoListar();
    Console.Write("Informe o código do produto a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o produto com esse id
    Produto p = nproduto.Listar(id);
    // Exclui o produto
    nproduto.Excluir(p);
  }

  public static void ClienteListar() {
    Console.WriteLine("----- Lista de Clientes -----");
    // Lista os clientes
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach(Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void ClienteInserir() {
    Console.WriteLine("----- Inserção de Clientes -----");
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc };
    // Insere o cliente
    ncliente.Inserir(c);
  }

  public static void ClienteAtualizar() {
    Console.WriteLine("----- Atualização de Clientes -----");
    CategoriaListar();
    Console.Write("Informe o código do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Id = id, Nome = nome, Nascimento = nasc };
    // Atualiza o cliente
    ncliente.Atualizar(c);
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----- Exclusão de Clientes -----");
    CategoriaListar();
    Console.Write("Informe o código do cliente a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // Exclui o cliente do cadastro
    ncliente.Excluir(c);
  }

}
