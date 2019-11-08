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
                public int Ataque {get; set;}
                public int Vida {get; set;}
                public string Nome {get; set;}
                
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
                Deck primeiro = new Deck();
                Card trova = new Card(0,primeiro);
                Deck segundo = new Deck();
                Card b = new Card(0, segundo);
                Card o = new Card(0, segundo);
               
            }
        }
    }
}
