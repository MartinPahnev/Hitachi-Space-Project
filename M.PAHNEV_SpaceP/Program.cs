using System.Globalization;
using System.Data;
using CsvHelper;
using CsvHelper.Configuration;
namespace M.PAHNEV_SpaceP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Controls? controls = null;
            Console.WriteLine("Welcome to the Space Program's Planning Center!");
            Console.WriteLine("This center uses exclusively @outlook.com emails!");
            Console.WriteLine("Please input 1 for the English Controls," +
                "and 2 für die deutschen Steuerungen");
            int LanguageInput = Convert.ToInt32(Console.ReadLine());
            switch (LanguageInput)
            {
                case 1:
                    {
                        controls = new EnglishControls();
                        break;
                    };
                case 2:
                    {
                        controls = new GermanControls();
                        break;
                    }
                default:
                    {
                        controls = new EnglishControls();
                        break;
                    }

            }
            if (controls != null)
            {
                try
                {
                    controls.Input();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oh no! An exception occured :( :" + ex.Message.ToString());
                }
            }
        }

    }
}