using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http; // HTTP Get
using Newtonsoft.Json; // Reading JSON and stuff
using Microsoft.Win32.TaskScheduler; // Integration with Task Scheduler

namespace Loadshedding_Schedule
{
    public partial class Form1 : Form
    {
        private string token = "D2B65230-E1304BAF-9C78EA86-551AE189"; // My token
        private string areaId = "eskme-11-worcesterbreedevalleywesterncape"; // My area
        private bool trigger = false;
        private string start = "";
        private string end = "";


        public Form1()
        {
            InitializeComponent();
            InitializeNotifyIcon();
        }

        private async void CheckLoadshedding()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url;
                    bool test = false;
                    string testParam = "";

                    if(radCurrent.Checked)
                    {
                        test = true;
                        testParam = "current";
                    }
                    else if(radFuture.Checked)
                    {
                        test = true;
                        testParam = "future";
                    }

                    if (test)
                    {
                        url = $"https://developer.sepush.co.za/business/2.0/area?id={areaId}&test={testParam}";
                    }
                    else
                    {
                        url = $"https://developer.sepush.co.za/business/2.0/area?id={areaId}";
                    }
                    client.DefaultRequestHeaders.Add("token", token);

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseBody);

                    // Accessing the first event in the response
                    dynamic events = data.events;
                    if (events == null || events.Count == 0)
                    {
                        throw new InvalidOperationException("No events found in the response.");
                    }

                    dynamic firstEvent = events[0]; // First loadshedding slot
                    DateTime start_time = DateTime.Parse((firstEvent.start).ToString()); // Start of next loadshedding slot
                    DateTime end_time = DateTime.Parse((firstEvent.end).ToString()); // End of next loadshedding slot
                    start = start_time.ToString("HH:mm tt");
                    end = end_time.ToString("HH:mm tt");

                    // THROWS INDEX OUT OF RANGE ERROR
                    //dynamic secondEvent = events[1]; // Second loadshedding slot
                    //DateTime start_time2 = DateTime.Parse((secondEvent.start).ToString()); // Start of second loadshedding slot
                    //DateTime end_time2 = DateTime.Parse((secondEvent.end).ToString()); // End of second loadshedding slot

                    // Calculate the notification time
                    //int offset = 15;
                    //if (txtOffset.Text != "")
                    //{
                    //    int.TryParse(txtOffset.Text, out offset);
                    //}
                    //DateTime notificationTime = start_time - TimeSpan.FromMinutes(offset);

                    DateTime currentTime = DateTime.Now; // Current time

                    if (currentTime >= start_time && !trigger) // If loadshedding is now
                    {
                        MessageBox.Show($"Loadshedding is happening now from {start_time.ToString("HH:mm tt")} to {end_time.ToString("HH:mm tt")}. ");
                    }
                    else if (!trigger) // If loadshedding is in future
                    {
                        MessageBox.Show($"Loadshedding begins at {start_time.ToString("HH:mm tt")}.");
                        //TimeSpan timeDifference = notificationTime - currentTime;
                        //int timeBeforeNotification = (int)Math.Round(timeDifference.TotalMinutes);
                        //if(timeBeforeNotification < 0) // If the time for notification was in the past
                        //{
                        //
                        //}
                        //string timeOutput = $"{timeBeforeNotification}";
                        //if (timeBeforeNotification > 60)
                        //{
                        //    timeOutput = $"{(timeBeforeNotification / 60)} hours and {(timeBeforeNotification % 60)}";
                        //}
                        //MessageBox.Show($"Loadshedding begins at {start_time.ToString("HH:mm")}. Notification will be sent in {timeOutput} minutes (at {notificationTime.ToString("HH:mm")}).");
                    }
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckLoadshedding();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                TaskDefinition td = TaskService.Instance.NewTask();
                td.RegistrationInfo.Description = "Checks loadshedding schedule and notifies as set.";
                td.Principal.LogonType = TaskLogonType.InteractiveToken;

                DailyTrigger dt = (DailyTrigger)td.Triggers.Add(new DailyTrigger(1)); // Runs every day

                DateTime beginSchedule = DateTime.Today;
                double duration = 24.0;
                double interval = 0.5;
                if (!DateTime.TryParse(txtStartTime.Text, out beginSchedule))
                {
                    beginSchedule = DateTime.Today; // Defaults to begin at midnight
                }
                if (!double.TryParse(txtDuration.Text, out duration) || duration <= 1.0 || duration >= 24.0)
                {
                    duration = 24.0; // Default to 24 hours (entire day)
                }
                if (!double.TryParse(txtInterval.Text, out interval) || interval < 0.0 || interval > 2.0)
                {
                    interval = 0.5; // Default to ever half hour
                }
                dt.StartBoundary = beginSchedule;
                dt.Repetition.Duration = TimeSpan.FromHours(duration);
                dt.Repetition.Interval = TimeSpan.FromHours(interval);
                //td.Triggers.Add(new WeeklyTrigger {StartBoundary = DateTime.Today, DaysOfWeek = DaysOfTheWeek.Monday});

                // Add an action that will launch Loadshedding schedule with /check whenever the trigger fires
                string filePath = Application.ExecutablePath; // Finds location of exe to launch when triggered
                td.Actions.Add(new ExecAction("Loadshedding Schedule.exe", "/check", filePath)); 

                const string taskName = "Loadshedding Schedule Notifier";
                TaskService.Instance.RootFolder.RegisterTaskDefinition(taskName, td);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show($"COM Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
   
    private async void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            if(args.Length > 1 && args[1] == "/check") // If launched with command line argument
            {
                trigger = true; // Was triggered using command line or scheduler (used by CheckLoadshedding)
                CheckLoadshedding(); // Check for loadshedding
                await System.Threading.Tasks.Task.Delay(2000); // Waits 2 seconds for GET
                notifyIcon.Visible = true; // Weird workaround to not have a persistent icon in the system tray
                notifyIcon.ShowBalloonTip(5000, "Loadshedding", $"Starting {start} and ending {end}.", ToolTipIcon.Info); // Show next loadshedding slot
                notifyIcon.Visible = false; // Weird workaround to not have a persistent icon in the system tray
                this.Close(); // Close the form
            }
        }

        private NotifyIcon notifyIcon;
        private void InitializeNotifyIcon() // Initializes the notification
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Text = "Loadshedding Schedule", // Text must be above "Visible = false" for name to display correctly
                Visible = false
            };
        }
    }
}
