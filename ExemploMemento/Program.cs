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
            private DateTime _dataModificacao;
            private string _nomeArquivo;
            private string _textoArquivo;
            private string _diretorio;

            public string NomeArquivo
            {
                get { return _nomeArquivo; }
                set {
                    this._nomeArquivo = value;
                    this._dataModificacao = DateTime.Now;
                }
            }
            public string Diretorio
            {
                get { return _diretorio; }
                set {
                    this._diretorio = value;
                    this._dataModificacao = DateTime.Now;
                }
            }
            public string Texto
            {
                get { return _textoArquivo; }
                set
                {
                    this._textoArquivo = value;
                    this._dataModificacao = DateTime.Now;
                }
            }
            public Commits SalvarCommits()
            {
                return new Commits(_dataModificacao, _nomeArquivo, _textoArquivo, _diretorio);
            }
        }
        #endregion
        #region Memento
        class Commits
        {
            DateTime dataModificacao;
            private string _nomeArquivo;
            private string _textoArquivo;
            private string _diretorio;

            public Commits(DateTime a, string b, string c, string d)
            {
                this.dataModificacao = a;
                this._nomeArquivo = b;
                this._textoArquivo = c;
                this._diretorio = d;
            }           
        }
        #endregion
        #region CareTaker
        class Github
        {
            private Stack<Commits> _mementos;
            public Commits CareTaker { get{ return _mementos.Pop(); } set { _mementos.Push(value); } }
        }
        #endregion


        static void Main(string[] args)
        {
            File a = new File();
            a.Diretorio = @"C:\Users\aluno\Music";
            a.NomeArquivo = "Musicas";
            a.Texto = "Eu curto rock balboa";
          
            Github b = new Github();
            b.CareTaker = a.SalvarCommits();
        }
    }
}
