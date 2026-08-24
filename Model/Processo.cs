using AppWebExemplo.Configs;
using AppWebExemplo.Models;
namespace AppWebExemplo.DAO
{
    public class ProcessoDAO
    {
        private readonly Conexao _conexao;

        public ProcessoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List Listar()
        {
            try
            {
                var lista = new List(0);
                //Buscando e abrindo a Conexão com o banco de dados
                using var con = _conexao.GetConnection();
                con.Open();

                string sql = "SELECT * FROM processos";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecutReader();

                while(leitor.Read())
                {
                    var processo = new Processo();
                    processo.Id = leitor.GetInt32("id_pro");
                    processo.Numero = leitor.GetString("numero_pro");
                    processo.Interessado = leitor.GetString("interessado_pro");
                    processo.Assunto = leitor.GetString("assunto_pro");
                    processo.Descricao = leitor.GetString("descricao_pro");
                    processo.situacao = leitor.GetString("situacao_pro");

                    lista.Add(processo);
                }





                return Listar();
            }
            catch
            {
                throw;
            }
        }
    }
}

