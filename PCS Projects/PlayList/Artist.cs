using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    internal class Artist
    {
        string name;
        Album[] albums = new Album[0];
        public Artist(string name)
        {
            this.name = name;
        }
        public void Add(Album album)
        {
            if (!album.Equals(this)) return;
            Album[] temp = new Album[albums.Length + 1];
            for (int i = 0; i < albums.Length; i++)
            {
                temp[i] = albums[i];
            }
            albums = temp;
            albums[albums.Length - 1] = album;
        }
        public void Play(Mode mode)
        {
             
            foreach (Album album in albums)
            {
                if (mode == Mode.Repeat)
                {
                    mode = Mode.Normal;
                    this.Play(mode);
                }
                Console.WriteLine($"Current Album {album.Title}\n");
                album.Play(mode);
                Console.WriteLine();
            }
        }
        public string Name { get { return name; } }
    }
}
