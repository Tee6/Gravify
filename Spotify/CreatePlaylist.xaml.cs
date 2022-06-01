using Newtonsoft.Json;
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
        internal static List<Playlist> playlists;
        public CreatePlaylist()
        {
            InitializeComponent();
            playlists = LoadSongsFromJson(@"C:\playlists.json");

        }

        static List<Playlist> LoadSongsFromJson(string path)
        {
            //Pfad wird gesucht und Objekte aus dem JSON File werden in die Songs Liste übergeben
            string json = File.ReadAllText(path);
            playlists = JsonConvert.DeserializeObject<List<Playlist>>(json);
            return playlists;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Song> playlist = new List<Song>();
            playlists.Add(new Playlist(nameplayllist.Text, descrplaylist.Text, playlist));

            string jsonString = System.Text.Json.JsonSerializer.Serialize(playlists);
            File.WriteAllText(@"C:\playlists.json", jsonString);
        }






































        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameplayllist.Text;
            string desc = descrplaylist.Text;
            List<Song> playlistnull = new List<Song>();

            list.Add(new Playlist(name, desc, playlistnull));
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(@"C:\Users\nikol\OneDrive\Desktop\School\3CHELhome\FSST\2. Semester\emomullet\Spotify\Spotify\bin\Debug\playlists.json", json);
        }
        */
    }
}
