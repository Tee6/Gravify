using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify
{
    class Song
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public TimeSpan Time { get; set; }
        public string Path { get; set; }
        [JsonIgnore]
        public bool focus { get; set; }


        public Song(string name, string artist, string album, TimeSpan time, string path)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Time = time;
            Path = path;
        }
    }
}
