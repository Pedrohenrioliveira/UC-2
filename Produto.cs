using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Produto
    {
        internal object categoriaEscolhida;
        internal object fornecedorEscolhido;

        public string Nome { get; set; }
        public int CategoriaEscolhida { get; set; }
        public int FornecedorEscolhido { get; set; }
        //public double Preco { get; set; }
        public Categoria Categoria { get; set; }

        public Fornecedor Fornecedor { get; set; }


        public Produto(string nome, int categoriaEscolhida, int fornecedorEscolhido)
        {
            Nome = nome;
            CategoriaEscolhida = categoriaEscolhida;
            FornecedorEscolhido = fornecedorEscolhido;
        }


    }
}
