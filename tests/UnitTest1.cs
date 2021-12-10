using System;
using Xunit;
using Museet.Models;
using System.Collections.Generic;

namespace tests
{
    public class MuseetTests
    {
        [Fact]
        public void Test_Should_AddBuilding()
        {
            var buildingList = new List<Building>();
            var building1 = new Building("Test");

            buildingList.Add(building1);

            Assert.True(buildingList.Contains(building1));
        }
        [Fact]
        public void Test_Should_AddRoom()
        {
            var roomList = new List<Room>();
            var room1 = new Room("Test");

            roomList.Add(room1);

            Assert.True(roomList.Contains(room1));
        }
        [Fact]
        public void Test_Should_AddArt()
        {
            var artList = new List<Art>();
            var art1 = new Art("En röd Gurka", "Gurkis", "En gurka som ingen annan gurka");

            artList.Add(art1);

            Assert.True(artList.Contains(art1));
        }
        [Fact]
        public void Test_Should_AddArtInARoom()
        {
            var roomList = new List<Room>();
            var artList = new List<Art>();
            var room1 = new Room("Test");
            var art1 = new Art("En röd Gurka", "Gurkis", "En gurka som ingen annan gurka");

            if (room1.Name == "Test")
            {
                AddArtToTheRoomAndReturnTheArt(roomList, artList, room1, art1);
            }
            
            Assert.Contains(art1.Title, room1.Name);
            Assert.Equal($"{room1.Name}:\n{art1.Title}\n{art1.Author}\n{art1.Description}", AddArtToTheRoomAndReturnTheArt(roomList, artList, room1, art1));
        }
        public string AddArtToTheRoomAndReturnTheArt(List<Room> roomList, List<Art> artList, Room room1, Art art1)
        {
            artList.Add(art1);
            var txt = $"{room1.Name}:\n{art1.Title}\n{art1.Author}\n{art1.Description}";
            return txt;
        }
    }
}
