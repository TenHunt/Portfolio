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
using System.Globalization; // For capitalization
using System.IO;

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
            lblOutput.Text = "";
        }

        private void btnCapitalize_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            string title = txtTitle.Text;
            string[] words = title.Split(' ');

            StreamReader inputFile = File.OpenText("lowercase.txt"); // Open lowercase.txt

            int i = 0;
            string[] lowercaseWords = new string[20];
            while(!inputFile.EndOfStream)
            {
                lowercaseWords[i] = inputFile.ReadLine();
                i++;
            }
            inputFile.Close(); // Close lowercase.txt

            try
            {
                bool firstWord = true;

                foreach (string word in words)
                {
                    string lowercaseWord = word.ToLower();

                    if (lowercaseWords.Contains(lowercaseWord))
                    {
                        if (firstWord)
                        {
                            if (word[0] == '"')
                            {
                                lblOutput.Text += "\"" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                            }
                            else if (word[0] == '\'')
                            {
                                lblOutput.Text += "\'" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                            }
                            else
                            {
                                lblOutput.Text += char.ToUpper(word[0]) + word.Substring(1) + " ";
                            }
                        }
                        else
                        {
                            lblOutput.Text += lowercaseWord + " "; // Match found, keep it lowercase
                        }
                    }
                    else
                    {
                        if (word[0] == '"')
                        {
                            lblOutput.Text += "\"" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                        }
                        else if (word[0] == '\'')
                        {
                            lblOutput.Text += "\'" + char.ToUpper(word[1]) + word.Substring(2) + " ";
                        }
                        else
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
            lstPrevious.Items.Add(lblOutput.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            lblOutput.Text = "";
            txtTitle.Focus();
        }
    }
}
