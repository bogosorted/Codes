using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card
{
    class Program
    {
        class Deck
        {
            int quantidadeCartasDeck1;
            List<Card> mao = new List<Card>();
            public void Adicionar1(int id)
            {
                quantidadeCartasDeck1++;
            }           
        }
       class Card:Deck
        {
            float id,angulacaoMaxZ;
            int ataque,vida;
            string nome;
           
            public Card(float id)
            {               
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
            Deck segundo = new Deck();
        }
    }
}
