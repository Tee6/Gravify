using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Spotify
{
    public partial class MainWindow : Window
    {

        //internal List damit man im ganzen Programm nur eine Liste hat für alle Songs und Playlists
        internal static List<Song> Songs = new List<Song>();

        internal static List<Playlist> playlists = new List<Playlist>();

        //internal static bool focus;
        internal static string focusedname;
        public MainWindow()
        {
            //XAML Einbinden
            InitializeComponent();
            LoadPlaylistFromJson(@"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\playlists.json");
            LoadSongsFromJson(@"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\Songs.json");



        }
        public void LoadPlaylistFromJson(string path)
        {
            playlists = JsonConvert.DeserializeObject<List<Playlist>>(File.ReadAllText(path));
        }

        static void LoadSongsFromJson(string path)
        {
            //Pfad wird gesucht und Objekte aus dem JSON File werden in die Songs Liste übergeben
                string json = File.ReadAllText(path);
                Songs = JsonConvert.DeserializeObject<List<Song>>(json);

        }

        private void LoadSongs_Click(object sender, RoutedEventArgs e)
        {
            int k = 0;

            //Explorer Öffnen, Multiselect aktivieren
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {

                //Jedes ausgewählte File wird in die Songs liste übergeben.

                foreach (string s in openFileDialog.FileNames)
                {
                    TagLib.File f = TagLib.File.Create(openFileDialog.FileNames[k]); //Filename gibt pfad mit f.Tag.Album krigt ma album name
                    Songs.Add(new Song(f.Tag.Title, f.Tag.FirstAlbumArtist, f.Tag.Album, f.Properties.Duration, openFileDialog.FileName));
                    string tests = f.Tag.Title;
                    //Songs Liste wird in JSON gespeichert.
                    string json = JsonSerializer.Serialize(Songs);
                    File.WriteAllText(@"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\Songs.json", json);
                    k++;
                }
            }
        }

        private void Allsongs_Click(object sender, RoutedEventArgs e)
        {
            //Banner.Children.Clear();
            int j = 0;
            foreach (Song s in Songs)
            {
                CreateSongBox(s.Name, s.Artist,s.Album, s.Time, j);
                s.focus = false;
                j++;
            }
        }

        public void CreateSongBox(string songtitle, string artist,string album, TimeSpan time, int i)
        {
            //i: nr des Songs und multiplikator für den Abstand zu Top damit immer 80 abstand herrscht.
            int top = 125 + (i * 80);

            //Rechteck auf Canvas setzen
            Rectangle r = new Rectangle();
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.StrokeThickness = 3;
            r.HorizontalAlignment = HorizontalAlignment.Stretch;
            r.VerticalAlignment = VerticalAlignment.Stretch;
            r.Fill = new SolidColorBrush(Colors.Gray);
            r.Width = 995;
            r.Height = 75;
            Canvas.SetLeft(r, 262);
            Canvas.SetTop(r, top);
            Banner.Children.Add(r);

            //Songtitel Label
            Label songname = new Label();
            songname.Margin = new Thickness(10, 10, 144, 519);
            songname.FontSize = 22;
            songname.Content = songtitle;
            Canvas.SetLeft(songname, 262);
            Canvas.SetTop(songname, top-5);
            Banner.Children.Add(songname);

            //Songartist Label
            Label songartist = new Label();
            songartist.Margin = new Thickness(36, 35, 118, 494);
            songartist.FontSize = 22;
            songartist.Content = artist;
            Canvas.SetLeft(songartist, 262);
            Canvas.SetTop(songartist, top-5);
            Banner.Children.Add(songartist);


            //Songalbum Label
            Label songalbum = new Label();
            songalbum.FontSize = 22;
            songalbum.Content = album;
            Canvas.SetLeft(songalbum, 800);
            Canvas.SetTop(songalbum, top + 15);
            Banner.Children.Add(songalbum);


            //Songlänge Label
            Label songtime = new Label();
            songtime.FontSize = 22;

                    //time.Totalseconds = 300.2 
                    //schot hässlich us also oamol modulo 60 zum da rest krriga und oamol durch 60 zum die minuten zum kriga
            int remainder = Convert.ToInt16(time.TotalSeconds % 60);

            int quotient = Convert.ToInt16(time.TotalSeconds / 60);

            //fürn flex wenn sekunden unter 10 isch no a 0 dazua
            if (remainder < 10)
            {
                string seconds = "0" + remainder;
                songtime.Content = quotient + ":" + seconds;
            }
            else
            {
                songtime.Content = quotient + ":" + remainder;
            }

            Canvas.SetLeft(songtime, 1151);
            Canvas.SetTop(songtime, top+15);
            Banner.Children.Add(songtime);

            Button b = new Button();
            b.FontSize = 22;
            b.Content = "...";
            b.Name = songtitle.Replace(" ", "");
            b.Click += Menubutton_Click;
            Canvas.SetLeft(b, 1201);
            Canvas.SetTop(b, top+20);
            Banner.Children.Add(b);

            Button p = new Button();
            p.FontSize = 22;
            p.Content = "Play";
            p.Name = songtitle.Replace(" ", "_");
            p.Click += PlayButton_Click;
            Canvas.SetLeft(p, 1101);
            Canvas.SetTop(p, top + 20);
            Banner.Children.Add(p);

        }

        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            string sonname = (sender as Button).Name.Replace("_"," ");
            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Source = new Uri(@"C:\Users\nikol\Music\" + sonname + ".mp3", UriKind.RelativeOrAbsolute);
            mediaElement1.Play();
        }

        public void Menubutton_Click(object sender, RoutedEventArgs e)
        {
            var top = Canvas.GetTop(sender as Button);
            focusedname = (sender as Button).Name;

            foreach (Song s in Songs)
            {
                if (s.Name.Replace(" ", "") == (sender as Button).Name)
                {
                    Button deletebutton = new Button();
                    deletebutton.Name = (sender as Button).Name + "delete";


                    Button AddtoPlaylistbutton = new Button();
                    AddtoPlaylistbutton.Name = (sender as Button).Name + "Add";
                    AddtoPlaylistbutton.Content = "Add Song to Playlist";
                    AddtoPlaylistbutton.Click += ShowPlaylistsmenu;
                    Canvas.SetLeft(AddtoPlaylistbutton, 300);
                    Canvas.SetTop(AddtoPlaylistbutton, 300);
                    Banner.Children.Add(AddtoPlaylistbutton);
                    s.focus = true;
                }
            }
        }

        public void ShowPlaylistsmenu(object sender, RoutedEventArgs e)
        {
            int k = 0;
            foreach(Playlist p in playlists)
            {
                Button addtoplay = new Button();
                addtoplay.Name = p.PlaylistName.Replace(" ","");
                addtoplay.Click += AddToPlaylist_Click;
                addtoplay.Content = p.PlaylistName;
                addtoplay.FontSize = 22;
                Canvas.SetLeft(addtoplay, 320);
                Canvas.SetTop(addtoplay, 300 + (k * 10));
                Banner.Children.Add(addtoplay);
                k++;
            }
        }

        public void AddToPlaylist_Click(object sender, RoutedEventArgs e)
        {
            foreach (Playlist p in playlists)
            {
                if ((sender as Button).Content.ToString() == p.PlaylistName)
                {

                    p.AddSongToPlaylist(Songs.Where(S => S.focus == true).FirstOrDefault());
                    p.SaveSongs();
                    //mach dass die Buttons wieder verschwinden @nick
                }
            }

        }

        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            CreatePlaylist c = new CreatePlaylist();
            c.Show();
        }

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPlaylistFromJson(@"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\playlists.json");


            int i = 0;
            int top = 150;
            foreach (Playlist p in playlists)
            {
                p.LoadSongs();
                if (i >= 5)
                {
                    i = 0;
                    top += 30;
                }
                int left= 300 + (i * 150);
                Button b = new Button();
                b.Content = p.PlaylistName;
                b.Name = p.PlaylistName.Replace(" ","");
                b.Click += ShowPlaylist;
                Canvas.SetTop(b,top);
                Canvas.SetLeft(b, left);
                Banner.Children.Add(b);
                i++;
            }
        }

        public void ShowPlaylist(object sender, RoutedEventArgs e)
        {
            string playname = (sender as Button).Content.ToString();

            var playli = playlists.Where(Playlist => Playlist.PlaylistName == playname).FirstOrDefault();
            int k = 0;
            foreach (Playlist p in playlists)
            {
                if (playli.PlaylistName == p.PlaylistName)
                {
                    foreach (Song s in p.Playlistsongs)
                    {
                        CreateSongBox(s.Name, s.Artist, s.Album, s.Time, k);
                        k++;
                    }
                }
            }
        }
    }
}
