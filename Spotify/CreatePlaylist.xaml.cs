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
    /// Interaktionslogik für CreatePlaylist.xaml
    /// </summary>
    public partial class CreatePlaylist : Window
    {

        internal List<Playlist> list = new List<Playlist>();
        public CreatePlaylist()
        {
            InitializeComponent();

            //list = LoadStudentsFromJson(@"C:\Users\nikol\OneDrive\Desktop\School\3CHELhome\FSST\2. Semester\emomullet\Spotify\Spotify\bin\Debug\playlists.json");

        }
        private static List<Playlist> LoadStudentsFromJson(string path)
        {
            List<Playlist> students = null;
            // Load from file
            using (StreamReader stream = new StreamReader(path))
            {
                string serializedData = stream.ReadToEnd();
                // Deserialize the string into a student object
                students = JsonSerializer.Deserialize<List<Playlist>>(serializedData);
            }
            return students;
        }

        public static void SaveJsonToFile(string jsonString, string path)
        {
            // Open a new file stream to write into a text file
            using (StreamWriter stream = new StreamWriter(path, append: false))
            {
                // Write the data to the file
                stream.WriteLine(jsonString);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameplayllist.Text;
            string desc = descrplaylist.Text;

            list.Add(new Playlist(name, desc));
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(@"C:\Users\nikol\OneDrive\Desktop\School\3CHELhome\FSST\2. Semester\emomullet\Spotify\Spotify\bin\Debug\playlists.json", json);
        }
    }
}
