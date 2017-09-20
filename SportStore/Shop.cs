using System;
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

        public enum TypeError
        {
            IncorrectCommand,
            IncorrectInputValue
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
        /// <summary>The main method for adding all types of the equipments</summary>
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

        /// <summary>Set base characteristics</summary>
        private bool SetBaseInfo(out string name, out float price)
        {
            bool canContinue = true;
            Console.Clear();
            Console.WriteLine("Name of the equipment:");
            name = Console.ReadLine();

            Console.WriteLine("Price of the equipment:");
            bool result = float.TryParse(Console.ReadLine(), out price);

            if (result)
                result = price >= 0;

            if (!result)
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    SetBaseInfo(out name, out price);
                else
                    canContinue = false;
            }

            return canContinue;
        }

        #region Adding Ball
        /// <summary>Adding equipments wich are Ball</summary>
        private void AddBall()
        {
            string name = "";
            float price = 0.0f;
            float diameter = 0.0f;

            if (!SetBaseInfo(out name, out price))
                return;

            if (!SetBallDiameter(out diameter))
                return;

            SetTypeBall(name, price, diameter);
        }

        /// <summary>Set diameter of the ball</summary>
        private bool SetBallDiameter(out float val)
        {
            bool canContinue = true;
            Console.WriteLine("Set diameter of the ball:");
            bool result = float.TryParse(Console.ReadLine(), out val);

            if (result)
                result = val >= 0;

            if (!result)
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    SetBallDiameter(out val);
                else
                    canContinue = false;
            }

            return canContinue;
        }

        /// <summary>Set type of the ball</summary>
        private void SetTypeBall(string name, float price, float diameter)
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("What type of ball do you want to add ?");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine("Football");
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine("Tennis");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddFootball(name, price, diameter); break;
                case "1": AddTennisBall(name, price, diameter); break;
                default:
                    {
                        if (RepeatEnter())
                            SetTypeBall(name, price, diameter);

                        break;
                    };
            }
        }

        /// <summary>Adding ball - football</summary>
        private void AddFootball(string name, float price, float diameter)
        {
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

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddConcreteBall(name, price, diameter, Football.TypeGame.BeachFotball); break;
                case "1": AddConcreteBall(name, price, diameter, Football.TypeGame.Soccer); break;
                case "2": AddConcreteBall(name, price, diameter, Football.TypeGame.BeachFotball); break;
                default:
                    {
                        if (RepeatEnter())
                            AddFootball(name, price, diameter);

                        break;
                    }
            }
        }

        /// <summary>Adding ball - tennis</summary>
        private void AddTennisBall(string name, float price, float diameter)
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("Type of court");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine(TennisBall.TypeCourt.Ground.ToString());
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine(TennisBall.TypeCourt.Plant.ToString());
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": AddConcreteBall(name, price, diameter, TennisBall.TypeCourt.Ground); break;
                case "1": AddConcreteBall(name, price, diameter, TennisBall.TypeCourt.Plant); break;
                default:
                    {
                        if (RepeatEnter())
                            AddTennisBall(name, price, diameter);

                        break;
                    }
            }
        }

        /// <summary>Adding concrete ball - football</summary>
        private void AddConcreteBall(string name, float price, float diameter, Football.TypeGame tg)
        {
            Console.Clear();
            eqCollection.Add(new Football(name, price, diameter, tg));
            Console.WriteLine("The ball was added successfully!");
            BackToMainMenu();
        }

        /// <summary>Adding concrete ball - tennis</summary>
        private void AddConcreteBall(string name, float price, float diameter, TennisBall.TypeCourt tc)
        {
            Console.Clear();
            eqCollection.Add(new TennisBall(name, price, diameter, tc));
            Console.WriteLine("The ball was added successfully!");
            BackToMainMenu();
        }
        #endregion

        #region Adding Bike
        /// <summary>Adding equipments wich are Bike</summary>
        private void AddBike()
        {
            string name = "";
            float price = 0.0f;
            float weight = 0.0f;

            if (!SetBaseInfo(out name, out price))
                return;

            if (!SetWeightBike(out weight))
                return;

            SetTypeBike(name, price, weight);
        }

        /// <summary>Set bike's weight</summary>
        private bool SetWeightBike(out float weight)
        {
            bool canContinue = true;

            Console.WriteLine("Set weight of the bike:");
            bool result = float.TryParse(Console.ReadLine(), out weight);

            if (result)
                result = weight >= 0;

            if (!result)
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    SetWeightBike(out weight);
                else
                    canContinue = false;
            }

            return canContinue;
        }

        /// <summary>Set type of the bike</summary>
        private void SetTypeBike(string name, float price, float weight)
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("What type of bike do you want to add?");
            menuBuilder.Append("0 - ");
            menuBuilder.AppendLine("City");
            menuBuilder.Append("1 - ");
            menuBuilder.AppendLine("Offroad");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddCityBike(name, price, weight); break;
                case "1": AddOffroadBike(name, price, weight); break;
                default:
                    {
                        if (RepeatEnter())
                            SetTypeBall(name, price, weight);

                        break;
                    };
            }
        }

        /// <summary>Adding bike - citybike</summary>
        private void AddCityBike(string name, float price, float weight)
        {
            Console.Clear();
            Console.WriteLine("Bike has a trunk: 0 - Yes, 1 - No");

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": AddConcreteCityBike(name, price, weight, true); break;
                case "1": AddConcreteCityBike(name, price, weight, false); break;
                default:
                    {
                        if (RepeatEnter())
                            AddCityBike(name, price, weight);

                        break;
                    }
            }
        }

        /// <summary>Adding concrete bike - citybike</summary>
        private void AddConcreteCityBike(string name, float price, float weight, bool hasTrunk)
        {
            Console.Clear();
            eqCollection.Add(new CityBike(name, price, weight, true));
            Console.WriteLine("The bike was added successfully!");
            BackToMainMenu();
        }

        /// <summary>Adding bike - offroad</summary>
        private void AddOffroadBike(string name, float price, float weight)
        {
            Console.Clear();
            Console.WriteLine("Set a number of damper:");

            int ans;
            bool result = int.TryParse(Console.ReadLine(), out ans);
            Console.Clear();
            if (result)
            {
                eqCollection.Add(new OffRoadBike(name, price, weight, ans));
                Console.WriteLine("The bike was added successfully!");
                BackToMainMenu();

            }
            else
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    AddOffroadBike(name, price, weight);
            }
        }
        #endregion

        #region Adding Boat
        /// <summary>Adding equipments wich are Boat</summary>
        private void AddBoat()
        {
            string name = "";
            float price = 0.0f;
            int countSeats = 0;

            if (!SetBaseInfo(out name, out price))
                return;

            if (!SetCountSeats(out countSeats))
                return;

            SetTypeBoat(name, price, countSeats);
        }

        /// <summary>Set boat's number of seats</summary>
        private bool SetCountSeats(out int countSeats)
        {
            bool canContinue = true;
            Console.WriteLine("Set number of seats:");
            bool result = int.TryParse(Console.ReadLine(), out countSeats);

            if (result)
                result = countSeats >= 0;

            if (!result)
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    SetCountSeats(out countSeats);
                else
                    canContinue = false;

            }

            return canContinue;
        }

        /// <summary>Set type of the bike</summary>
        private void SetTypeBoat(string name, float price, int countSeats)
        {
            Console.Clear();
            Console.WriteLine("What type of boat do you want to add? Canoe - 0, Motor - 1");
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "0": AddCanoeBoat(name, price, countSeats); break;
                case "1": AddMotorBoat(name, price, countSeats); break;
                default:
                    {
                        if (RepeatEnter())
                            SetTypeBoat(name, price, countSeats);

                        break;
                    }
            }
        }

        /// <summary>Adding boat - canoe</summary>
        private void AddCanoeBoat(string name, float price, int seats)
        {
            Console.Clear();
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
                case "0": AddConcreteCanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Long); break;
                case "1": AddConcreteCanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Middle); break;
                case "2": AddConcreteCanoeBoat(name, price, seats, CanoeBoat.TypePaddle.Short); break;
                default:
                    {
                        if (RepeatEnter())
                            AddCanoeBoat(name, price, seats);

                        break;
                    }
            }
        }

        /// <summary>Adding concrete boat - canoe</summary>
        private void AddConcreteCanoeBoat(string name, float price, int seats, CanoeBoat.TypePaddle tp)
        {
            Console.Clear();
            eqCollection.Add(new CanoeBoat(name, price, seats, tp));
            Console.WriteLine("The boat was added successfully!");
            BackToMainMenu();
        }

        /// <summary>Adding boat - motorboat</summary>
        private void AddMotorBoat(string name, float price, int countSeats)
        {
            float power = 0.0f;

            Console.Clear();
            Console.WriteLine("Power of motor:");

            bool result = float.TryParse(Console.ReadLine(), out power);

            if (result)
                result = power >= 0;

            if (result)
            {
                Console.Clear();
                eqCollection.Add(new MotorBoat(name, price, countSeats, power));
                Console.WriteLine("The boat was added successfully!");
                BackToMainMenu();
            }
            else
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    AddMotorBoat(name, price, countSeats);
            }
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

            Console.WriteLine("Enter:");
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

            int index;
            bool result = int.TryParse(Console.ReadLine(), out index);
            if (result)
            {
                Console.Clear();
                if (eqCollection.RemoveByIndex(index))
                    Console.WriteLine("The equipment was removed successfully!");
                else
                    Console.WriteLine("The equipment wasn't removed!");

                BackToMainMenu();
            }
            else
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    RemoveByIndex();
            }
        }

        private void RemoveByName()
        {
            Console.Clear();
            Console.WriteLine("Name of equipment:");
            string name = Console.ReadLine();

            Console.Clear();
            if (eqCollection.RemoveByName(name))
                Console.WriteLine("The equipment was removed successfully!");
            else
                Console.WriteLine("The equipment wasn't removed!");

            BackToMainMenu();
        }

        private void RemoveAll()
        {
            Console.Clear();
            eqCollection.RemoveAll();
            Console.WriteLine("The equipment were removed successfully!");

            BackToMainMenu();
        }
        #endregion

        #region Showing Equipment
        /// <summary>The main method for showing all equipments</summary>
        private void ShowEquipment()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("You can choose:");
            menuBuilder.AppendLine("0 - All equipment");
            menuBuilder.AppendLine("1 - Concrete type of equipment");
            menuBuilder.AppendLine("2 - Concrete equipment");
            menuBuilder.AppendLine("3 - Sort equipments and view");
            menuBuilder.AppendLine("4 - Count of equipment");
            menuBuilder.AppendLine("-------------");
            menuBuilder.AppendLine("5 - Main menu");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "0": ShowAllEquipment(); break;
                case "1": ShowConcreteType(); break;
                case "2": ShowConcreteEquipment(); break;
                case "3": ShowSortingEquipmentsByPrice(); break;
                case "4": ShowCountOfEquipment(); break;
                case "5": ShowMainManu(); break;
                default:
                    {
                        if (RepeatEnter())
                            ShowEquipment();

                        break;
                    }
            }
        }

        /// <summary>Showing all equipments</summary>
        private void ShowAllEquipment()
        {
            Console.Clear();
            if (eqCollection.Length == 0)
            {
                Console.WriteLine("The shop is empty!");

            }
            else
            {
                Console.WriteLine("The whole list of the equipment:");
                ShowWholeListEquipments();
            }

            BackToMainMenu();
        }

        /// <summary>Showing all equipments with oreder numbers, without checks</summary>
        private void ShowWholeListEquipments()
        {
            for (int i = 0; i < eqCollection.Length; i++)
            {
                BaseEquipment beq = eqCollection.GetEquipmentByIndex(i);
                Console.WriteLine((i + 1).ToString() + " " + beq.GetInfo());
            }
        }

        /// <summary>Showing some type of equipments</summary>
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

            Console.WriteLine("The list of the concrete type of the equipment:");

            int countItemsConcreteType = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < eqCollection.Length; i++)
            {

                switch (eq)
                {
                    case 0:
                        {
                            BaseBall beq = eqCollection.GetEquipmentByIndex(i) as BaseBall;
                            if (beq != null)
                                SetEquipmentInfoForType(ref sb, ref countItemsConcreteType, beq.GetInfo());

                            break;
                        }
                    case 1:
                        {
                            BaseBike beq = eqCollection.GetEquipmentByIndex(i) as BaseBike;
                            if (beq != null)
                                SetEquipmentInfoForType(ref sb, ref countItemsConcreteType, beq.GetInfo());

                            break;
                        }
                    case 2:
                        {
                            BaseBoat beq = eqCollection.GetEquipmentByIndex(i) as BaseBoat;
                            if (beq != null)
                                SetEquipmentInfoForType(ref sb, ref countItemsConcreteType, beq.GetInfo());

                            break;
                        }
                }
            }


            if (countItemsConcreteType == 0)
                Console.WriteLine("The equipments of the concrete type were not found!");
            else
                Console.WriteLine(sb);
        }

        /// <summary>Configuring view for concrete type of the equipments</summary>
        private void SetEquipmentInfoForType(ref StringBuilder sb, ref int count, string info)
        {
            sb.Append(count + 1);
            sb.Append(" ");
            sb.AppendLine(info);
            count++;
        }

        /// <summary>Obtain the concrete type of the equipment</summary>
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

        /// <summary>Obtain concrete equipment by number or name</summary>
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

        /// <summary>Showing concrete equipment by name</summary>
        private void ShowConcreteEquipmentByName()
        {
            Console.Clear();
            Console.WriteLine("Name:");
            string ans = Console.ReadLine();

            Console.Clear();
            BaseEquipment eq = eqCollection.GetEquipmentByName(ans);
            if (eq != null)
                Console.WriteLine(eq.GetInfo());
            else
                Console.WriteLine("The equipment wasn't found!");

            BackToMainMenu();
        }

        /// <summary>Showing concrete equipment by index</summary>
        private void ShowConcreteEquipmentByIndex()
        {
            int index;
            BaseEquipment eq = null;

            Console.Clear();
            Console.WriteLine("Number:");

            bool result = int.TryParse(Console.ReadLine(), out index);
            Console.Clear();
            if (result)
            {
                eq = eqCollection.GetEquipmentByIndex(index - 1);

                if (eq != null)
                    Console.WriteLine(eq.GetInfo());
                else
                    Console.WriteLine("The equipment wasn't found!");

                BackToMainMenu();
            }
            else
            {
                if (RepeatEnter(TypeError.IncorrectInputValue))
                    ShowConcreteEquipment();
            }
        }

        /// <summary>Choicing a type of sorting</summary>
        private void ShowSortingEquipmentsByPrice()
        {
            Console.Clear();
            Console.WriteLine("You can sort equipments by price. Try it!");
            Console.WriteLine();

            if (eqCollection.Length == 0)
            {
                Console.WriteLine("The shop is empty!");
            }
            else if (eqCollection.Length == 1)
            {
                Console.WriteLine("Only one equipment is situated in the shop! You can see this one:");
                Console.WriteLine();
                Console.WriteLine(eqCollection.GetEquipmentByIndex(0).GetInfo());
            }
            else
            {
                Console.WriteLine("Type of sorting: 0 - Ascending, 1 - Descending");
                SortEquipment(Console.ReadLine());
            }

            BackToMainMenu();
        }

        /// <summary>Sorting equipments</summary>
        /// <param name="typeSort">0 - ascending, 1 - descending</param>
        private void SortEquipment(string typeSort = "0")
        {
            if (typeSort != "0" && typeSort != "1")
            {
                Console.WriteLine("Incorrect command!");
                return;
            }

            BaseEquipment temp;
            if (typeSort == "0") // - ascending
            {
                for (int i = 0; i < eqCollection.Length - 1; i++)
                {
                    for (int j = 0; j < eqCollection.Length - 1; j++)
                    {
                        if (eqCollection.GetEquipmentByIndex(j).Price > eqCollection.GetEquipmentByIndex(j + 1).Price)
                        {
                            temp = eqCollection.GetEquipmentByIndex(j);
                            eqCollection.SetElementByIndex(j, eqCollection.GetEquipmentByIndex(j + 1));
                            eqCollection.SetElementByIndex(j + 1, temp);
                        }
                    }
                }
            }
            else // - descending
            {
                for (int i = 0; i < eqCollection.Length - 1; i++)
                {
                    for (int j = 0; j < eqCollection.Length - 1; j++)
                    {
                        if (eqCollection.GetEquipmentByIndex(j).Price < eqCollection.GetEquipmentByIndex(j + 1).Price)
                        {
                            temp = eqCollection.GetEquipmentByIndex(j);
                            eqCollection.SetElementByIndex(j, eqCollection.GetEquipmentByIndex(j + 1));
                            eqCollection.SetElementByIndex(j + 1, temp);
                        }
                    }
                }
            }

            Console.WriteLine("The sorted list of the equipments:");
            ShowWholeListEquipments();
        }

        private void ShowCountOfEquipment()
        {
            Console.Clear();
            menuBuilder.Clear();
            menuBuilder.AppendLine("You can choose type of viewing information:");
            menuBuilder.AppendLine("0 - Total information");
            menuBuilder.AppendLine("1 - Detail information by the main types");
            Console.WriteLine(menuBuilder);

            Console.WriteLine("Enter:");
            string ans = Console.ReadLine();
            Console.Clear();
            if (ans == "0" || ans == "1")
            {
                ShowCountOfEquipmentByParametr(ans);
            }
            else
            {
                if (RepeatEnter())
                    ShowCountOfEquipment();
            }
        }

        private void ShowCountOfEquipmentByParametr(string typeView = "0")
        {
            if (typeView == "0")
            {
                Console.WriteLine("Total number of equipment is {0}", eqCollection.Length);
            }
            else if (typeView == "1")
            {
                int countBalls, countBikes, countBoats;
                GetCountEquipmentsByBaseType(out countBalls, out countBikes, out countBoats);
                menuBuilder.Clear();
                menuBuilder.Append("Count of balls: ");
                menuBuilder.AppendLine(countBalls.ToString());
                menuBuilder.Append("Count of bikes: ");
                menuBuilder.AppendLine(countBikes.ToString());
                menuBuilder.Append("Count of boats: ");
                menuBuilder.AppendLine(countBoats.ToString());
                Console.WriteLine("Information by types:");
                Console.WriteLine(menuBuilder);
            }
            else
            {
                Console.WriteLine("Incorrect command!");
            }

            BackToMainMenu();
        }

        private void GetCountEquipmentsByBaseType(out int countBalls, out int countBikes, out int countBoats)
        {
            countBalls = countBikes = countBoats = 0;

            for (int i = 0; i < eqCollection.Length; i++)
            {
                if (eqCollection.GetEquipmentByIndex(i) is BaseBall)
                    countBalls++;
                else if (eqCollection.GetEquipmentByIndex(i) is BaseBike)
                    countBikes++;
                else if (eqCollection.GetEquipmentByIndex(i) is BaseBoat)
                    countBoats++;
            }
        }
        #endregion


        /// <summary>Moving to the Main menu</summary>
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

        /// <summary>Ask user about repeat the last input</summary>
        private bool RepeatEnter(TypeError typeError = TypeError.IncorrectCommand)
        {
            bool result = false;

            Console.Clear();
            menuBuilder.Clear();

            if (typeError == TypeError.IncorrectCommand)
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
