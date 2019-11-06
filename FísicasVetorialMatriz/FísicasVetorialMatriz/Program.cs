using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FísicasVetorialMatriz
{
    class Program
    {
        class MassaAtuante
        {
            public string formato { get; set; }
            public int velocidadeX { get; set; }
            public int velocidadeY { get; set; }
            public int[] Posicao { get; set; }
            public MassaAtuante(string a, int b, int c,int[] d)    
            {
                this.formato = a;
                this.velocidadeX = b;
                this.velocidadeY = c;
                this.Posicao = d;
            }
            static void PrintarMatrizBi(string[,] a, List<MassaAtuante> Massas)
            {
                //atuação das forças
                for (int i = 0; i < Massas.Count; i++)
                {
                    //definindo o objeto no espaço
                    a[Massas[i].Posicao[0], Massas[i].Posicao[1]] = Massas[i].formato ;
                    //deslocando o objeto no espaço
                    if (Massas[i].velocidadeX != 0)
                    {
                        a[Massas[i].Posicao[0], Massas[i].Posicao[1]] = Massas[i].formato;
                        Massas[i].Posicao[1] = Massas[i].Posicao[1] + Massas[i].velocidadeX;
                    }
                }
                //printando a matriz
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] == null)
                            a[i, j] = ".";
                        Console.Write(" {0} ", a[i, j]);
                    }
                }
                System.Threading.Thread.Sleep(200);
                Console.Clear();

            }
            static void Main(string[] args)
            {
                string[,] espacoMundial = new string[20, 30];
                List<MassaAtuante> massas = new List<MassaAtuante>();
                MassaAtuante bola = new MassaAtuante("#", 1, 0,new int[] {0,0});
                massas.Add(bola);
                while (true)
                    PrintarMatrizBi(espacoMundial, massas);
            }

        }
    }
}