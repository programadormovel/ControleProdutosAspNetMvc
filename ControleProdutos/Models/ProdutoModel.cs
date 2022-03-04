using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutos.Models
{
    public class ProdutoModel
    {
        public Int64 Id { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public string DataDeValidade { get; set; }
        public string DataDeRegistro { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public string NomeDaFoto { get; set; }
        public byte[] Foto { get; set; }
        public bool Ativo { get; set; }
    }
}
