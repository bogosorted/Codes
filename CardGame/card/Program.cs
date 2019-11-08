using System.Collections.Generic;
using System;

namespace card
{
    class Program
    {
        class Deck
        {
            float angulacaoMaxZ;

            List<Card> mao = new List<Card>();
            public Deck(float z)
            {
                this.angulacaoMaxZ = z;
            }
            
            public Card Carta
            {
                get { return Carta; }
                set { mao.Add(value); }
            }
            public int GetTamanhoBaralho()
            {
                return mao.Count;
            }
            public float SetarAngulacao(List<Card> a)
            {
             for (float i = 0; i < a.Count; i++)
                 {
                    a[i].Angulacao = a.Count % 2 == 0 ? angulacaoMaxZ / (float)(a.Count / 2) : angulacaoMaxZ / (float)((a.Count - 1) / 2);
                 }              
            }

        }
        class Card
        {
            float id;
            public int Angulacao { get; set; }
            public int Ataque { get; set; }
            public int Vida { get; set; }
            public string Nome { get; set; }

            public Card(float id, Deck a)
            {
                a.Carta = this;
                this.id = id;
                switch (id)
                {
                    case 0:
                        this.Nome = "Trovador";
                        this.Ataque = 15;
                        this.Vida = 13;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Deck primeiro = new Deck(3);
            Deck segundo = new Deck(3);
            int zM = 3;
            int quantidCart = 17;
         /*   float angulação = quantidCart % 2 == 0f ? zM /(float)(quantidCart / 2) : zM / (float)((quantidCart - 1) / 2);
            for (float i = -zM; i <= zM;)
            {               
                Console.WriteLine(i);
                i += angulação;
                if (quantidCart % 2 == 0 && i == 0)
                    i += angulação;
            }
            */
            
        }       
    }
}
