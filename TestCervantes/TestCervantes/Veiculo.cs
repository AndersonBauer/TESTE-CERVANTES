using System;
using System.Collections.Generic;
using System.Text;

namespace TestCervantes
{
    public abstract class Veiculo
    {
        public Veiculo(int codigo, string placa, string modelo, int ano, int marcaCodigo, string tipo)
        {
            Codigo = codigo;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            MarcaCodigo = marcaCodigo;
            Tipo = tipo;
        }

        public int Codigo { get;  private set; }
        public string Placa { get;  private set; }
        public string Modelo { get;  private set; }
        public int Ano { get;  private set; }
        public int MarcaCodigo { get; private set; }
        public string Tipo { get; private set; }
    }
    
}
