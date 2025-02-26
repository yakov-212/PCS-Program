namespace Playlist
{
    internal class SongApp
    {
        static void Main(string[] args)
        {
            Artist bennyF = new Artist("Benny Friedman");
            Artist bethovan = new Artist("Bethovan");
            Song todah = new Song("Todah","toda words more words and then some music ending off with words",bennyF);
            Artist asdf = new Artist("ASDF");
            Song sheep = new Song("Im a sheep", "Beep Beep im a sheep i said beep beep im a sheep",asdf);
            Song cow = new Song("Im a cow", "Meow meow im a cow i said meow meow im a c... NO!", asdf);
            Song flop = new Song("everybody do the flop", "Everybody do the flop", asdf);
            Song muffin = new Song("The Muffin Song", "Hey im a muffin and its muffin time, Who wants a muffin please i just want to die ", asdf);

            
            Song virus = new Song("Virus","sjdngkjnviawe", bethovan);
            Album alb = new Album(bennyF, "album");
            Album asdfAlb = new Album(asdf, "Asdf Album");
            asdfAlb.Add(sheep);
            asdfAlb.Add(cow);
            asdfAlb.Add(flop);
            asdfAlb.Add(muffin);
            asdf.Add(asdfAlb);
            alb.Add(todah);
            alb.Add(virus);
            bennyF.Add(alb);
            bennyF.Play(Mode.Normal);
            asdf.Play(Mode.Repeat);




        }
    }
}
