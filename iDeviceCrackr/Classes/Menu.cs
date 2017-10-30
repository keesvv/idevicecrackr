using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDeviceCrackr
{
    public class Menu
    {
        public string MenuTitle { get; set; }
        public ConsoleColor? MenuTitleColor { get; set; }
        public List<MenuItem> Items { get; set; }

        public Menu(string title, ConsoleColor? titleColor, List<MenuItem> items)
        {
            MenuTitle = title;
            MenuTitleColor = titleColor;
            Items = items;
        }

        public void ShowMenu(bool clearConsole = true)
        {
            if(clearConsole)
            {
                Console.ResetColor();
                Console.Clear();
                Tools.DisplaySplashText();
            }
            
            if (MenuTitleColor.HasValue) Console.ForegroundColor = MenuTitleColor.Value;
            Console.WriteLine(Tools.StringIndent + $"-=+ [ {MenuTitle} ] +=-");
            Console.ResetColor();

            foreach (MenuItem item in Items)
            {
                if (item.ForeColor.HasValue) Console.ForegroundColor = item.ForeColor.Value;
                Console.WriteLine(Tools.StringIndent + $"[{item.Identifier}] {item.Title}");
                Console.ResetColor();
            }

            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            foreach (MenuItem item in Items)
            {
                if (pressedKey == item.Key)
                {
                    item.SelectAction.Invoke();
                }
            }
        }
    }

    public class MenuItem
    {
        public int Identifier { get; set; }
        public string Title { get; set; }
        public ConsoleColor? ForeColor { get; set; }
        public ConsoleKey Key { get; set; }
        public Action SelectAction { get; set; }

        public MenuItem(int id, string title, ConsoleColor? color, ConsoleKey key, Action action)
        {
            Identifier = id;
            Title = title;
            ForeColor = color;
            Key = key;
            SelectAction = action;
        }
    }
}
