using Microsoft.Win32;
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
        string picPath = "";
        static List<Playlist> LoadSongsFromJson(string path)
        {
            //Pfad wird gesucht und Objekte aus dem JSON File werden in die Songs Liste übergeben
            string json = File.ReadAllText(path);
            playlists = JsonConvert.DeserializeObject<List<Playlist>>(json);
            return playlists;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameplaylist.Text;
            string desc = descrplaylist.Text;

            List<Song> playlist = new List<Song>();
            playlists.Add(new Playlist(name,desc, playlist, picPath));

            string jsonString = System.Text.Json.JsonSerializer.Serialize(playlists);
            File.WriteAllText(@"C:\playlists.json", jsonString);


        }
        private void nameplaylist_Click(object sender, EventArgs e)
        {
            nameplaylist.Clear();
        }

        private void descrplaylist_Click(object sender, EventArgs e)
        {
            descrplaylist.Clear();
        }

        private void ImportPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == true)
            {
                icon.Source = new BitmapImage(new Uri(op.FileName));
            }
            icon.Width = 185;
            CanvasPic.OpacityMask = Brushes.Black;
        }
    }
}
