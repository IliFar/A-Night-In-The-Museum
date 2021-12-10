
namespace Museet.Models
{
	// TODO: Needs further work
   public class Art
	{
		public string Title {get; private set;}
		public string Description {get; private set;}
		public string Author {get; private set;}

		private int numberOfArts;

        public Art(string title, string author, string description)
        {
			Title = title;
			Description = description;
			Author = author;
        }

        public string ShowArt()
        {
            return $"Art Title: {Title}\nArt Author: {Author}\nArt Description: {Description}";
        }
    }
}