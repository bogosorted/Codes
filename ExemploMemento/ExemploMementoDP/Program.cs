using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication43
{
    class Program
    {
        #region Originator
        class Arquivo
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
            public void ExibirInfo()
            {
                Console.WriteLine("__________________________________\n");
                Console.WriteLine("Data de modificação: {0} \nDiretório do arquivo : {1} \nNome do arquivo : {2} \nTexto do arquivo : {3} ", _dataModificacao, _diretorio, _nomeArquivo, _textoArquivo);
                Console.WriteLine("__________________________________\n");
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

            String userNome = Environment.UserName;
            String computadorNome = Environment.MachineName;
            String[] matrizAuxiliar = Environment.CurrentDirectory.Split(Char.Parse(@"\"));
            String pathPadrao = matrizAuxiliar[0] + @"\" + matrizAuxiliar[1] + @"\" + matrizAuxiliar[2] + @"\";
            String path = pathPadrao;
            String input;
            Arquivo a = new Arquivo();
            Github b = new Github();
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}@{1} ", userNome, computadorNome);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("MINGW{0} ", Environment.Is64BitOperatingSystem ? "64" : "32");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(path == pathPadrao ? "~" : path);
                Console.ResetColor();
                Console.Write("$ ");
                input = Console.ReadLine();
                try
                {
                    switch (input.Substring(0, 3))
                    {
                        case "cd ":
                            if (Directory.Exists(path + @input.Substring(3)))
                            {
                                a.Diretorio = path + @input.Substring(3);
                                path = a.Diretorio;
                            }
                            else
                            {
                                Console.WriteLine("Este Caminho não existe");
                            }
                            goto default;
                        case "git":
                            switch (input.Substring(4))
                            {
                                case "commit -m":
                                    b.CareTaker = a.SalvarCommits();
                                    break;
                                case "checkout":
                                    a.VoltarCommits(b.CareTaker);
                                    break;
                                case "alterar1":
                                    a.NomeArquivo = "Rodavort";
                                    a.Texto = "NOVIDADES EM BREVE";
                                    a.Diretorio = path + "Rodavort";
                                    break;
                                case "alterar2":
                                    a.NomeArquivo = "Mabara";
                                    a.Texto = "JOGO SOBRE VIDA MAARINHA";
                                    a.Diretorio = path + "Mabara";
                                    break;
                                case "alterar3":
                                    a.NomeArquivo = "Alunos";
                                    a.Texto = "Lista de Alunos: Lila Maria, Gabriel Aragão, Gabriel Dias, Janderson Ferreira, Eduardo frans";
                                    a.Diretorio = path + "ListaAlunos";
                                    break;
                                case "alterar4":
                                    a.NomeArquivo = "Celeste";
                                    a.Texto = "jogo divertido";
                                    a.Diretorio = path + "celeste";
                                    break;
                                case "info":
                                    a.ExibirInfo();
                                    break;
                            }
                            goto default;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }

                catch (Exception)
                {
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}


