﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public static class Paths
    {
        public static string selectedpath = "Bibliothek";
        //Pfad des Projektordners bis zum "Spotify"-Folder hier einsetzen, Bsp: "C:\Users\Nick\Downloads\Gravify-master_123\Gravify-master\Spotify\"
        public static string projectfolderpath = @"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Spotify\bin\Debug\";
        public static string datapath = projectfolderpath;
        //Der Songfolder muss an einem anderen Platz abgespeichert werden, aus einem unbekannten Grund, Bsp: "C:\Users\Nick\Downloads\Songfolder\"
        public static string librarypath = @"C:\Users\nikol\OneDrive\Desktop\School\emomullet\Spotify\Songfolder\";

    }
}
