using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    internal class Album 
    {
        Song[] songs = new Song[0];
        Artist artist;
        string title;
        public string Title { get { return title; } }
        public Album(Artist artist, string title)
        {
            this.artist = artist;
            this.title = title;
        }
        public void Add(Song song)
        {
            if (!song.Equals(this.artist)) return;
            Song[] temp = new Song[songs.Length + 1];
            for (int i = 0; i < songs.Length; i++)
            {
                temp[i] = songs[i];
            }
            songs = temp;
            songs[songs.Length - 1] = song;
        }
        // I used this for testing purposes and once i made it i didnt want to delete it
        // So instead of making the toString the title i just made a property
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < songs.Length; i++)
            {
                sb.Append(songs[i]);
            }
            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            return this.artist == obj;
        }
        public void Play(Mode mode)
        {

            if (mode == Mode.Repeat)
            {
                mode = Mode.Normal;
                this.Play(mode);
            }
            for (int i= 0; i <= songs.Length-1;i++)
            {
                Console.WriteLine($"Now Playing {songs[i]}");
                    songs[i].Play(mode);
            }
        }
    }
}
