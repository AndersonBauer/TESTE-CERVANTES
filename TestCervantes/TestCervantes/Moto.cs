using System;
using System.Collections.Generic;
using System.Text;

namespace TestCervantes
{
    public class Moto : Veiculo
    {
        public Moto(int codigo, string placa, string modelo, int ano, int marcaCodigo) : base(codigo, placa, modelo, ano, marcaCodigo, "MOTO") { }
    }
}
