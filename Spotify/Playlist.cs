using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify
{
    internal class Playlist
    {
        public string PlaylistName { get; set; }
        public string Description { get; set; }
        public List<Song> Playlistsongs { get; set; }

        /*
        public Playlist(string name)
        {
            PlaylistName = name;
            Playlistsongs = new List<Song>();
        }
       
        public Playlist(string name, string desc)
        {
            PlaylistName = name;
            Description = desc;
            Playlistsongs = new List<Song>();
        }
        */
        [JsonConstructor]
        public Playlist(string name, string desc, List<Song> songs)
        {
            PlaylistName = name;
            Description = desc;
            Playlistsongs = songs;
        }



        public void AddSongToPlaylist(Song s)
        {
            if (s != null)
            {
                Playlistsongs.Add(new Song(s.Name, s.Artist, s.Album, s.Time, s.Path));
            }
        }
    }
}
