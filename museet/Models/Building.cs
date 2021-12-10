using System.Collections.Generic;

namespace Museet.Models
{
    public class Building
    {
        public string Name {get; private set;}
        public bool BuildingExist;
        public Building(string name)
        { 
            Name = name;
        }

        public void Add(Building building, List<Building> buildingList)
        {
            buildingList.Add(building);
        }
        public void AddRoomToBuilding(Room room, List<Room> roomList)
        {
            roomList.Add(room);
        }
        public string ShowRoomInBuilding(List<Room> roomList)
        {
            var txt = "";
            foreach (var room in roomList)
            {
                txt += $"{room.ShowRoom()}\n";
            }
            return txt;
        }
        public void DeleteRoomFromBuilding(List<Room> roomList, string roomToDelete)
        {
            foreach (var room in roomList)
            {
                if (roomToDelete == room.Name)
                {
                    roomList.Remove(room);
                }
            }
        }
    }
}