using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_CS_SQL_SERVER
{
    public class Cadastrar
    {
        ConexaoSql conexao = new ConexaoSql();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";
        public Cadastrar(string nome, string telefone)
        {
            //comando SQL  -- insert, update, delete -- SqlComand
            cmd.CommandText = "insert into ex (nome,telefone) values (@nome, @telefone)"; // o cmd está recebendo o comado a executar na tabela ex

            // parametros
            cmd.Parameters.AddWithValue("@nome", nome); // o cmd está recebendo os parâmetros e substituindo na string
            cmd.Parameters.AddWithValue("@telefone", telefone); // o cmd está recebendo os parâmetros e substituindo na string


            try
            {
                // conectar com o banco de dados -- conexão
                cmd.Connection = conexao.conectar(); // o cmd está recebendo a conexão
                //executar o comando
                cmd.ExecuteNonQuery(); // envia o comando para o banco de dados
                // desconectar com o banco de dados -- conexao
                conexao.desconectar();
                // mostrar mensagem de erro ou sucesso -- string mensagem
                this.mensagem = "Cadastrado com Sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao tentar se conectar com o banco de dados";
            }

        }

    }
}
