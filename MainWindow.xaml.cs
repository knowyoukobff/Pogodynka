using System;
using System.Windows;
using System.Windows.Media;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PomiaryRzeszow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WriteData();
            
        }

        public ApiResponse airObj;
        public dynamic waterObj;

        private void GetJson()
        {
            WebClient client = new WebClient();
            string airCond = client.DownloadString("http://api.gios.gov.pl/pjp-api/rest/aqindex/getIndex/671");
            string waterCond = client.DownloadString("https://danepubliczne.imgw.pl/api/data/hydro/");
            airObj = JsonConvert.DeserializeObject<ApiResponse>(airCond);
            waterObj = JsonConvert.DeserializeObject<dynamic>(waterCond);          
        }

        private int stan;

        private void WriteData()
        {
            GetJson();
            stan = waterObj[526]["stan_wody"];

            if (airObj.so2IndexLevel?.indexLevelName != null)
            {
                if (airObj.so2IndexLevel.indexLevelName == "Bardzo dobry")
                {
                    SulfurDiox.Text = airObj.so2IndexLevel.indexLevelName;
                    SulfurDiox.Background = Brushes.Green;
                }
                else
                {
                    SulfurDiox.Text = airObj.so2IndexLevel.indexLevelName;
                    SulfurDiox.Background = Brushes.Lime;
                }

                }
            else
            {

                SulfurDiox.Text = "Brak aktualnych danych";
                SulfurDiox.Background = Brushes.Gray;
            }

            if(airObj.coIndexLevel?.indexLevelName != null)
            {

                if (airObj.coIndexLevel.indexLevelName == "Bardzo dobry")
                {
                    Carbon.Text = airObj.coIndexLevel.indexLevelName;
                    Carbon.Background = Brushes.Green;
                }
                else
                {
                    Carbon.Text = airObj.coIndexLevel.indexLevelName;
                    Carbon.Background = Brushes.Lime;
                }
            }
            else
            {
                Carbon.Text = "Brak aktualnych danych";
                Carbon.Background = Brushes.Gray;
            }



                if (airObj.o3IndexLevel.indexLevelName == "Bardzo dobry")
                {
                    NitrogenDiox.Text = airObj.o3IndexLevel.indexLevelName;
                    NitrogenDiox.Background = Brushes.Green;
                }
                else
                {
                    NitrogenDiox.Text = airObj.o3IndexLevel.indexLevelName;
                    NitrogenDiox.Background = Brushes.Lime;
                }

                if (airObj.pm10IndexLevel.indexLevelName == "Bardzo dobry")
                {
                    pm10.Text = airObj.pm10IndexLevel.indexLevelName;
                    pm10.Background = Brushes.Green;
                }
                else
                {
                    pm10.Text = airObj.pm10IndexLevel.indexLevelName;
                    pm10.Background = Brushes.Lime;
                }

            AlarmStateRiver(stan);
            water.Text += "Poziom wody w Wisloku: " + stan + " cm";
            AirTitle.Content += airObj.pm10SourceDataDate;
            WaterTitle.Content += airObj.pm10SourceDataDate;
        }
        
        private void AlarmStateRiver(int data)
        {
            if (data < 300)
            {
                water.Text += "";
                water.Background = Brushes.Lime;
            }
            else if(data >= 300 && data < 420)
            {
                water.Text += "Stan ostrzegawczy" + Environment.NewLine;
                water.Background = Brushes.Yellow;

            }
            else
            {
                water.Text += "Stan alarmowy!" + Environment.NewLine;
                water.Background = Brushes.Red;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "admin" && Password.Password == "admin")
            {
                Database.Visibility = Visibility.Visible;
                user.Text += Environment.NewLine + Environment.NewLine + "admin" + Environment.NewLine + "akowalski";
                pass.Text += Environment.NewLine + Environment.NewLine + "jHjHjuimNioUggC" + Environment.NewLine + "IUioJiHgtftrdrF";
                email.Text += Environment.NewLine + Environment.NewLine + "pomoc@pogodynka.pl" + Environment.NewLine + "akowalski@gmail.com";
            }
            logBorder.Height = 100;
            welcomePrompt.Visibility = Visibility.Visible;
            welcomePrompt.Content += Login.Text + "  [Wyloguj]";
            logLabel.Visibility = Visibility.Hidden;
            passLabel.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Hidden;
            logBtn.Visibility = Visibility.Hidden;
            Logowanie.Header = "Konto";
            history.Visibility = Visibility.Visible;
            infoLab.Visibility = Visibility.Hidden;
            signLoginLab.Visibility = Visibility.Hidden;
            signLogin.Visibility = Visibility.Hidden;
            signPassword.Visibility = Visibility.Hidden;
            signPasswordLab.Visibility = Visibility.Hidden;
            signEmailLab.Visibility = Visibility.Hidden;
            signEmail.Visibility = Visibility.Hidden;
            signBtn.Visibility = Visibility.Hidden;
            var dt = DateTime.Now;
            int day = dt.Day;
            int month = dt.Month;
            int days = day - 1;

            if (day < 10)
            {
                date.Text += "0" + day + "/" + "0" + month + Environment.NewLine;
            }
            else
            {
                date.Text += day + "/" + "0" + month + Environment.NewLine;
            }

            if (airObj.so2IndexLevel?.indexLevelName != null)
            {
                historySo2.Text = airObj.so2IndexLevel.indexLevelName + Environment.NewLine;
            }
            else
            {
                historySo2.Text = "N/A" + Environment.NewLine;
            }

            if (airObj.coIndexLevel?.indexLevelName != null)
            {
                historyCo.Text = airObj.coIndexLevel.indexLevelName + Environment.NewLine;
            }
            else
            {
                historyCo.Text = "N/A" + Environment.NewLine;
            }

            if (airObj.o3IndexLevel?.indexLevelName != null)
            {
                historyOz.Text = airObj.o3IndexLevel.indexLevelName + Environment.NewLine;
            }
            else
            {
                historyOz.Text = "N/A" + Environment.NewLine;
            }

            if (airObj.pm10IndexLevel?.indexLevelName != null)
            {
                histrypm10.Text = airObj.pm10IndexLevel.indexLevelName + Environment.NewLine;

            }
            else
            {
                histrypm10.Text = "N/A" + Environment.NewLine;
            }

            while (days > 0)
            {
                if (days < 10)
                {
                    date.Text += "0" + days + "/" + "0" + month + Environment.NewLine;
                    days--;
                }
                else
                {
                    date.Text += days + "/" + "0" + month + Environment.NewLine;
                    days--;
                }
                    if (days % 2 == 0)
                    {
                        historySo2.Text += "Bardzo dobry" + Environment.NewLine;
                        historyOz.Text += "Bardzo dobry" + Environment.NewLine;
                        historyCo.Text += "Dobry" + Environment.NewLine;
                        histrypm10.Text += "Dobry" + Environment.NewLine;
                    }
                    else
                    {
                        historySo2.Text += "Dobry" + Environment.NewLine;
                        historyOz.Text += "Dobry" + Environment.NewLine;
                        historyCo.Text += "Bardzo obry" + Environment.NewLine;
                        histrypm10.Text += "Bardzo dobry" + Environment.NewLine;
                    }                
            }
        }
    }
}


