using System.Collections.Generic;

namespace Museet.Models
{

    // TODO: Needs further work
    public class Room
    {

        public string Name { get; private set; }
        private List<Art> artList;
		public int artCount = 0;
		public int artLimit = 3;
		public bool noMoreArt = false;

        public Room(string name)
        {
            Name = name;
            artList = new List<Art>();
        }
		public string ShowRoom()
		{
			return Name;
		}
        public void AddArtToRoom(Art art)
        {
            artList.Add(art);
        }
		public string ShowArtInRoom()
		{
			var txt = "";
			foreach (var art in artList)
			{
				txt += $"{art.ShowArt()}\n";
			}
			return txt;
		}
		public string ShowAllRoomsAndTheirArt()
		{
			var txt = "";
			foreach (var art in artList)
			{
				txt += $"{art.ShowArt()}\n\n";
			}
			return txt;
		}
		public void DeleteArt(string artToDelete)
		{
			foreach (var art in artList)
			{
				if (artToDelete == art.Title)
				{
					artList.Remove(art);
				}
			}
		}
    }
}
