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
            static void PrintarMatrizBi(string[,] a, List<MassaAtuante> Massas, ref int frames)
            {
                //atuação das forças
                for (int i = 0; i < Massas.Count; i++)
                {
                    //definindo o objeto no espaço
                    a[Massas[i].Posicao[0], Massas[i].Posicao[1]] = Massas[i].formato ;
                    //deslocando o objeto no espaço
                    if (Massas[i].Posicao[1] + Massas[i].velocidadeX >= a.GetLength(1) || Massas[i].Posicao[1] + Massas[i].velocidadeX < 0)
                        Massas[i].velocidadeX = -Massas[i].velocidadeX;
                    if (Massas[i].Posicao[0] + Massas[i].velocidadeY >= a.GetLength(0) || Massas[i].Posicao[0] + Massas[i].velocidadeY < 0)
                        Massas[i].velocidadeY = -Massas[i].velocidadeY;
                    if (Massas[i].velocidadeX != 0 || Massas[i].velocidadeY !=0)
                    {                     
                        Massas[i].Posicao[1] = Massas[i].Posicao[1] + Massas[i].velocidadeX;
                        Massas[i].Posicao[0] = Massas[i].Posicao[0] + Massas[i].velocidadeY;
                        a[Massas[i].Posicao[0], Massas[i].Posicao[1]] = Massas[i].formato;
                        a[Massas[i].Posicao[0] - Massas[i].velocidadeY,Massas[i].Posicao[1] - Massas[i].velocidadeX] =null;
                    }
                    //Leis Universais                 
                }
                //printando a matriz
                Console.WriteLine(" 1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26  27  28  29 30");
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    Console.WriteLine();
                    if (i + 1 >=10)
                    Console.Write(i +1 +" ");
                    else
                    {
                        Console.Write(i + 1 +"  ");
                    }
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                       
                        if (a[i, j] == null)
                            a[i, j] = ".";
                        //cannot use switch
                        else {
                            switch (a[i, j]) {
                                case "#":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case "@":
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case "+":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                            }                       
                        }
                        Console.Write(" {0} ", a[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    
                }
                frames++;
                Console.WriteLine("\t\t\t\t\t\t\t\t frames " + frames);
                System.Threading.Thread.Sleep(500);
                Console.Clear();

            }
            static void Main(string[] args)
            {
                int frames = 0;
                string[,] espacoMundial = new string[20, 30];
                List<MassaAtuante> massas = new List<MassaAtuante>();
                MassaAtuante bola = new MassaAtuante("#", 1, 1,new int[] {0,0});
                MassaAtuante Pedra = new MassaAtuante("@", 2, 3, new int[] { 5, 5 });
                MassaAtuante poeira = new MassaAtuante("+", 4, 1, new int[] { 4, 5 });
            
                massas.Add(bola);
                massas.Add(Pedra);
             //   massas.Add(triangulo);
                massas.Add(poeira);
              //  massas.Add(seila);
                while (true)
                    PrintarMatrizBi(espacoMundial, massas,ref frames);
            }

        }
    }
}