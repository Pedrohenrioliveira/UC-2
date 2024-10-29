namespace POO
{
    internal class Program
    {
        public class Ecommerce
        {
            private const int LIMITE = 30;
            private List<Categoria> categorias = new List<Categoria>();
            private List<Fornecedor> fornecedores = new List<Fornecedor>();
            private List<Produto> produtos = new List<Produto>();

            public void Executar()
            {
                int opcao = 0;

                do
                {
                    Console.WriteLine("BEM VINDO AO MEU ERP DE VENDAS DE CELULARES");
                    Separador('=', 100);
                    Console.WriteLine("CADASTRO GERAL DO SISTEMA");
                    Console.WriteLine("(1) - Cadastro de Categorias");
                    Console.WriteLine("(2) - Cadastro de Fornecedores");
                    Console.WriteLine("(3) - Cadastro de Produtos");
                    Console.WriteLine("(4) - Listar Categorias");
                    Console.WriteLine("(5) - Listar Fornecedores");
                    Console.WriteLine("(6) - Listar Produtos");
                    Console.WriteLine("(0) - Sair");
                    Separador('_', 100);

                    Console.WriteLine("Digite sua opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            CadastrarCategoria();
                            break;
                        case 2:
                            CadastrarFornecedor();
                            break;
                        case 3:
                            CadastrarProduto();
                            break;
                        case 4:
                            ListarCategorias();
                            break;
                        case 5:
                            ListarFornecedores();
                            break;
                        case 6:
                            ListarProdutos();
                            break;
                        case 0:
                            Console.WriteLine("Saindo do sistema. Até logo!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                } while (opcao != 0);
            }

            private void Separador(char simbolo, int quantidade)
            {
                Console.WriteLine(new string(simbolo, quantidade));
            }

            private void CadastrarCategoria()
            {
                if (categorias.Count < LIMITE)
                {
                    Console.WriteLine("Digite o nome da nova categoria (ex: Smartphones, Acessórios, etc.): ");
                    string nome = Console.ReadLine();
                    categorias.Add(new Categoria(nome));
                    Console.WriteLine("Categoria cadastrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Limite de categorias atingido!");
                }
            }

            private void CadastrarFornecedor()
            {
                if (fornecedores.Count < LIMITE)
                {
                    Console.WriteLine("Digite o nome do fornecedor (ex: Samsung, Apple, Xiaomi): ");
                    string nome = Console.ReadLine();
                    fornecedores.Add(new Fornecedor(nome));
                    Console.WriteLine("Fornecedor cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Limite de fornecedores atingido!");
                }
            }

            private void CadastrarProduto()
            {
                if (produtos.Count < LIMITE)
                {
                    Console.WriteLine("Digite o nome do produto (ex: iPhone 13, Galaxy S21): ");
                    string nome = Console.ReadLine();

                    ListarCategorias();
                    Console.WriteLine("Digite o número da categoria: ");
                    int categoriaEscolhida = int.Parse(Console.ReadLine()) -1;

                    ListarFornecedores();
                    Console.WriteLine("Digite o número do fornecedor: ");
                    int fornecedorEscolhido = int.Parse(Console.ReadLine()) -1;

                    var produto = new Produto(nome, categoriaEscolhida, fornecedorEscolhido);

                    
                    foreach (var cat in categorias)
                    {
                        if (categoriaEscolhida == cat.Id)
                        {
                            produto.Categoria = new Categoria(cat.Nome);
                        }                        
                    }

                    foreach (var fornecedor in fornecedores)
                    {
                        if (fornecedorEscolhido == fornecedor.Id)
                        {
                            produto.Fornecedor = new Fornecedor(fornecedor.Nome);
                        }
                    }

                    produtos.Add(produto);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Limite de produtos atingido!");
                }
            }

            private void ListarCategorias()
            {
                if (categorias.Count > 0)
                {
                    Console.WriteLine("CATEGORIAS CADASTRADAS: ");
                    for (int i = 0; i < categorias.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {categorias[i].Nome}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhuma categoria cadastrada.");
                }
            }

            private void ListarFornecedores()
            {
                if (fornecedores.Count > 0)
                {
                    Console.WriteLine("FORNECEDORES CADASTRADOS:");
                    for (int i = 0; i < fornecedores.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {fornecedores[i].Nome}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum fornecedor cadastrado.");
                }
            }

            private void ListarProdutos()
            {
                if (produtos.Count > 0)
                {
                    Console.WriteLine("PRODUTOS CADASTRADOS: ");
                    foreach (var produto in produtos)
                    {

                        Console.WriteLine($"Produto: {produto.Nome}, Categoria: {produto.Categoria.Nome}, Fornecedor: {produto.Fornecedor.Nome}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
            }

            static void Main(string[] args)
            {
                var sistema = new Ecommerce();
                sistema.Executar();
            }
        }
    }
}
