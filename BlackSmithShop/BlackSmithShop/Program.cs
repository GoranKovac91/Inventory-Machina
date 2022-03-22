using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjektiKonstruktori
{
    public enum Rarity
    {
        Common,
        Rare,
        Legendary,
        Unkown

    }
    public enum Type
    {
        Sword,
        Shield,
        Armor,
        Unkown
    }
    public class Item
    {
        private int _price;
        private string _name;
        private Type _type;
        private Rarity _rarity;

        public Item(Rarity rarity, Type type, string name, int price)
        {
            _rarity = rarity;
            _type = type;
            _name = name;
            _price = price;
        }
        public int price
        {
            get { return _price; }
            set { price = value; }
        }
        public Type type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Rarity rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

    }

    public class User
    {
        public static List<Item> itemList;

        private static Rarity SetRarity()
        {
            int userInput;
            Console.WriteLine("What kind of item do u wish to create" + "\r\n" + "Common" + "\r\n" + "Rare" + "\r\n" + "Legendary");
            string userString = Console.ReadLine();
            int.TryParse(userString, out userInput);
            if (userInput == 1)
            {
                return Rarity.Common;
            }
            else if (userInput == 2)
            {
                return Rarity.Legendary;
            }
            else if (userInput == 3)
            {
                return Rarity.Rare;
            }
            else
            {
                return Rarity.Unkown;
            }

        }
        private static Type CreateType()
        {
            int userInput;
            Console.WriteLine("Select item to be created" + "\r\n " + "Sword" + "\r\n" + "Shield " + "\r\n" + "Armor");
            string userString = Console.ReadLine();
            int.TryParse(userString, out userInput);
            if (userInput == 1)
            {
                return Type.Sword;
            }
            else if (userInput == 2)
            {
                return Type.Shield;

            }
            else if (userInput == 3)
            {
                return Type.Armor;
            }
            else
            {
                return Type.Unkown;
            }
        }
        private static int SetPrice()
        {
            Console.WriteLine("Please set price of item");
            int userInput;
            string userString = Console.ReadLine();
            int.TryParse(userString, out userInput);
            return userInput;
        }
        private static string SetName()
        {
            Console.WriteLine("Enter name of item");
            string userString = Console.ReadLine();
            return userString;

        }
        public static void CreateItems()
        {
            itemList = new List<Item>();
            Console.WriteLine("Select number of items u wish to create");
            int userInput;
            string userString = Console.ReadLine();
            int.TryParse(userString, out userInput);
            for (int i = 0; i < userInput; i++)
            {
                Item itemName = new Item(User.SetRarity(), User.CreateType(), User.SetName(), User.SetPrice());
                itemList.Add(itemName);

            }

        }
        public static void ShowItems()
        {
            itemList.ForEach(delegate (Item item)
            {
                Console.WriteLine(item.name + " " + item.price + " " + item.rarity + " " + item.type);
            });
        }
        public static void DeleteItems()
        {
            int userInput;
            Console.WriteLine("Please select item to be deleted");
            string userString = Console.ReadLine();
            int.TryParse(userString, out userInput);
            for (int i = 0; i < itemList.Count; i++)
            {
                if (userInput > itemList.Count)
                {
                    Console.WriteLine("Not enough items in list");
                }
                else if (userInput == i)
                {
                    itemList.RemoveAt(i);
                }
            }

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            string userString;
            do
            {
                Console.WriteLine("Select what u want to do" + " \r\n " + "1.Create new items" + " \r\n " + "2.View all items" + "\r\n " + "3.Delete items");
                userString = Console.ReadLine();
                int.TryParse(userString, out userInput);
                if (User.itemList == null || userInput == 1)
                {
                    User.CreateItems();
                }
                else if (userInput == 2)
                {
                    User.ShowItems();
                }
                else if (userInput == 3)
                {
                    User.DeleteItems();
                }
                else if (userInput == 0)
                {
                    return;
                }
            } while (int.TryParse(userString, out userInput) == true && userInput != 0 && userInput < 4);



        }
    }
}
