using System;

class MainClass {
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
  }
  public static void CategoriaInserir() {
    Console.WriteLine("----- Inserção de Categorias -----");
  }
}
