using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spotify
{
    /// <summary>
    /// Interaktionslogik für AddSong.xaml
    /// </summary>
    public partial class AddSong : Window
    {
       internal static List<Song> Songs = new List<Song>();
        public AddSong()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DateTime date = new DateTime();
            Tryagain.Visibility = Visibility.Visible;
            
            string word = Timetextbox1.Text;
            string[] words = word.Split(':');
            try
            {
                int hour = Convert.ToInt16(words[0]);
            int minute = Convert.ToInt16(words[1]);
            int second = Convert.ToInt16(words[2]) + (minute*60) + (hour * 60 * 60);
                TimeSpan duration = TimeSpan.FromSeconds(second);
                Tryagain.Content = second;

                //Save(Nametextbox.Text, Artisttextbox.Text, Albumtextbox.Text, duration);
            }
            catch (Exception)
            {
                Tryagain.Visibility = Visibility.Visible;
            }
        }
        /*
        public static void Save(string sname, string sartist, string salbum, TimeSpan tim)
        {
            Songs.Add(new Song(sname, sartist, salbum, tim));
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(Songs, options);
            using (StreamWriter stream = new StreamWriter(@"C:\Users\nikol\OneDrive\Desktop\School\3CHELhome\FSST\2. Semester\emomullet\Spotify\Spotify\bin\Debug\Songs.json", true))
            {
                // Write the data to the file
                stream.WriteLine(jsonString);
            }
        }
        */
        private void ClearBoxes_Click(object sender, RoutedEventArgs e)
        {
            Nametextbox.Clear();
            Artisttextbox.Clear();
            Albumtextbox.Clear();
            Timetextbox1.Clear();
        }

        private void Closebutton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
