using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_CS_SQL_SERVER
{
    public class Log
    {
        static string pastausuario = Environment.GetEnvironmentVariable("HOMEPATH");
        string diretorio = pastausuario + @"\Documents\";
        string nomePasta = "LOG";//nome da pasta
        string nomeArquivo = "log.txt";// nome do arquivo


        public Log()
        {

        }
        public void criar(string log)
        {
            FileInfo file = new FileInfo(diretorio + "\\" + nomePasta);
            if (file.Exists)
            {
                StreamWriter arquivo = new StreamWriter(diretorio + "\\" + nomePasta + "\\" + nomeArquivo, true);
                arquivo.WriteLine(log + " " + DateTime.Now.ToString());
                arquivo.Close();
            }
            else
            {
                DirectoryInfo raiz = new DirectoryInfo(diretorio);
                raiz.CreateSubdirectory(nomePasta);
                StreamWriter arquivo = new StreamWriter(diretorio + "\\" + nomePasta + "\\" + nomeArquivo, true);
                arquivo.WriteLine(log + " " + DateTime.Now.ToString());
                arquivo.Close();
            }
        }
    }
}
