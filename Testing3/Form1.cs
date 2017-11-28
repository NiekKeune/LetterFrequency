using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterFrequency
{
    public partial class Form1 : Form
    {
        string placeholder = "A sïmple русский 한글또는조선글은 test";  //test string to work with, tests different letters than the standard alphabet
        int count = 0;                                                //variable which will count how many letters there are

        public void Counting()
        {
            foreach (char letter in placeholder)                      //goes through the string
            {
                if (char.IsLetter(letter))                            //checks if its a letter and not a character
                {
                    count++;                                          //adds a number to the count variable
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            List<String> letters = new List<String>();                      //test list to visualize how I want it to look
            letters.Add("a");
            letters.Add("B");
            letters.Add("µ");
            letters.Add("ð");

            textBox1.Text = String.Join(Environment.NewLine, letters);
        }

        public string displayMembers(List<String> letters)
        {
            foreach (String s in letters)
            {
                return s.ToString();
            }
            return null;
        }

        private void CountLetters_Click(object sender, EventArgs e)
        {
            Counting();                                             //goes to the counting method when the button is pressed
            string result = count.ToString();                       //converts int count to string result variable
            textBox1.Text = result;                                 //textbox displays the result
            count = 0;                                              //count resetted to 0 so the counting method doesnt add up if the button is pressed again
        }

    }
}
