using System;
using System.Collections.Generic;

class NCliente {
  private NCliente() { }
  static NCliente obj = new NCliente();
  public static NCliente Singleton { get => obj; }

  private List<Cliente> clientes = new List<Cliente>();

  public void Abrir() {
    Arquivo<List<Cliente>> f = new Arquivo<List<Cliente>>();
    clientes = f.Abrir("./clientes.xml");
  }

  public void Salvar() {
    Arquivo<List<Cliente>> f = new Arquivo<List<Cliente>>();
    f.Salvar("./clientes.xml", Listar());
  }


  public List<Cliente> Listar() {
    // Retorna uma listas com os clientes cadastrados
    clientes.Sort();
    return clientes;
  }

  public Cliente Listar(int id) {
    // Localiza na lista o cliente com o id informado
    for (int i = 0; i < clientes.Count; i++)
      if (clientes[i].Id == id) return clientes[i];
    return null;  
  }

  public void Inserir(Cliente c) {
    // Gera o id do cliente
    int max = 0;
    foreach(Cliente obj in clientes)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    // Insere o cliente na lista
    clientes.Add(c);
  } 

  public void Atualizar(Cliente c) {
    // Localiza na lista o cliente que possui o id informado no parametro c
    Cliente c_atual = Listar(c.Id);
    // Se não encontrar o cliente com o Id, retorna sem alterar
    if (c_atual == null) return;
    // Altera os dados do cliente
    c_atual.Nome = c.Nome;
    c_atual.Nascimento = c.Nascimento;
  } 

  public void Excluir(Cliente c) {
    // Remove o cliente da lista
    if (c != null) clientes.Remove(c);
  } 
}
