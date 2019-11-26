using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication43
{
    class Program
    {
        #region Originator
        class File
        {
            private string _nomeArquivo;
            private string _textoArquivo;
            private string _diretorio;

            public string NomeArquivo
            {
                get { return _nomeArquivo;  }
                set { this._nomeArquivo = value; Console.WriteLine(" Alterado às : {0} \n Nome Arquivo: {1}, ",DateTime.Now,value); }
            }
            
        }
        #endregion
        #region Memento
        class Commits
        {
        }
        #endregion
        #region CareTaker
        class Github { }
        #endregion


        static void Main(string[] args)
        {
            File a = new File();
            a.NomeArquivo = "hehe";          
        }
    }
}
