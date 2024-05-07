/*
Author: Daniël De Jager
Date last updated: 03/10/2023
Name: Title Capitalizer
Desc: Takes titles and capitalizes them
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; // For string searching
using System.IO; // For file reading

namespace TitleCapitalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblOutput.Text = ""; // Make output label blank on load
        }

        private void btnCapitalize_Click(object sender, EventArgs e)
        {
            lblOutput.Text = ""; // Resets the label in case Clear button isn't clicked
            string title = txtTitle.Text; // Store the title entered in the textbox
            string[] words = title.Split(' '); // Splits the provided title into an array of words

            StreamReader inputFile = File.OpenText("lowercase.txt"); // Open lowercase.txt

            string[] lowercaseWords = new string[20]; // Assume there will be 20 or less lowercase words
            int i = 0;
            while (!inputFile.EndOfStream)
            {
                lowercaseWords[i] = inputFile.ReadLine(); // Get all the words from lowercase.txt into an array
                i++;
            }
            inputFile.Close(); // Close lowercase.txt

            try
            {
                bool firstWord = true;

                foreach (string word in words)
                {
                    string lowercaseWord = word.ToLower(); // Lowercase all the words for proper handling

                    if (lowercaseWords.Contains(lowercaseWord)) // If word is on lowercase list
                    {
                        if (firstWord) // First time always capitalize
                        {
                            if (word[0] == '"') // If "word'
                            {
                                lblOutput.Text += "\"" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                            }
                            else if (word[0] == '\'') // If 'word'
                            {
                                lblOutput.Text += "\'" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                            }
                            else // If no " or '
                            {
                                lblOutput.Text += char.ToUpper(word[0]) + word.Substring(1) + " ";
                            }
                        }
                        else // If not first time, keep lowercase
                        {
                            lblOutput.Text += lowercaseWord + " ";
                        }
                    }
                    else // If word is not on lowercase list
                    {
                        if (word[0] == '"') // If "word"
                        {
                            lblOutput.Text += "\"" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                        }
                        else if (word[0] == '\'') // If 'word'
                        {
                            lblOutput.Text += "\'" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                        }
                        else // If no " or '
                        {
                            lblOutput.Text += char.ToUpper(word[0]) + word.Substring(1) + " ";
                        }
                    }

                    firstWord = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lstPrevious.Items.Add(lblOutput.Text); // Title capitalizer history
        }

        private void btnReset_Click(object sender, EventArgs e) // Clears all except title capitalizer history
        {
            txtTitle.Text = "";
            lblOutput.Text = "";
            txtTitle.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstPrevious.Items.Clear();
        }
    }
}
