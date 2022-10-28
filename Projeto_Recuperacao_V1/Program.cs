using Recuperacao_Backend_UC9_SA2.Classes;

Console.Clear();//Método Clear para limpar tudo que estiver antes desse ponto
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(@"
===========================================================
|            Bem vindo ao sistema de cadastro de          |
|                Pessoas Jurídicas                        |
===========================================================
");
Console.ResetColor();

string? opcao;// atribuição de variável que armazenará a opção escolhida do próximo menu de opções 

do //estrutura de repetição dowhile - executará o laço enquanto a condição for verdadeira
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
===========================================================
|                Escolha uma das opções abaixo            |
|---------------------------------------------------------|
|                  1 - Cadastrar Pessoa Jurídica          |
|                  2 - Listar Pessoas Jurídica            |
|                                                         |
|                  0 - Sair                               |
|                                                         |
|                                                         |
===========================================================
");
    Console.ResetColor();
    opcao = Console.ReadLine();//armazenaremos aqui a opção escolhida pelo usuário

    PessoaJuridica metodosPj = new PessoaJuridica();//instanciamos um objeto para manipular os métodos

    switch (opcao)//vamos comparar o valor armazenado em opcao e para cada opcao vamos realizar uma ação
    {
        case "1":

            //criação dos objetos 
            PessoaJuridica novaPessoaJuridica = new PessoaJuridica();

            //entrada e armazenamento dos dados
            Console.WriteLine($"Digite o nome fantasia da empresa: ");
            novaPessoaJuridica.Nome = Console.ReadLine();

            bool valido;//variável booleana para armazenar o resultado da validação do método validar Cnpj
            do//enquanto o cnpj digitado for inválido, vamos pedir que o usuário digite outro cnpj
            {
                Console.WriteLine($"Digite um Cnpj válido ex: XX.XXX.XXX/0001-XX ou XXXXXXXX0001XX: ");
                novaPessoaJuridica.Cnpj = Console.ReadLine();
                valido = metodosPj.ValidarCnpj(novaPessoaJuridica.Cnpj!);

            } while (valido == false);

            Console.WriteLine($"Digite o rendimento mensal da empresa: ");
            novaPessoaJuridica.Rendimento = float.Parse(Console.ReadLine()!);

            //chamada do método para inserir os dados de novaPessoaJuridica dentro de um arquivo csv
            metodosPj.Inserir(novaPessoaJuridica);

            break;
        case "2":

            //chamada para listar os itens salvos dentro do csv
            List<PessoaJuridica> listaPj = metodosPj.LerArquivo();

            foreach (PessoaJuridica cadaItem in listaPj)//percorrer o csv e trazer os dados no console
            {
                Console.WriteLine(@$"
                    Nome Fantasia : {cadaItem.Nome}
                    Cnpj : {cadaItem.Cnpj}
                    Rendimento : {cadaItem.Rendimento}            
                    ");
                Console.WriteLine($"Aperte ENTER para continuar");
                Console.ReadLine();
            }
            break;

        case "0"://caso seja 0 a opção, vamos sair do sistema
            break;

        default://caso não seja nenhuma opção do menu, vamos trazer uma mensagem para o usuário
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Opção inválida, escolha outra opção !");
            Console.ResetColor();
            Thread.Sleep(3000);
            break;
    }

} while (opcao != "0");//condição para o laço se repetir = enquanto a opção for diferente de 0