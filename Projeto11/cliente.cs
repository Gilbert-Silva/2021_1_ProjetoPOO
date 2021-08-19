using System;

class Cliente : IComparable<Cliente> {
  // Propriedade do Cliente
  public int Id { get; set; }
  public string Nome { get; set; }
  public DateTime Nascimento { get; set; }
  public int CompareTo(Cliente obj) {
    return this.Nome.CompareTo(obj.Nome);
  }
  public override string ToString() {
    return Id + " - " + Nome + " - " + Nascimento.ToString("dd/MM/yyyy");
  }
}
