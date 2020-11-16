using System;
using System.Collections.Generic;
using DataLayer.Entity;

namespace MarsRoverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Fields
            List<int> plateauSize = new List<int>();
            List<string> roverCoordinatesList = new List<string>();
            List<Rover> roverList = new List<Rover>();
            #endregion

            #region MainProcess

            var totalRover = "" ;
            var key = false;

            do
            {
                Console.WriteLine("Please enter the plateau size you will be on. For example 5 5 ");
                var sizeList = Console.ReadLine().Split(' ');

                foreach (var item in sizeList)
                {

                    if (int.TryParse(item, out int tempSize))
                    {
                        plateauSize.Add(tempSize);
                        key = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number");
                        key = true;
                    }

                }
            } while (key);

            Console.WriteLine("Please enter the number of rovers to be on the plateau. For example 1");
            totalRover =Console.ReadLine();

            if(!int.TryParse(totalRover,out int temptotal))
            {
                Console.WriteLine("Please enter a number");
                return;
            }


            for (int i = 1; i <= temptotal; i++)
            {
                var rover = new Rover();
                List<string> moveInformationList = new List<string>();

                Console.WriteLine("Please enter the current location of the " + i + "st rover. For example 1 2 N");
                var locationList = Console.ReadLine().Split(' ');

                foreach (var item in locationList)
                {
                    roverCoordinatesList.Add(item);
                }

                rover.X = Convert.ToInt32(roverCoordinatesList[0]);
                rover.Y = Convert.ToInt32(roverCoordinatesList[1]);
                rover.Direction = roverCoordinatesList[2].ToString();

                Console.WriteLine("Please enter the direction you want the " + i + "st rover to move. For example LMRLML");
                var directionList = Console.ReadLine();

                for (int a = 0; a < directionList.Length; a++)
                {
                    moveInformationList.Add(directionList[a].ToString().ToUpper());
                }

                rover.MoveInformationList = moveInformationList;
                roverList.Add(rover);

                roverCoordinatesList.Clear();
            }

            for (int i = 0; i < roverList.Count; i++)
            {
                var response = NewLocation(roverList[i], plateauSize);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("The outputs of the " + Convert.ToInt32(i + 1) + "st rover are as follows");
                Console.WriteLine(response.X.ToString() + ' ' + response.Y.ToString() + ' ' + response.Direction);
            }


            Console.ReadKey();
        }
        #endregion

        #region Other Methods
        static Rover NewLocation(Rover rover, List<int> plateauSize)
        {
            if (rover.MoveInformationList.Count != 0)
            {
                for (int index = 0; index < rover.MoveInformationList.Count; index++)
                {
                    if (rover.MoveInformationList[index] == "L") //left
                    {
                        switch (rover.Direction)
                        {
                            case "N":
                                rover.Direction = "W";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "E":
                                rover.Direction = "N";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "S":
                                rover.Direction = "E";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "W":
                                rover.Direction = "S";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            default:
                                return rover;
                        }
                    }

                    else if (rover.MoveInformationList[index] == "R") //right
                    {
                        switch (rover.Direction)
                        {
                            case "N":
                                rover.Direction = "E";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "E":
                                rover.Direction = "S";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "S":
                                rover.Direction = "W";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "W":
                                rover.Direction = "N";
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            default:
                                return rover;
                        }
                    }

                    else if (rover.MoveInformationList[index] == "M") //move
                    {
                        switch (rover.Direction)
                        {
                            case "E":
                                if (rover.X < plateauSize[0])
                                    rover.X += 1;
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "N":
                                if (rover.Y < plateauSize[1])
                                    rover.Y += 1;
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "S":
                                if (rover.Y > 0)
                                    rover.Y -= 1;
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            case "W":
                                if (rover.X > 0)
                                    rover.X -= 1;
                                rover.MoveInformationList.RemoveAt(index);
                                return NewLocation(rover, plateauSize);

                            default:
                                return rover;
                        }
                    }
                }
            }
            return rover;
        }
        #endregion
    }
}

