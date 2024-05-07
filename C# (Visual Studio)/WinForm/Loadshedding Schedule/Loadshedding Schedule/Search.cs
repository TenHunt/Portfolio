using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Text.RegularExpressions;
using System.Net.Http; // HTTP Get
using Newtonsoft.Json; // Reading JSON and stuff


namespace Loadshedding_Schedule
{
    public partial class Search : Form
    {
        public string area = "";
        public string latitude = "";
        public string longitude = "";
        public string closestArea = "";
        public string areaName = "";

        public Search()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;
            StringBuilder location = new StringBuilder("https://www.google.com/maps/search/");
            location.Append(query);
            webView.CoreWebView2.Navigate(location.ToString());
            await System.Threading.Tasks.Task.Delay(5000);
            //lblResult.Text = webView.Source.ToString();
            string coords = webView.Source.ToString();
            Regex regex = new Regex(@"@(-?\d+\.\d+),(-?\d+\.\d+)");
            Match match = regex.Match(coords);

            int count = 0;

            while(!match.Success && count < 10)
            {
                lblResult.Text = "Finding coordinates...";
                await System.Threading.Tasks.Task.Delay(2000);
                coords = webView.Source.ToString();
                regex = new Regex(@"@(-?\d+\.\d+),(-?\d+\.\d+)");
                match = regex.Match(coords);
                count++;
            }
            if (match.Success)
            {
                // The first group captures the latitude, and the second group captures the longitude
                latitude = match.Groups[1].Value;
                longitude = match.Groups[2].Value;

                // You can use these values as needed
                //lblResult.Text = $"Latitude: {latitude}, Longitude: {longitude}";
                lblResult.Text = $"Coordinates found!";
            }
            else
            {
                //lblResult.Text = "Coordinates not found in the URL";
                //MessageBox.Show(coords);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (latitude != "" && longitude != "")
            {
                btnSubmit.Text = "Please wait...";
                SearchArea();
            }
            else
            {
                MessageBox.Show("No coordinates found! Please try searching again.");
            }
        }

        private async void SearchArea()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://developer.sepush.co.za/business/2.0/areas_nearby?lat={latitude}&lon={longitude}";

                    Form1 myForm = new Form1();
                    client.DefaultRequestHeaders.Add("token", myForm.token);

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseBody);

                    // Accessing the first event in the response
                    dynamic areas = data.areas;
                    if (areas == null || areas.Count == 0)
                    {
                        throw new InvalidOperationException("No area information found in the response.");
                    }

                    closestArea = areas[0].id;
                    areaName = areas[0].name;
                    //MessageBox.Show(closestArea);
                    await System.Threading.Tasks.Task.Delay(2000);
                    this.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
