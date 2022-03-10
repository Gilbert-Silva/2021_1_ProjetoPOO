using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

class MainClass {
  private static NCategoria ncategoria = NCategoria.Singleton;
  private static NProduto nproduto = NProduto.Singleton;
  private static NCliente ncliente = NCliente.Singleton;
  private static NVenda nvenda = NVenda.Singleton;

  private static Cliente clienteLogin = null;
  private static Venda clienteVenda = null;

  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    try {
      ncategoria.Abrir();
      nproduto.Abrir();
      ncliente.Abrir();
      nvenda.Abrir();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }

    int op = 0;
    int perfil = 0;
    Console.WriteLine ("----- Aplicativo de Vendas ------");
    do {
      try {
        if (perfil == 0) {
          op = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1) {
          op = MenuVendedor();
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
            case 13 : VendaListar(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin == null) {
          op = MenuClienteLogin();
          switch(op) {
            case 1  : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null) {
          op = MenuClienteLogout();
          switch(op) {
            case 1  : ClienteVendaListar(); break;
            case 2  : ClienteProdutoListar(); break;
            case 3  : ClienteProdutoInserir(); break;
            case 4  : ClienteCarrinhoVisualizar(); break;
            case 5  : ClienteCarrinhoLimpar(); break;
            case 6  : ClienteCarrinhoComprar(); break;
            case 99 : ClienteLogout(); break;
          }
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    try {
      ncategoria.Salvar();
      nproduto.Salvar();
      ncliente.Salvar();
      nvenda.Salvar();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }
    Console.WriteLine ("Bye.....");    
  }
  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Vendedor");
    Console.WriteLine("2 - Entrar como Cliente");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static int MenuVendedor() {
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
    Console.WriteLine("13 - Venda   - Listar");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static int MenuClienteLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome);
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Listar minhas compras");
    Console.WriteLine("02 - Listar produtos");
    Console.WriteLine("03 - Inserir um produto no carrinho");
    Console.WriteLine("04 - Visualizar o carrinho");
    Console.WriteLine("05 - Limpar o carrinho");
    Console.WriteLine("06 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
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
  public static void VendaListar() { 
    Console.WriteLine("----- Lista de Vendas -----");
    // Listar as vendas cadastradas
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma venda cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();

    var r1 = vs.Select(v => new {
      MesAno = v.Data.Month + "/" + v.Data.Year,
      Total  = v.Itens.Sum(vi => vi.Qtd * vi.Preco)
    });

    foreach(var item in r1) Console.WriteLine(item);
    Console.WriteLine();

    var r2 = r1.GroupBy(item => item.MesAno,
      (key, items) => new {
        MesAno = key,
        Total = items.Sum(item => item.Total) });

    foreach(var item in r2) Console.WriteLine(item);
    Console.WriteLine();
  }

  public static void ClienteLogin() { 
    Console.WriteLine("----- Login do Cliente -----");
    ClienteListar();
    Console.Write("Informe o código do cliente para logar: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    clienteLogin = ncliente.Listar(id);
    // Abre o carrinho de compra do cliente
    clienteVenda = nvenda.ListarCarrinho(clienteLogin);
  }
  public static void ClienteLogout() { 
    Console.WriteLine("----- Logout do Cliente -----");
    if (clienteVenda != null) nvenda.Inserir(clienteVenda, true);
    // Faz o logout do cliente
    clienteLogin = null;
    clienteVenda = null;
  }
  public static void ClienteVendaListar() { 
    Console.WriteLine("----- Minhas Compras -----");
    // Listar as vendas do cliente
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma compra cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();
  }
  public static void ClienteProdutoListar() { 
    // Lista os produtos cadastrados no sistema
    ProdutoListar();
  }
  public static void ClienteProdutoInserir() { 
    // Lista os produtos cadastrados no sistema
    ProdutoListar();
    Console.Write("Informe o código do produto a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    // Procurar o produto pelo id
    Produto p = nproduto.Listar(id);
    // Verifica se o produto foi localizado
    if (p != null) {
      // Verifica se já existe um carrinho
      if (clienteVenda == null)
        clienteVenda = new Venda(DateTime.Now, clienteLogin);
      // Insere o produto no carrinho
      nvenda.ItemInserir(clienteVenda, qtd, p);  
    }
  }
  public static void ClienteCarrinhoVisualizar() { 
    // Verificar se existe um carrinho
    if (clienteVenda == null) {
      Console.WriteLine("Nenhum produto no carrinho");
      return;
    }
    // Lista os produtos no carrinho
    List<VendaItem> itens = nvenda.ItemListar(clienteVenda);
    foreach(VendaItem item in itens) Console.WriteLine(item);
    Console.WriteLine();
  }
  public static void ClienteCarrinhoLimpar() { 
    // Verificar se existe um carrinho
    if (clienteVenda != null)
      nvenda.ItemExcluir(clienteVenda);
  }
  public static void ClienteCarrinhoComprar() { 
    // Verificar se existe um carrinho
    if (clienteVenda == null) {
      Console.WriteLine("Nenhum produto no carrinho");
      return;
    }
    // Salva a compra do cliente
    nvenda.Inserir(clienteVenda, false);
    // Inicia um novo carrinho
    clienteVenda = null;
  }

}
