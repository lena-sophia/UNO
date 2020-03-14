using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uno
{
    public class Card
    {
        public String name;
        public String value;
        public int index;
        public String color;
        public String imgPath;

        //Konstruktor, aufrauf bei Kartenerstellung
        public Card(String n, String val, int i, String co, String path)
        {
            name = n;
            value = val;
            index = i;
            color = co;
            imgPath = path;
        }
    }
}