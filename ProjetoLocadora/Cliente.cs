public class Cliente : Pessoa, IEntidade {
    public Cliente(string nome, string cpf) : base(nome, cpf) { }

    public void Exibir() {
        Console.WriteLine($"Cliente: {Nome}, CPF: {Cpf}");
    }

    public static new Cliente FromString(string linha) {
        var partes = linha.Split(';');
        return new Cliente(partes[0], partes[1]);
    }
}
