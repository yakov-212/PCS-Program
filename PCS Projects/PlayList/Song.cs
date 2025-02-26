using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    internal class Song
    {
        string name;
        Artist artist;
        string lyrics;

        public Song(string name, string lyrics, Artist artist)
        {
            this.name = name;
            this.lyrics = lyrics;
            this.artist = artist;
        }
        
        public void Display()
        {
            Console.WriteLine($"{name} by {artist.Name}");
        }
        public void Play(Mode mode)
        {
            if (mode == Mode.Repeat) 
                Console.WriteLine(lyrics+"\n");
            Console.WriteLine(lyrics+"\n");
        }
        public override bool Equals(object? obj)
        {
            return this.artist == obj;
        }
        public override string ToString()
        {
            return $"{this.name} by {this.artist.Name}\n";
        }
    }
}
