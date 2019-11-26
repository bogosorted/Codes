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
                Console.WriteLine("Salvando versão...");
                return new Commits(_dataModificacao, _nomeArquivo, _textoArquivo, _diretorio);
            }
            public void VoltarCommits(Commits a)
            {
                Console.WriteLine("Regredindo versão...");
                this._nomeArquivo = a.NomeArquivo;
                this._diretorio = a.Diretorio;
                this._textoArquivo = a.Texto;
            }
            public void ExibirInfo()
            {
                Console.WriteLine( "Data de modificação: {0}",_dataModificacao);
                //Console.WriteLine( "Nome do arquivo")
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
            public string NomeArquivo
            {
                get { return _nomeArquivo; }
            }
            public string Diretorio
            {
                get { return _diretorio; }
            }
            public string Texto
            {
                get { return _textoArquivo; }

            }

        }
        #endregion
        #region CareTaker
        class Github
        {
            private Stack<Commits> _mementos = new Stack<Commits>();
            public Commits CareTaker
            { get{ return _mementos.Pop(); }
              set {_mementos.Push(value); } }
        }
        #endregion


        static void Main(string[] args)
        {
            File a = new File();
            a.Diretorio = @"c";
            a.NomeArquivo = "Musicas";
            a.Texto = "Eu curto rock balboa";
          
            Github b = new Github();
            b.CareTaker = a.SalvarCommits();

            a.Diretorio = @"C:\Users\aluno\Object3D";
            a.NomeArquivo = "Maçã";
            a.Texto = "Maçã verde, cultivada em 1987 e mumificada pelo própio Isaaac Newton";

            b.CareTaker = a.SalvarCommits();

        }
    }
}
