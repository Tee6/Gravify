﻿using Microsoft.Win32;
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
        internal static string currentlyPlaying;
        internal static TimeSpan currenttime;
        internal static string selectedpath = "Bibliothek";
        internal string datapath = @"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\";
        internal string librarypath = @"C:\Users\nikol\Music\";

        //internal static bool focus;
        internal static string focusedname;
        public MainWindow()
        {
            //XAML Einbinden
            InitializeComponent();


            mediaElement1.LoadedBehavior = MediaState.Manual;

            // Loading in Json Files
            LoadPlaylistFromJson(datapath + "playlists.json");
            LoadSongsFromJson(datapath + "Songs.json");

            Banner.Height = Songs.Count * 95;
            leftrectangle.Height = Banner.Height;
            Scrollbar.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

            foreach (Playlist p in playlists)
                {
                    if (File.Exists(datapath + p.PlaylistName + ".json"))
                    {
                        string json = File.ReadAllText(datapath + p.PlaylistName + ".json");
                    p.Sev(json);
                    }
                }

        }
        #region LoadJson
        //Funktionen für Json Files
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

        #endregion LoadJson

        #region Songs

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
                    File.WriteAllText(datapath + "Songs.json", json);
                    k++;
                }
            }
        }

        private void Allsongs_Click(object sender, RoutedEventArgs e)
        {
            Scrollbar.Visibility = Visibility.Visible;
            selectedpath = "Bibliothek";
            Banner.Height = Songs.Count * 95;
            leftrectangle.Height = Banner.Height;
            Scrollbar.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            //Löscht alle WPF Elemente bevor neue gezeichnet werden
            List<UIElement> itemstoremove = new List<UIElement>();
            foreach (UIElement ui in Banner.Children)
            {
                if (ui.Uid.StartsWith("Song") || ui.Uid.StartsWith("Play") || ui.Uid.StartsWith("Playlist") || ui.Uid.StartsWith("Menu"))
                {
                    itemstoremove.Add(ui);
                }
            }
            foreach (UIElement ui in itemstoremove)
            {
                Banner.Children.Remove(ui);
            }

            //SongBoxen zeichnen
            int j = 0;
            foreach (Song s in Songs)
            {
                CreateSongBox(s.Name, s.Artist,s.Album, s.Time, j);
                s.focus = false;
                j++;
            }
        }
        #endregion Songs

        #region WPF und Buttons
        public void CreateSongBox(string songtitle, string artist,string album, TimeSpan time, int i)
        {
            //i: nr des Songs und multiplikator für den Abstand zu Top damit immer 80 abstand herrscht.
            int top = 125 + (i * 80);
            int a = 1;

            //Rechteck auf Canvas setzen
            Rectangle r = new Rectangle();
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.StrokeThickness = 3;
            r.HorizontalAlignment = HorizontalAlignment.Stretch;
            r.VerticalAlignment = VerticalAlignment.Stretch;
            r.Fill = new SolidColorBrush(Colors.Gray);
            r.Width = 995;
            r.Height = 75;
            r.Uid = "Song" + a;
            Canvas.SetLeft(r, 262);
            Canvas.SetTop(r, top);
            Banner.Children.Add(r);

            //Songtitel Label
            Label songname = new Label();
            songname.Margin = new Thickness(10, 10, 144, 519);
            songname.FontSize = 22;
            songname.Content = songtitle;
            songname.Uid = "Song" + a;
            Canvas.SetLeft(songname, 262);
            Canvas.SetTop(songname, top-5);
            Banner.Children.Add(songname);

            //Songartist Label
            Label songartist = new Label();
            songartist.Margin = new Thickness(36, 35, 118, 494);
            songartist.FontSize = 22;
            songartist.Content = artist;
            songartist.Uid = "Song" + a;
            Canvas.SetLeft(songartist, 262);
            Canvas.SetTop(songartist, top-5);
            Banner.Children.Add(songartist);


            //Songalbum Label
            Label songalbum = new Label();
            songalbum.FontSize = 22;
            songalbum.Content = album;
            songalbum.Uid = "Song" + a;
            Canvas.SetLeft(songalbum, 800);
            Canvas.SetTop(songalbum, top + 15);
            Banner.Children.Add(songalbum);


            //Songlänge Label
            Label songtime = new Label();
            songtime.FontSize = 22;
            songtime.Uid = "Song" + a;

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


            //Menu Button für Playlist Add und Song delete
            Button b = new Button();
            b.FontSize = 22;
            b.Content = "...";
            b.Name = songtitle.Replace(" ", "");
            b.Click += Menubutton_Click;
            b.Uid = "Song" + a;
            Canvas.SetLeft(b, 1201);
            Canvas.SetTop(b, top+20);
            Banner.Children.Add(b);

            Button p = new Button();
            p.FontSize = 22;
            p.Content = "Play";
            p.Name = songtitle.Replace(" ", "_");
            p.Click += PlayButton_Click;
            p.Uid = "Songplay" + a;
            Canvas.SetLeft(p, 1101);
            Canvas.SetTop(p, top + 20);
            Banner.Children.Add(p);

        }

        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            //Songs abspielen
            currentlyPlaying = (sender as Button).Name.Replace("_"," ");
            currenttime = TimeSpan.Zero;

            playbuttonimage.Visibility = Visibility.Hidden;
            pausebuttonimage.Visibility = Visibility.Visible;

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Source = new Uri(librarypath + currentlyPlaying + ".mp3", UriKind.RelativeOrAbsolute);
            mediaElement1.Play();
        }

        

        public void Menubutton_Click(object sender, RoutedEventArgs e)
        {

            List<UIElement> itemstoremove = new List<UIElement>();
            foreach (UIElement ui in Banner.Children)
            {
                if (ui.Uid.StartsWith("Menu"))
                {
                    itemstoremove.Add(ui);
                }
            }
            foreach (UIElement ui in itemstoremove)
            {
                Banner.Children.Remove(ui);
            }


            //Menubutton Links von Songbox öffnet 2 neue Buttons

            var top = Canvas.GetTop(sender as Button);
            var left = Canvas.GetLeft(sender as Button);
            focusedname = (sender as Button).Name;

            foreach (Song s in Songs)
            {
                if (s.Name.Replace(" ", "") == (sender as Button).Name)
                {
                    Button deletebutton = new Button();
                    deletebutton.Name = (sender as Button).Name + "delete";
                    deletebutton.Content = "Delete Song";
                    //deletebutton.Click += DeleteSong;
                    deletebutton.Uid = "Menu";
                    Canvas.SetLeft(deletebutton, left + 20);
                    Canvas.SetTop(deletebutton, top + 20);
                    Banner.Children.Add(deletebutton);

                    Button AddtoPlaylistbutton = new Button();
                    AddtoPlaylistbutton.Name = (sender as Button).Name + "Add";
                    AddtoPlaylistbutton.Content = "Add Song to Playlist";
                    AddtoPlaylistbutton.Click += ShowPlaylistsmenu;
                    AddtoPlaylistbutton.Uid = "Menu";
                    Canvas.SetLeft(AddtoPlaylistbutton, left + 20);
                    Canvas.SetTop(AddtoPlaylistbutton, top);
                    Banner.Children.Add(AddtoPlaylistbutton);
                    s.focus = true;
                }
            }
        }
        public void ShowPlaylistsmenu(object sender, RoutedEventArgs e)
        {
            //AddPlaylist Menu zeigt alle Playlists
            int k = 0;
            foreach(Playlist p in playlists)
            {
                Button addtoplay = new Button();
                addtoplay.Name = p.PlaylistName.Replace(" ","");
                addtoplay.Click += AddToPlaylist_Click;
                addtoplay.Content = p.PlaylistName;
                addtoplay.FontSize = 15;
                addtoplay.Uid = "Menu";
                Canvas.SetLeft(addtoplay, 410);
                Canvas.SetTop(addtoplay, 300 + (k * 23));
                Banner.Children.Add(addtoplay);
                k++;
            }
        }

        public void AddToPlaylist_Click(object sender, RoutedEventArgs e)
        {

            //Fügt song zu Playlist hinzu

            foreach (Playlist p in playlists)
            {
                if ((sender as Button).Content.ToString() == p.PlaylistName)
                {
                    var song = Songs.FirstOrDefault(r => r.focus == true);
                    p.AddSongToPlaylist(song);
                    p.SaveSongs();

                    song.focus = false;
                    //mach dass die Buttons wieder verschwinden @nick
                }
            }

        }

        #endregion WPF und Buttons
        #region controls
        public void Play_MouseDown(object sender, RoutedEventArgs e)
        {
            //Songs abspielen

            playbuttonimage.Visibility = Visibility.Hidden;
            pausebuttonimage.Visibility = Visibility.Visible;

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Source = new Uri(librarypath + currentlyPlaying + ".mp3", UriKind.RelativeOrAbsolute);

            mediaElement1.Play();

            mediaElement1.Position += currenttime;
        }

        public void Play_MouseDown()
        {
            //Songs abspielen

            playbuttonimage.Visibility = Visibility.Hidden;
            pausebuttonimage.Visibility = Visibility.Visible;

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Source = new Uri(librarypath + currentlyPlaying + ".mp3", UriKind.RelativeOrAbsolute);

            mediaElement1.Play();

            mediaElement1.Position += currenttime;
        }

        public void Pause_MouseDown(object sender, RoutedEventArgs e)
        {

            playbuttonimage.Visibility = Visibility.Visible;
            pausebuttonimage.Visibility = Visibility.Hidden;

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Pause();

            currenttime = mediaElement1.Position;
        }

        public void Skip_MouseDown(object sender, RoutedEventArgs e)
        {
            Playlist queue = new Playlist();

            if (selectedpath == "Bibliothek")
            {
                queue.Playlistsongs = Songs;
            }
            else
            {
                Playlist selected = playlists.FirstOrDefault(p => p.PlaylistName == selectedpath);
                queue.Playlistsongs = selected.Playlistsongs;
            }
            

            Song playing = queue.Playlistsongs.FirstOrDefault(p => p.Name == currentlyPlaying);

            int idx = queue.Playlistsongs.IndexOf(playing);

            Song next = queue.Playlistsongs[idx + 1];
            currentlyPlaying = next.Name;

            Play_MouseDown();
        }
        public void Back_MouseDown(object sender, RoutedEventArgs e)
        {
            Playlist queue = new Playlist();

            if (selectedpath == "Bibliothek")
            {
                queue.Playlistsongs = Songs;
            }
            else
            {
                queue.Playlistsongs = playlists.FirstOrDefault(p => p.PlaylistName == selectedpath).Playlistsongs;
            }


            Song playing = queue.Playlistsongs.FirstOrDefault(p => p.Name == currentlyPlaying);

            int idx = queue.Playlistsongs.IndexOf(playing);

            Song next = queue.Playlistsongs[idx - 1];
            currentlyPlaying = next.Name;

            Play_MouseDown();
        }
        #endregion controls

        #region Playlists 

        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            //Öffnet Playlist erstellen fenster
            CreatePlaylist c = new CreatePlaylist();
            c.Show();
        }

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            //Load Playlists
            LoadPlaylistFromJson(datapath + "playlists.json");

            //Alle Elemente Löschen

            List<UIElement> itemstoremove = new List<UIElement>();
            foreach (UIElement ui in Banner.Children)
            {
                if (ui.Uid.StartsWith("Song") || ui.Uid.StartsWith("Play") || ui.Uid.StartsWith("Playlist") || ui.Uid.StartsWith("Menu"))
                {
                    itemstoremove.Add(ui);
                }
            }
            foreach (UIElement ui in itemstoremove)
            {
                Banner.Children.Remove(ui);
            }

            //Für jede Playlist ein Button

            int i = 0;
            int top = 150;
            int c = 0;
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
                b.Uid = "Play" + c;
                Canvas.SetTop(b,top);
                Canvas.SetLeft(b, left);
                Banner.Children.Add(b);
                i++;
                c++;
            }
        }

        public void ShowPlaylist(object sender, RoutedEventArgs e)
        {
            //Unerwünschte Elemente löschen

            List<UIElement> itemstoremove = new List<UIElement>();
            foreach (UIElement ui in Banner.Children)
            {
                if (ui.Uid.StartsWith("Song") || ui.Uid.StartsWith("Play") || ui.Uid.StartsWith("Playlist") || ui.Uid.StartsWith("Menu"))
                {
                    itemstoremove.Add(ui);
                }
            }
            foreach (UIElement ui in itemstoremove)
            {
                Banner.Children.Remove(ui);
            }

            string playname = (sender as Button).Content.ToString();

            Playlist playli = playlists.Where(Playlist => Playlist.PlaylistName == playname).FirstOrDefault();
            selectedpath = playli.PlaylistName;

            //Songs in Playlist anzeigen

            int b = 0;
            Label Playlisttitle = new Label();
            Playlisttitle.Content = playli.PlaylistName;
            Playlisttitle.FontSize = 30;
            Playlisttitle.Foreground = Brushes.White;
            Playlisttitle.Uid = "Playlist" + b;
            Canvas.SetTop(Playlisttitle,200);
            Canvas.SetLeft(Playlisttitle,300);
            Banner.Children.Add(Playlisttitle);

            //Desc
            Label describtion = new Label();
            describtion.Content = playli.Description;
            describtion.FontSize = 30;
            describtion.Foreground = Brushes.White;
            describtion.Uid = "Playlist" + b;
            Canvas.SetTop(describtion,300);
            Canvas.SetLeft(describtion, 300);
            Banner.Children.Add(describtion);

            int mult = 2;
            Image Cover = new Image();
            try
            {
                Cover.Source = new BitmapImage(new Uri(playli.PicPath));
            }
            catch (Exception)
            {
            }
            Cover.Width = mult * 185;
            Cover.Height = mult * 104;
            Cover.Uid = "Playlist" + b;
            Canvas.SetTop(Cover, 150);
            Canvas.SetLeft(Cover, 800);
            Banner.Children.Add(Cover);


            int k = 3;
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

        #endregion Playlists
    }
}
