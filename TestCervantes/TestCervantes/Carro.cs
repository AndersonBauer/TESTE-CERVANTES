using System;
using System.Collections.Generic;
using System.Text;

namespace TestCervantes
{
    public class Carro : Veiculo
    {
        public Carro(int codigo, string placa, string modelo, int ano, int marcaCodigo ) : base(codigo, placa, modelo, ano, marcaCodigo, "CARRO") { }
    }
}
