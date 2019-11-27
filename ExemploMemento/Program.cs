using System;
using System.Collections.Generic;
using System.Threading;

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
            #region Propiedades
            public string NomeArquivo
            {
                get { return _nomeArquivo; }
                set
                {
                    this._nomeArquivo = value;
                    this._dataModificacao = DateTime.Now;
                }
            }
            public string Diretorio
            {
                get { return _diretorio; }
                set
                {
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
            #endregion
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
                Console.WriteLine("__________________________________\n");
                Console.WriteLine("Data de modificação: {0} \nDiretório do arquivo : {1} \nNome do arquivo : {2} \nTexto do arquivo : {3} ", _dataModificacao, _diretorio, _nomeArquivo, _textoArquivo);
                Console.WriteLine("__________________________________\n");
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
            #region Propiedades
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
            #endregion

        }
        #endregion
        #region CareTaker
        class Github
        {
            private Stack<Commits> _mementos = new Stack<Commits>();
            public Commits CareTaker
            {
                get { return _mementos.Pop(); }
                set { _mementos.Push(value); }
            }
        }
        #endregion


        static void Main(string[] args)
        {
            Console.Title = "GitBash";

            File a = new File();
            Github b = new Github();
            //vs 1
            a.Diretorio = @"C:\Users\aluno\Object3D";
            a.NomeArquivo = "Musicas";
            a.Texto = "Eu curto rock balboa";

            a.ExibirInfo();
            //salvando vs 1
            b.CareTaker = a.SalvarCommits();
            //vs 2
            a.Diretorio = @"C:\Users\aluno\Object3D";
            a.NomeArquivo = "Maçã";
            a.Texto = "Maçã verde, cultivada em 1987 e mumificada pelo própio Isaaac Newton";

            a.ExibirInfo();
            //salvando vs 2
            b.CareTaker = a.SalvarCommits();
            //vs 3
            a.Diretorio = @"C:\Users\aluno\JogoPi";
            a.NomeArquivo = "Rodavort";
            a.Texto = "O melhor jogo do mundo?";
            a.ExibirInfo();
            //regredindo para vs 2
            a.VoltarCommits(b.CareTaker);
            a.ExibirInfo();
            //regredindo para vs 1
            a.VoltarCommits(b.CareTaker);
            a.ExibirInfo();
        }
    }
}
