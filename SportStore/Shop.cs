﻿using System;
using SportStore.Ball;
using SportStore.Bike;
using SportStore.Boat;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore
{
    class Shop
    {
        public enum TypeEquipment
        {
            Ball,
            Bike,
            Boat
        }

        private StringBuilder menuBuilder;

        private EquipmentCollection eqCollection;

        public Shop()
        {
            eqCollection = new EquipmentCollection();
        }

        public void ShowMainManu()
        {
            Console.Clear();

            if (menuBuilder == null)
                menuBuilder = new StringBuilder();
            else
                menuBuilder.Clear();

            menuBuilder.AppendLine("----------Main Menu----------");
            menuBuilder.AppendLine("See equipments:    -- 0");
            menuBuilder.AppendLine("Add equipment:     -- 1");
            menuBuilder.AppendLine("Remove equipment:  -- 2");
            menuBuilder.AppendLine("Exit               -- Press any key");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": ShowEquipment(); break;
                case "1": AddEquipment(); break;
                case "2": RemoveEquipment(); break;
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Bye, bye...");
                        break;
                    }
            }
        }

        #region Adding Equipment
        private void AddEquipment()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("What type of equipment do you want to add?");
            menuBuilder.AppendLine("0 - Ball");
            menuBuilder.AppendLine("1 - Bike");
            menuBuilder.AppendLine("2 - Boat");
            menuBuilder.AppendLine("-------------");
            menuBuilder.AppendLine("3 - Main menu");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddBall(); break;
                case "1": AddBike(); break;
                case "2": AddBoat(); break;
                case "3": ShowMainManu(); break;
                default:
                    {
                        if (RepeatEnter())
                            AddEquipment();
                        break;
                    }
            }
        }

        private bool SetBaseInfo(out string name, out float price)
        {
            bool canContinue = true;
            Console.Clear();
            Console.WriteLine("Name of the equipment:");
            name = Console.ReadLine();

            Console.WriteLine("Price of the equipment:");
            bool result = float.TryParse(Console.ReadLine(), out price);
            if (!result)
            {
                if (RepeatEnter(1))
                    SetBaseInfo(out name, out price);
                else
                    canContinue = false;
            }

            return canContinue;
        }

        #region Adding Ball
        private void AddBall()
        {
            string name = "";
            float price = 0.0f;
            float diameter = 0.0f;

            if (!SetBaseInfo(out name, out price))
                return;

            if (!SetBallDiameter(out diameter))
                return;

            if (!SetTypeBall(name, price, diameter))
                return;
        }

        private bool SetBallDiameter(out float val)
        {
            bool canContinue = true;
            Console.WriteLine("Set diameter of the ball:");
            bool result = float.TryParse(Console.ReadLine(), out val);
            if (!result)
            {
                if (RepeatEnter(1))
                    SetBallDiameter(out val);
                else
                    canContinue = false;
            }

            return canContinue;
        }

        private bool SetTypeBall(string name, float price, float diameter)
        {
            bool canContinue = true;

            Console.Clear();
            Console.WriteLine("What type of ball do you want to add? Football - 0, Tennis - 1");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddFootball(name, price, diameter); break;
                case "1": AddTennisBall(name, price, diameter); break;
                default:
                    {
                        if (RepeatEnter())
                            SetTypeBall(name, price, diameter);
                        else
                            canContinue = false;

                        break;
                    };
            }

            return canContinue;
        }

        private void AddFootball(string name, float price, float diameter)
        {
            bool canContinue = true;
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("Set a type of game:");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine(Football.TypeGame.MiniFootball.ToString());
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine(Football.TypeGame.Soccer.ToString());
            menuBuilder.Append("2 - ");
            menuBuilder.AppendLine(Football.TypeGame.BeachFotball.ToString());
            Console.WriteLine(menuBuilder);

            string ans = Console.ReadLine();
            Console.Clear();
            switch (ans)
            {
                case "0":
                    {
                        eqCollection.Add(new Football(name, price, diameter, Football.TypeGame.MiniFootball));
                        Console.WriteLine("The ball was added successfully!");
                        break;
                    }
                case "1":
                    {
                        eqCollection.Add(new Football(name, price, diameter, Football.TypeGame.Soccer));
                        Console.WriteLine("The ball was added successfully!");
                        break;
                    }
                case "2":
                    {
                        eqCollection.Add(new Football(name, price, diameter, Football.TypeGame.BeachFotball));
                        Console.WriteLine("The ball was added successfully!");
                        break;
                    }
                default:
                    {
                        if (RepeatEnter())
                            AddFootball(name, price, diameter);
                        else
                            canContinue = false;
                        break;
                    }
            }

            if (canContinue)
                BackToMainMenu();
        }

        private void AddTennisBall(string name, float price, float diameter)
        {
            Console.Clear();
            menuBuilder.AppendLine("Type of court");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine(TennisBall.TypeCourt.Ground.ToString());
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine(TennisBall.TypeCourt.Plant.ToString());
            Console.WriteLine(menuBuilder);

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": eqCollection.Add(new TennisBall(name, price, diameter, TennisBall.TypeCourt.Ground)); break;
                case "1": eqCollection.Add(new TennisBall(name, price, diameter, TennisBall.TypeCourt.Plant)); break;
                default:
                    {
                        if (RepeatEnter())
                            AddTennisBall(name, price, diameter);
                        break;
                    }

            }
        }
        #endregion

        #region Adding Bike
        private void AddBike()
        {
            string name = "";
            float price = 0.0f;
            SetBaseInfo(out name, out price);

            Console.WriteLine("Set weight of the bike:");
            float weight = float.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("What type of bike do you want to add? City - 0, Offroad - 1");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddCityBike(name, price, weight); break;
                case "1": AddOffroadBike(name, price, weight); break;
                default:
                    {
                        if (RepeatEnter())
                            AddBike();
                        break;
                    }
            }
        }

        private void AddCityBike(string name, float price, float weight)
        {
            Console.Clear();
            Console.WriteLine("Bike has a trunk: 0 - Yes, 1 - No");
            bool moveToMainMenu = true;
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": eqCollection.Add(new CityBike(name, price, weight, true)); break;
                case "1": eqCollection.Add(new CityBike(name, price, weight, false)); break;
                default:
                    {
                        if (RepeatEnter())
                            AddCityBike(name, price, weight);
                        else
                            moveToMainMenu = false;

                        break;
                    }
            }

            if (moveToMainMenu)
                BackToMainMenu();
        }

        private void AddOffroadBike(string name, float price, float weight)
        {
            Console.Clear();
            Console.WriteLine("Set a number of damper:");

            // TODO: Добавить проверку на введенное значение
            int ans = int.Parse(Console.ReadLine());
            eqCollection.Add(new OffRoadBike(name, price, weight, ans));

            BackToMainMenu();
        }
        #endregion

        #region Adding Boat
        private void AddBoat()
        {
            string name = "";
            float price = 0.0f;
            SetBaseInfo(out name, out price);

            Console.WriteLine("Set number of seats:");
            // TODO: Add checking
            int countSeats = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("What type of boat do you want to add? Canoe - 0, Offroad - 1");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddCanoeBoat(name, price, countSeats); break;
                case "1": AddMotorBoat(name, price, countSeats); break;
                default:
                    {
                        if (RepeatEnter())
                            AddBoat();
                        break;
                    }
            }
        }

        private void AddCanoeBoat(string name, float price, int seats)
        {
            Console.Clear();
            bool MoveToMainMenu = true;
            menuBuilder.Clear();
            menuBuilder.AppendLine("Type of paddle:");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine(CanoeBoat.TypePaddle.Long.ToString());
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine(CanoeBoat.TypePaddle.Middle.ToString());
            menuBuilder.Append("2 - ");
            menuBuilder.AppendLine(CanoeBoat.TypePaddle.Short.ToString());
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": eqCollection.Add(new CanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Long)); break;
                case "1": eqCollection.Add(new CanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Middle)); break;
                case "2": eqCollection.Add(new CanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Short)); break;
                default:
                    {
                        if (RepeatEnter())
                            AddCanoeBoat(name, price, seats);
                        else
                            MoveToMainMenu = false;

                        break;
                    }
            }

            if (MoveToMainMenu)
                BackToMainMenu();
        }

        private void AddMotorBoat(string name, float price, int seats)
        {
            Console.Clear();
            Console.WriteLine("Power of motor:");
            //TODO: Add check
            float power = float.Parse(Console.ReadLine());

            eqCollection.Add(new MotorBoat(name, price, seats, power));

            BackToMainMenu();
        }
        #endregion
        #endregion

        #region Removing equipment
        private void RemoveEquipment()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("Type of removing equipment:");
            menuBuilder.AppendLine("0 - By name");
            menuBuilder.AppendLine("1 - By number");
            menuBuilder.AppendLine("2 - All equipments");
            menuBuilder.AppendLine("-------------");
            menuBuilder.AppendLine("3 - Main menu");
            Console.WriteLine(menuBuilder);

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": RemoveByName(); break;
                case "1": RemoveByIndex(); break;
                case "2": RemoveAll(); break;
                case "3": BackToMainMenu(); break;
                default:
                    {
                        if (RepeatEnter())
                            RemoveEquipment();
                        break;
                    }
            }

        }

        private void RemoveByIndex()
        {
            Console.Clear();
            Console.WriteLine("Number of equipment:");
            bool needMoveToMainMenu = true;
            int index;
            bool result = int.TryParse(Console.ReadLine(), out index);
            if (result)
            {
                eqCollection.RemoveByIndex(index);
            }
            else
            {
                if (RepeatEnter(1))
                    RemoveByIndex();
                else
                    needMoveToMainMenu = false;
            }

            if (needMoveToMainMenu)
                BackToMainMenu();
        }

        private void RemoveByName()
        {
            Console.Clear();
            Console.WriteLine("Name of equipment:");
            string name = Console.ReadLine();

            eqCollection.RemoveByName(name);

            BackToMainMenu();
        }

        private void RemoveAll()
        {
            eqCollection.RemoveAll();

            BackToMainMenu();
        }
        #endregion

        #region Showing Equipment
        private void ShowEquipment()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("You can see:");
            menuBuilder.AppendLine("0 - All equipment");
            menuBuilder.AppendLine("1 - Concrete type of equipment");
            menuBuilder.AppendLine("2 - Concrete equipment");
            menuBuilder.AppendLine("-------------");
            menuBuilder.AppendLine("3 - Main menu");
            Console.WriteLine(menuBuilder);

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": ShowAllEquipment(); break;
                case "1": ShowConcreteType(); break;
                case "2": ShowConcreteEquipment(); break;
                case "3": ShowMainManu(); break;
                default:
                    {
                        if (RepeatEnter())
                            ShowEquipment();

                        break;
                    }
            }
        }

        private void ShowAllEquipment()
        {
            Console.Clear();
            if (eqCollection.Length == 0)
            {
                Console.WriteLine("The shop is empty!");

            }
            else
            {
                for (int i = 0; i < eqCollection.Length; i++)
                {
                    BaseEquipment beq = eqCollection.GetEquipmentByIndex(i);
                    Console.WriteLine(beq.GetInfo());
                }
            }

            BackToMainMenu();
        }

        private void ShowEquipmentByType(int eq)
        {
            if (eq < 0 || eq > 2)
                return;

            Console.Clear();
            if (eqCollection.Length == 0)
            {
                Console.WriteLine("The shop is empty!");
                return;
            }

            int countItemsConcreteType = 0;
            for (int i = 0; i < eqCollection.Length; i++)
            {

                switch (eq)
                {
                    case 0:
                        {
                            BaseBall beq = eqCollection.GetEquipmentByIndex(i) as BaseBall;
                            if (beq != null)
                            {
                                Console.WriteLine(beq.GetInfo());
                                countItemsConcreteType++;
                            }

                            break;
                        }
                    case 1:
                        {
                            BaseBike beq = eqCollection.GetEquipmentByIndex(i) as BaseBike;
                            if (beq != null)
                            {
                                Console.WriteLine(beq.GetInfo());
                                countItemsConcreteType++;
                            }

                            break;
                        }
                    case 2:
                        {
                            BaseBoat beq = eqCollection.GetEquipmentByIndex(i) as BaseBoat;
                            if (beq != null)
                            {
                                Console.WriteLine(beq.GetInfo());
                                countItemsConcreteType++;
                            }

                            break;
                        }
                }
            }

            if (countItemsConcreteType == 0)
                Console.WriteLine("The equipments of concrete type were not found!");

        }

        private void ShowConcreteType()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("What type of equipment do you want to see?");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine(TypeEquipment.Ball.ToString());
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine(TypeEquipment.Bike.ToString());
            menuBuilder.Append("2 - ");
            menuBuilder.AppendLine(TypeEquipment.Boat.ToString());
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            int ans;
            bool result = int.TryParse(Console.ReadLine(), out ans);
            if (result)
            {
                ShowEquipmentByType(ans);
                BackToMainMenu();
            }
            else
            {
                if (RepeatEnter())
                    ShowConcreteType();
            }
        }

        private void ShowConcreteEquipment()
        {
            Console.Clear();
            Console.WriteLine("Find equipment: By number - 0, By name - 1");
            string ans = Console.ReadLine();

            Console.Clear();
            switch (ans)
            {
                case "0":
                    {
                        ShowConcreteEquipmentByIndex();
                        break;
                    }
                case "1":
                    {
                        ShowConcreteEquipmentByName();
                        break;
                    }
                default:
                    {
                        if (RepeatEnter())
                            ShowConcreteEquipment();

                        break;
                    }
            }
        }

        private void ShowConcreteEquipmentByName()
        {
            Console.Clear();
            Console.WriteLine("Name:");
            string ans = Console.ReadLine();
            BaseEquipment eq = eqCollection.GetEquipmentByName(ans);

            if (eq != null)
                eq.GetInfo();
            else
                Console.WriteLine("The equipment wasn't found!");

            BackToMainMenu();
        }

        private void ShowConcreteEquipmentByIndex()
        {
            int index;
            BaseEquipment eq = null;

            Console.Clear();
            Console.WriteLine("Number:");
            string ans = Console.ReadLine();

            bool result = int.TryParse(ans, out index);
            if (result)
            {
                eq = eqCollection.GetEquipmentByIndex(index);

                if (eq != null)
                    eq.GetInfo();
                else
                    Console.WriteLine("The equipment wasn't found!");

                BackToMainMenu();
            }
            else
            {
                if (RepeatEnter(1))
                    ShowConcreteEquipment();
            }
        }
        #endregion



        private void BackToMainMenu()
        {
            Console.WriteLine("\nBack to main menu - 0, Exit - press any key");
            string ans = Console.ReadLine();
            if (ans == "0")
                ShowMainManu();
            else
            {
                Console.Clear();
                Console.WriteLine("Bye, bye...");
            }
        }

        private bool RepeatEnter(int typeError = 0)
        {
            bool result = false;

            Console.Clear();
            menuBuilder.Clear();

            if (typeError == 0)
                menuBuilder.Append("Unknown command! ");
            else
                menuBuilder.Append("Incorrect input! ");

            menuBuilder.AppendLine("Try one more time?");
            menuBuilder.AppendLine("0 - Yes");
            menuBuilder.AppendLine("Any other key - No(Exit)");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            if (ans == "0")
            {
                result = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bye, bye...");
            }

            return result;
        }
    }
}