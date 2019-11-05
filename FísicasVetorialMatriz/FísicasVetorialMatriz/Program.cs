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
     
            public string formato {get; set;}
            public int velocidadeX{get; set;}
            public int velocidadeY{get; set;}
            public MassaAtuante(string a, int b, int c)
            {
                this.formato = a;
                this.velocidadeX = b;
                this.velocidadeY = c;
            }
        }
        static void PrintarMatrizBi(string[,] a,List<MassaAtuante> Massas)
        {
            //atuação das forças
            for (int i = 0; i < Massas.Count; i++)
            {
            }
            //printando a matriz
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j <a.GetLength(1); j++)
                {
                    if (a[i, j] == null)
                        a[i, j] = ".";
                    Console.Write(" {0} ",a[i,j]);
                }
            }         
            System.Threading.Thread.Sleep(200);
            Console.Clear();

        }
        static void Main(string[] args)
        {
            string[,] espacoMundial = new string[20, 30];
            List<MassaAtuante> massas = new List<MassaAtuante>();
            MassaAtuante bola = new MassaAtuante("#", 0, 0);            
            massas.Add(bola);
            espacoMundial[10,10] = bola.formato;
            while(true)
            PrintarMatrizBi(espacoMundial,massas);
        }

    }
}
