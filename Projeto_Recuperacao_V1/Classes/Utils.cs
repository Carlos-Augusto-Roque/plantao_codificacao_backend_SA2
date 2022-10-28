namespace Recuperacao_Backend_UC9_SA2.Classes
{
    //classe estática, os métodos aqui dentro não devem ser instanciados
    //dentro de outra classe, apenas chamado quando quisermos utilizado
    static class Utils
    {
        //método para verificar se existe um caminho pasta + arquivo
        public static void VerificarPastaArquivo(string caminho)
        {
            //variável que armazena a primeira posição do caminho = pasta
            string pasta = caminho.Split("/")[0];

            //se não existir um diretório nessa posição
            if (!Directory.Exists(pasta))
            {
                //então criamos um diretório nessa posição
                Directory.CreateDirectory(pasta);
            }

            //se não existir um arquivo nesse caminho
            if (!File.Exists(caminho))
            {
                //então criamos um arquivo
                using(File.Create(caminho)){}
            }
        }
    }
}

//Caminho = "Database/PessoaJuridica.csv"