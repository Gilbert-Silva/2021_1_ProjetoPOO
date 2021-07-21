using System;

class MainClass {
  public static void Main() {
    Categoria c1 = new Categoria(1, "Mouse");
    Categoria c2 = new Categoria(2, "Fonte");
    Console.WriteLine(c1);
    Console.WriteLine(c2);

    Produto p1 = new Produto(1, "Mouse Bluetooth", 10, 150, c1);
    Produto p2 = new Produto(2, "Mouse Usb", 15, 60, c1);
    Produto p3 = new Produto(3, "Fonte Atx", 20, 300, c2);
    Produto p4 = new Produto(4, "Teclado Usb", 20, 100);    
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);

    c1.ProdutoInserir(p1);
    c1.ProdutoInserir(p2);
    c2.ProdutoInserir(p3);

    Produto[] v = c1.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c1.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c2.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c2.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);
  }
}
