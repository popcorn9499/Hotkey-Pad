using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Hotkey_Pad
{
    class ColorHandler
    {
        public static string convertRGBA(string data)
        {//fix my formatting for rgba. 
            string[] rgbArray = data.Split(',');
            rgbArray[3] = (double.Parse(rgbArray[3]) / 255).ToString();
            return string.Join(",", rgbArray);
        }

        public static string CheckRGBA(string rgb)
        {
            string[] rgbArray = rgb.Split(',');
            if (rgbArray.Count() != 4)
            {
                MessageBox.Show("Please use correct RGBA");
                throw new InvalidRGBAColor();
            }

            for (int i = 0; i < 3; i++)
            {
                int x;
                if (!int.TryParse(rgbArray[i], out x)) //check the r g b values
                {
                    MessageBox.Show("Please use sets of integers!");
                    throw new InvalidRGBAColor();
                }
                if (x > 255 || x < 0)
                {
                    MessageBox.Show("The numbers must be from 0 to 255");
                    throw new InvalidRGBAColor();
                }
            }
            double y;
            if (!double.TryParse(rgbArray[3], out y))
            {
                MessageBox.Show("Please use a float for the alpha value!");
                throw new InvalidRGBAColor();
            }
            if (y < 0.0 | y > 1.0)
            {
                MessageBox.Show("Please keep this number between 0 and 1");
                throw new InvalidRGBAColor();
            }

            rgbArray[3] = ((int)double.Parse(rgbArray[3]) * 255).ToString();

            return string.Join(",", rgbArray);
        }

        public class InvalidRGBAColor : Exception
        {
            public InvalidRGBAColor() : base() { }
        }

        public static Brush generateBrush(string rgbString)
        {
            byte R = 0, G = 0, B = 0, A = 0;
            string[] rgbStringList = rgbString.Split(',');
            R = (byte)int.Parse(rgbStringList[0]);
            G = (byte)int.Parse(rgbStringList[1]);
            B = (byte)int.Parse(rgbStringList[2]);
            A = (byte)int.Parse(rgbStringList[3]);
            Brush payload = new SolidColorBrush(Color.FromArgb(A, R, G, B));
            return payload;
        }
    }
}
