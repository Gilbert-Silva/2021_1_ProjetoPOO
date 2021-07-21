using System;

class MainClass {
  private static NCategoria ncategoria = new NCategoria();
  public static void Main() {
    int op = 0;
    Console.WriteLine ("----- Aplicativo de Vendas ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : CategoriaListar(); break;
          case 2 : CategoriaInserir(); break;
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
}
