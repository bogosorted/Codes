using System.Collections.Generic;

namespace card
{
    class Program
    {
        class Deck
        {
            List<Card> mao = new List<Card>();

            public Card Carta
            {
                get { return Carta; }
                set { mao.Add(value);}
            }
            public int GetTamanhoBaralho()
            {
                return mao.Count;
            }
            public class Card : Deck
            {
                float id, angulacaoMaxZ;
                public int ataque {get; set;}
                public int vida {get; set;}
                public string nome {get; set;}
                
                public Card(float id, Deck a)
                {
                    a.Carta = this;
                    this.id = id;
                    switch (id)
                    {
                        case 0:
                            this.nome = "Trovador";
                            this.ataque = 15;
                            this.vida = 13;
                            break;
                    }
                }
            }
            static void Main(string[] args)
            {
                Deck primeiro = new Deck();
                Card trova = new Card(0,primeiro);
                System.Console.WriteLine(primeiro.GetTamanhoBaralho());
                Deck segundo = new Deck();
                Card b = new Card(0, segundo);
                Card o = new Card(0, segundo);
                System.Console.WriteLine(segundo.GetTamanhoBaralho());
                System.Console.WriteLine("ataque : " + segundo.mao[0].ataque);
            }
        }
    }
}
