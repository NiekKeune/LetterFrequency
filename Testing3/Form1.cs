using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterFrequency
{
    public partial class Form1 : Form
    {
        string placeholder = "";                        //Creates an empty string which will be worked with later.
        int count = 0;                                  //Variable which will contain how many letters there are in the document.

        public void OpeningAndCounting()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;

            //Opening files seems to only work on notepad files, or rather .txt files. It's even possible to read pictures, and word documents get even stranger.

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            placeholder = openFileDialog1.FileName;         //Gets the Directory of the file.
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not read the file from the disk.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                StreamReader reader = new StreamReader(placeholder, Encoding.UTF8);
            StringBuilder fileContents = new StringBuilder();       //StringBuilder where the text of the document will be saved.
            while (reader.Peek() != -1)         //Reads through the entire document.
            {
                fileContents.Append((char)reader.Read());
            }

            string data = fileContents.ToString();      //Converts the StringBuilder variable to a string so it can be looped.

            reader.Close();

            foreach (char letter in data)               //Goes through the string.
            {
                if (char.IsLetter(letter))              //Checks if its a letter and not a character.
                {
                    count++;                            //Adds 1 to the count variable if it's a letter.
                }
            }
            }
            catch(ArgumentException)    //Catches an exception when the user doesnt select a file and closes the window, since the program will try to work with a null file then.
            {
                MessageBox.Show("It's not possible to work with an empty file, please make sure to select a file next time.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void CountLetters_Click(object sender, EventArgs e)
        {
            OpeningAndCounting();               //Goes to the opening and counting method when the button is pressed.
            string result = count.ToString();   //Converts int count to string result variable so that the textBox can display it.
            if (count == 1)                     //Determines which message to send depending if the file has 1 letter or not.
            {
                textBox1.Text = "This file contains " + result + " letter.";   //Textbox displays the result.
            }
            else
            {
                textBox1.Text = "This file contains " + result + " letters.";  //Textbox displays the result.
            }
            count = 0;                                                         //Count resetted to 0 so the counting method doesnt add up if the button is pressed again.
        }
    }
}
