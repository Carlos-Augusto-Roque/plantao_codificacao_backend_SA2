namespace Recuperacao_Backend_UC9_SA2.Classes
{
    //classe pessoa juridica herda da classe abstrata
    public class PessoaJuridica : Pessoa
    {
        //propriedades da classe pessoa jurídica
        public string? Cnpj { get; set; }
        public string Caminho { get; private set; } = "Database/PessoaJuridica.csv";

        //método para validar cnpj
        //58.337.365/0001-56
        //58337365000156
        public bool ValidarCnpj(string cnpj)//retorno booleano, com um cnpj como argumento
        {
            //se o comprimento dessa string(cnpj) for igual á 18 
            if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11, 4) == "0001")//e se na posição 11,4 estiver escrito "0001"
                    {
                        return true;//retorna verdadeiro
                    }
                }
                else if (cnpj.Length == 14)//senão, se esse comprimento for igual a 14
                {
                    if (cnpj.Substring(8, 4) == "0001")//e se na posição 8,4 estiver escrito "0001"
                    {
                        return true;//retorne verdadeiro
                    }
                }
            return false;//caso contrário retorne falso
        }       

        // método para inserir uma pessoa juridica em um arquivo csv       
        public void Inserir(PessoaJuridica pj)
        {
            //chamada do método para verificar se o caminho já existe, ou seja a pasta e o arquivo
            Utils.VerificarPastaArquivo(Caminho);

            //criado um array de strings que recebe o objeto transformado em strings, ou seja, em partes
            //feito dessa maneira pq o método que vai inserir os dados espera receber um array de strings 
            //padrão que será salvo dentro do arquivo           
            string[] pjStrings = { $"{pj.Nome}, {pj.Cnpj}, {pj.Rendimento}" };

            //metodo que salva o conteúdo dentro do arquivo
            //AppendAllLines = método que vai inserir todas as linhas dentro do arquivo 
            File.AppendAllLines(Caminho, pjStrings);
        }

        // método para listar os itens do arquivo csv
        public List<PessoaJuridica> LerArquivo()
        {
            //criado uma lista para armazenar os itens lidos no csv
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            //criado um array de strings onde será armazenados os itens dentro do csv
            string[] linhas = File.ReadAllLines(Caminho);

            //criado um foreach para leitura de cada item do array "linhas"
            foreach (string cadaLinha in linhas)
            {
                //array para armazenar os atributos do objeto, ou seja, vamos pegar o padrão e separar onde tem uma vírgula
                string[] atributos = cadaLinha.Split(",");

                //criamos um objeto para atribuir os valores lidos nele
                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.Nome = atributos[0];
                cadaPj.Cnpj = atributos[1];
                cadaPj.Rendimento = float.Parse(atributos[2]);
                
                listaPj.Add(cadaPj);
            }
            return listaPj;
        }        
    }
}