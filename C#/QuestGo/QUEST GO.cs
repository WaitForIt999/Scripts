using System;
using Maps;
using QuestGO.App;
using QuestGO.App.Models;
using QuestGO.App.Services;
using QuestGO.App.ViewModels;
using QuestGO.App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading;g.Tasks;

namespace QuestGO.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please register or log in:");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("Please enter your date of birth (YYYY-MM-DD):");
                string dobInput = Console.ReadLine();
            }
        }
    }
}
            
        }
    }
}
}