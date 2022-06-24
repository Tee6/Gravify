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
        public string PicPath { get; set; }
        public Playlist(string name, string desc, List<Song> songs, string path)
        {
            PlaylistName = name;
            Description = desc;
            Playlistsongs = songs;
            PicPath = path;
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
