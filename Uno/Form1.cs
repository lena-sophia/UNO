using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uno
{
    public partial class Form1 : Form
    {
        //Spieler Array
        public Player[] player;
        //Stapel
        public Stack stack;
        //Das ist ein Array mit den Karten Buttons
        public List<Button>[] plButtons;
        //Welcher SPieler dran ist
        public int playerTurn;


        //Farbe wünschen Buttons
        public Button btnRed;
        public Button btnGreen;
        public Button btnYellow;
        public Button btnBlue;
        public String wishColor;

        public Form1()
        {
            InitializeComponent();
            // Form1 Vollbild öffnen
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
        }

        //Bereitet alles für ein neues Spiel vor
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            turn.Text = "Spieler 1 ist dran";
            wishColor = "0";
            //zwei Spieler anlegen und höhe der Kartenposition übergeben
            player = new Player[2];
            //383 und 553 sind Kartenhöhe
            player[0] = new Player();
            player[1] = new Player();

            //Buttons für Karten in zwei Listen anlegen
            plButtons = new List<Button>[2];
            plButtons[0] = new List<Button>();
            plButtons[1] = new List<Button>();

            //Stapel bilden
            stack = new Stack();

            //Farbe wünschen Buttons
            btnRed = new Button();
            btnRed.Text = "rot";
            btnRed.Location = new Point(300, 20);
            btnRed.Click += color_Click;
            btnGreen = new Button();
            btnGreen.Text = "gruen";
            btnGreen.Location = new Point(300, 60);
            btnGreen.Click += color_Click;
            btnYellow = new Button();
            btnYellow.Text = "gelb";
            btnYellow.Location = new Point(300, 100);
            btnYellow.Click += color_Click;
            btnBlue = new Button();
            btnBlue.Text = "blau";
            btnBlue.Location = new Point(300, 140);
            btnBlue.Click += color_Click;

            //Jeden Spieler sieben Karten ziehen lassen
            playerTurn = 1;
            for(int i = 0; i < 7; i++)
            {
                pullCard();
            }
            playerTurn = 0;
            for (int i = 0; i < 7; i++)
            {
                pullCard();
            }

            //erste Karte hinlegen
            //Zufallszahl initialisieren
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            //Hilfsvaribale
            Card firstCard;
            //Nur Zahlenkarte als erste Karte
            do
            {
                //Zufallszahl innerhalb Anzahl der Karten
                firstCard = stack.stackCards.ElementAt(rand.Next(stack.stackCards.Count));
            } while (firstCard.color == "schwarz" || firstCard.value == "Aussetzen" || firstCard.value == "Richtungswechsel" || firstCard.value == "ZweiZiehen");
            
            //Karte gilt nun als gespielt
            stack.playedCards.Add(firstCard);
            stack.stackCards.Remove(firstCard);

            //und die Tischkarte sieht nun so aus
            tableCard.BackgroundImage = Image.FromFile(firstCard.imgPath);
            tableCard.Size = tableCard.BackgroundImage.Size;
        }

        //Event-Handler merkt, welcher Button gedrückt wurde
        private void card_Click(object sender, EventArgs e)
        {
            //Hinweistext leeren
            alert.Text = "";

            //auslesen, welcher Button gedrückt wurde
            Button btn = (Button)sender;

            //Name des Buttons zu Zahl konvertieren
            int name = Convert.ToInt32(btn.Name);

            //Ist Kart gültig?
            if (player[playerTurn].possiblePush(name, stack.playedCards.Last(), wishColor))
            {
                //Falls eine Farbe gewünscht war, wird sie wieder auf 0 gesetzt
                wishColor = "0";

                //Button entfernen
                Controls.Remove(plButtons[playerTurn].ElementAt(name));
                //Button aus Liste entfernen
                plButtons[playerTurn].RemoveAt(name);
                //Alle Buttons neu sortieren
                buttonSort();
                //Aus Spieler Inventar entfernen und auf Tisch legen
                player[playerTurn].pushCard(name, ref stack.playedCards);

                //Hintergrund der Tischkarte festlegen
                tableCard.BackgroundImage = Image.FromFile(stack.playedCards.Last().imgPath);
                tableCard.Size = tableCard.BackgroundImage.Size;

                //Falls ein Spieler keine Karten mehr hat, hat er gewonnen
                if (player[playerTurn].myCards.Count == 0)
                {
                    turn.Text = "Spieler " + (playerTurn + 1).ToString() + " hat gewonnen!";
                }
                //Ansonsten wird Effekt der Karte ausgeführt (z.B. 2 ziehen)
                else
                {
                    //Wenn Karte nicht Aussetzen ist, dann ist nächster Spieler dran
                    if (stack.playedCards.Last().value != "Aussetzen")
                    {
                        if (playerTurn == 0)
                        {
                            playerTurn = 1;
                        }
                        else
                        {
                            playerTurn = 0;
                        }

                        //Label auf Spieler ändern, der nun dran ist
                        turn.Text = "Spieler " + (playerTurn + 1).ToString() + " ist dran";

                        //Effekte ausführen
                        if (stack.playedCards.Last().value == "ZweiZiehen")
                        {
                            pullCard();
                            pullCard();
                        }
                        else if (stack.playedCards.Last().value == "Wuenschen4")
                        {
                            pullCard();
                            pullCard();
                            pullCard();
                            pullCard();
                            wish();
                        }
                        else if (stack.playedCards.Last().value == "Wuenschen")
                        {
                            wish();
                        }
                    }
                }
            }
            else
            {
                alert.Text += "Diese Karte ist ungültig!";
            }
        }

        //Diese Methode wird aufgerufen, wenn ein Spieler eine Karte ziehen muss.
        private void pullCard()
        {
            //Wenn Stapel leer ist, gespielte Karten zum Stapel zurück
            if (stack.stackCards.Count == 0)
            {
                stack.playedCardsToStack();
            }

            //Methode des Spieler Objekts zum Kartenziehen. Übergabewerte: Kartenstapel aus dem er zieht, Buttons um gezogene anzuzeigen
            player[playerTurn].pullCard(ref stack, ref plButtons[playerTurn]);

            //Button verweist auf card_Click Methode (Eventhandler)
            plButtons[playerTurn].Last().Click += card_Click;

            //Buttons mit Location und Namen sortieren
            buttonSort();

            //Button wird zu Oberfläche hinzugefügt
            Controls.Add(plButtons[playerTurn].Last());
        }


        //Diese Methode sortiert die Button Namen nochmal. Wird aufgerufen, wenn eine Karte gezogen und gelegt wurde.
        public void buttonSort()
        {
            int x = 5;
            int y;
            if(playerTurn == 0)
            {
                y = 383;
            }
            else
            {
                y = 553;
            }
            //Für jeden Button den es noch gibt
            for(int i = 0; i < plButtons[playerTurn].Count; i++)
            {
                //Wird eine hochgezählte Zahl vergeben
                plButtons[playerTurn].ElementAt(i).Name = i.ToString();
                plButtons[playerTurn].ElementAt(i).Location = new System.Drawing.Point(x, y);
                x += 90;
            }
        }

        //Wenn eine Wünschen-Karte gelegt wird, setzt diese Funktion die Buttons dafür
        public void wish()
        {
            alert.Text = "Farbe wünschen!";
            Controls.Add(btnRed);
            Controls.Add(btnGreen);
            Controls.Add(btnYellow);
            Controls.Add(btnBlue);
        }

        //Wird aufgerufen, wenn eine Farbe gewünscht wird
        private void color_Click(object sender, EventArgs e)
        {
            //auslesen, welcher Button
            Button btn = (Button)sender;

            //Wunschfarbe wird gesetzt
            wishColor = btn.Text;
 
            //Buttons wieder ausblenden
            Controls.Remove(btnRed);
            Controls.Remove(btnGreen);
            Controls.Remove(btnYellow);
            Controls.Remove(btnBlue);

            alert.Text = wishColor + " ist die gewünschte Farbe";
        }

        private void btnNoChance(object sender, EventArgs e)
        {
            if (player[playerTurn].anythingPossible(stack.playedCards.Last(), wishColor))
            {
                alert.Text = "Es ist ein Zug möglich!";
            }
            else
            {
                alert.Text = "Du ziehst eine Karte";
                pullCard();
                if(playerTurn == 0)
                {
                    playerTurn = 1;
                }
                else
                {
                    playerTurn = 0;
                }
                turn.Text = "Spieler " + (playerTurn + 1).ToString() + " ist dran";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
