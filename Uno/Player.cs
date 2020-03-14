using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Uno
{
    public class Player
    {
        //Liste mit eigenen Karten
        public List<Card> myCards = new List<Card>();

        //Random Objekt für zufällig gezogene Karten
        private Random rand;
        private int tmp;
        

        //Konstruktor um Startwerte festzulegen
        public Player()
        {
            //erweiterter Zufallsgenerator, damit beide Spieler, die zur sleben Zeit angelegt werden, unterschiedliche Werte bekommen
            rand = new Random(Guid.NewGuid().GetHashCode());
        }

        //Karte ziehen
        public void pullCard(ref Stack stack, ref List<Button> myButtons)
        {
            //zufällige Zahl von Anzahl Karten auf dem Stapel
            tmp = rand.Next(stack.stackCards.Count);
            //Karte in eigene Karte kopieren
            myCards.Add(stack.stackCards.ElementAt(tmp));
            //Karte aus Stapel löschen
            stack.stackCards.RemoveAt(tmp);

            //Button für Karte anlegen
            String imgPath = myCards.Last().imgPath;
            myButtons.Add(new Button());
            myButtons.Last().Name = (myButtons.Count - 1).ToString();
            myButtons.Last().BackgroundImage = Image.FromFile(imgPath);
            myButtons.Last().BackgroundImageLayout = ImageLayout.Center;
            myButtons.Last().Size = myButtons.Last().BackgroundImage.Size;
        }

        //Karte ablegen
        public void pushCard(int pushedCard, ref List<Card> table)
        {
            //Karte wird auf Tisch gelegt
            table.Add(myCards.ElementAt(pushedCard));
            //Karte wird aus eigenen Karten entfernt
            myCards.RemoveAt(pushedCard);
        }

        //Prüft ob Zug gültig ist
        public bool possiblePush(int s, Card lastCard, String wish)
        {
            //legt eigene Karte an Stelle s an
            Card selected = myCards.ElementAt(s);

            //Prüft, ob Karte "selected" auf "lastCard" gelegt werden darf
            if(selected.color == "schwarz")
            {
                return true;
            }
            else if(selected.color == lastCard.color)
            {
                return true;
            }
            else if(selected.value == lastCard.value)
            {
                return true;
            }
            else if (selected.color == wish)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Wenn "Keine Karte möglich" Button gedrückt, prüft Methode ob irgendeine Karte möglich wäre
        public bool anythingPossible(Card lastCard, String wish)
        {
            //Führt possiblePush methode mit allen Karten aus
            for(int i = 0; i < myCards.Count; i++)
            {
                //bei erster möglich gültiger Karte gibt sie true zuück
                if(possiblePush(i, lastCard, wish))
                {
                    return true;
                }
            }
            //sonst läuft sie bis hier und gibt false zurück, also kein Zug möglich
            return false;
        }
    }
}
