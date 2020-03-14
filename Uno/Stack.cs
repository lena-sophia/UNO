using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    public class Stack
    { 
        //Das ist der Bilder Pfad
        private static String imgPath = "C:\\Users\\Sophia\\Desktop\\Karten\\";
        //Kartenstapel
        public List<Card> stackCards = new List<Card>();
        //Karten auf dem Tisch; gespielt wurden
        public List<Card> playedCards = new List<Card>();
        //Rückseite der Karte
        public String CardBack = imgPath + "back.png";
        
        //Konstruktor, wenn Stack angelegt wird
        public Stack()
        {
            //Hilfsvariablen
            String[] colors = { "rot", "blau", "gelb", "gruen" };
            String[] special = { "Aussetzen", "Richtungswechsel", "ZweiZiehen" };
            String[] black = { "Wuenschen", "Wuenschen4" };
            String path;
            //alle Karten die es gibt anlegen

            //für alle vier Farben
            for(int color = 0; color < 4; color++)
            {
                //Karten von 0 bis 9
                for(int i = 0; i < 10; i++)
                {
                    //jede Karte gibt es doppelt
                    for(int j = 0; j < 2; j++)
                    {
                        path = imgPath + colors[color] + "_" + i.ToString() + ".png";
                        stackCards.Add(new Card(colors[color] + i.ToString() + j.ToString(), i.ToString(), j, colors[color], path));
                    }
                }
                //spezielle Karten mit Farbe
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 2; j++)
                    {
                        path = imgPath + colors[color] + "_" + special[i] + ".png";
                        stackCards.Add(new Card(colors[color] + i.ToString() + j.ToString(), special[i], j, colors[color], path));
                    }
                }
                //schwarze Karten
                for(int i = 0; i < 2; i++)
                {
                    path = imgPath + black[i] + ".png";
                    stackCards.Add(new Card(black[i] + colors.ToString(), black[i], color, "schwarz", path));
                }
            }
        }

        //Wenn der Stapel leer ist, werden die gespielten Karten auf den Stapel gelegt
        public void playedCardsToStack()
        {
            stackCards = playedCards;
            playedCards.Clear();
        }
    }
}