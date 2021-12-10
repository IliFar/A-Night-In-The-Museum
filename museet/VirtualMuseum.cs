using System;
using System.Collections.Generic;
using Museet.Models;
using Simulator;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        List<Building> buildingList = new List<Building>();
        List<Room> roomList = new List<Room>();

        public void Run(string verb, string[] options)
        {
            bool showHelp = false;
			
            // FIXME: Continue with your program here
            Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',', options));

            switch (verb)
            {	
				case "select":
					break;
                case "add-building":
                    AddBuilding(options); //The option here is the building's name.
                    break;

                // *Applikationen 'mu' kan med ett lämpligt kommando lägga till ett helt nytt rum i museet.*|
                case "add-room":
                    AddRoomToBuilding(options); //The option here is the room's name
                    break;

				//*Applikationen 'mu' kan med ett lämpligt kommando radera ett specifikt rum i museet.*|
                case "delete-room":
                    DeleteRoomFromABuilding();
                    break;

                // *Applikationen 'mu' kan med ett lämpligt kommando lägga till ett nytt konstverk i ett rum.*|
                case "add-art":
                    AddArtToRoom();
                    break;

                // *Applikationen 'mu' kan med ett lämpligt kommando lista alla konstverken som finns i ett specifikt rum, rummet är angivet i kommandot.*
                case "show-art-in":
                    ShowArtInARoom(options); //The option here is the room's name
                    break;

                // *Applikationen 'mu' kan med ett lämpligt kommando lista alla rum samt konstverken som finns i rummet.*|
                case "show-all":
                    ListAllRoomsAndArts();
                    break;

                // *Applikationen 'mu' kan med ett lämpligt kommando radera ett specifikt konstverk från ett rum.*|
                case "delete-art":
                    DeleteArtInARoom();
                    break;

                default:
					Console.WriteLine("UNKNOWN COMMAND");
					showHelp = true;
                    break;
            }
			if (showHelp)
			{
				Console.Clear();
				Console.WriteLine("*** WELCOME TO THE VIRTUAL MUSEUM ***\n");
				Console.WriteLine("COMMANDS GUIDE: To Execute A Command, Start By Typing The Word \"mu\" Followed By One Of The Commands Below.\n");
				Console.WriteLine("[1] add-building [give it name] # Will add the building to the application");
				Console.WriteLine("[2] add-room [give it name] # Will add the room to specific building");
				Console.WriteLine("[3] delete-room # Will delete a room inside a specific building");
				Console.WriteLine("[4] add-art # Will add the art to a specific room");
				Console.WriteLine("[5] show-art-in [room name] # Will show the arts in the specified room");
				Console.WriteLine("[6] show-all # Will show all the rooms and the art inside them");
				Console.WriteLine("[7] delete-art # Will a specific art in a given room");
			}
        }

        private void DeleteRoomFromABuilding()
        {
            foreach (var building in buildingList)
            {
                Console.WriteLine($"Building: {building.Name.ToUpper()}\n{building.ShowRoomInBuilding(roomList)}\n");
            }
            Console.Write("Enter The Name Of The Building Where The Room To Be Deleted Exists: ");
            var buildingNameInput = Console.ReadLine();
            Console.Write("Enter The Room Name To Delete: ");
            var roomNameInput = Console.ReadLine();
            foreach (var building in buildingList)
            {
                building.DeleteRoomFromBuilding(roomList, roomNameInput);
            }
        }

        private void AddBuilding(string[] options)
        {
            if (options.Length < 0)
            {
                Console.WriteLine("No Building Name Specified");
                throw new Exception("addbuilding ERROR");
            }
            var newBuilding = new Building(options[0]);
            newBuilding.Add(newBuilding, buildingList);
            Console.WriteLine("Building is successfully added");
        }

        private void DeleteArtInARoom()
        {
            foreach (var room in roomList)
            {
                Console.WriteLine($"Room: {room.Name.ToUpper()}\n{room.ShowArtInRoom()}\n");
            }
            Console.Write("Enter The Name Of The Room Where The Art To Be Deleted Exists: ");
            var roomNameInput = Console.ReadLine();
            Console.Write("Enter The Art Name To Delete: ");
            var artNameInput = Console.ReadLine();
            foreach (var room in roomList)
            {
                if (room.Name == roomNameInput)
                {
                    room.DeleteArt(artNameInput);
                    Console.WriteLine("Art Is Successfully Deleted");
                }
            }
        }

        private void ListAllRoomsAndArts()
        {
            foreach (var room in roomList)
            {
                Console.WriteLine($"Room: {room.Name.ToUpper()}\n{room.ShowAllRoomsAndTheirArt()}");
            }
        }

        private void AddRoomToBuilding(string[] options)
        {
            if (options.Length < 0)
            {
                Console.WriteLine("No given name to the room");
                throw new Exception("addroom ERROR");
            }
            foreach (var building in buildingList)
            {
                if (building.Name == options[0])
                {
                    var newRoom = new Room(options[0]);
                    building.AddRoomToBuilding(newRoom, roomList);
                    Console.WriteLine("room successfully added");
                }
            }
        }

        private void ShowArtInARoom(string[] options)
        {
            if (options.Length < 0)
            {
                Console.WriteLine("No room specified");
                throw new Exception("Art ERROR");
            }
            foreach (var room in roomList)
            {
                if (room.Name == options[0])
                {
                    Console.WriteLine($"Room: {room.Name.ToUpper()}\n{room.ShowArtInRoom()}");
                }
            }
        }

        private void AddArtToRoom()
        {
            if (roomList.Count < 0)
            {
                Console.WriteLine("There are no rooms available");
                throw new Exception("addart ERROR");
            }
            if (roomList != null)
            {
                Console.Write("Enter Art Name: ");
                var artNameInput = Console.ReadLine();
                Console.Write("Enter Art Author: ");
                var artAuthorInput = Console.ReadLine();
                Console.Write("Enter Art Description: ");
                var artDescpInput = Console.ReadLine();
                Console.Write("Enter The Room Name In Which You Would like The Art To Be: ");
                var roomNameInput = Console.ReadLine();
                foreach (var room in roomList)
                {
                    if (room.Name == roomNameInput)
                    {
                        while (!room.noMoreArt)
                        {
                            if (room.artCount < room.artLimit)
                            {
                                var newArt = new Art(artNameInput, artAuthorInput, artDescpInput);
                                room.AddArtToRoom(newArt);
                                Console.WriteLine("art successfully added");
                                room.artCount++;
                                break;
                            }
                            else
                            {
                                room.noMoreArt = true;
                                Console.WriteLine($"Sorry, {room.Name.ToUpper()} Has Reached Maximun Capacity (MAX 3 Art Pieces Per Room)");
                            }
                        }
                    }
                }
            }
        }
    }
}