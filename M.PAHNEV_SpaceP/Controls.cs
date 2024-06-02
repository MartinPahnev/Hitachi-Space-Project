using System;
namespace M.PAHNEV_SpaceP
{
    public abstract class Controls
    {
        public string ExitMessage { get; protected set; } = "";
        public string StartingMessage { get; protected set; } = "";


        public void Input()
        {
            string PathToFolder = "";
            string SenderEmail = "";
            string SenderPassword = "";
            string RecipientEmail = "";

            while (true)
            {
                Console.WriteLine(StartingMessage);

                int ConsoleInput = Convert.ToInt32(Console.ReadLine());



                switch (ConsoleInput)
                {
                    case 1:
                        { 
                            PathToFolder = Console.ReadLine();
                            SenderEmail = Console.ReadLine();
                            SenderPassword = Console.ReadLine();
                            RecipientEmail = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            SpaceProject MainSupercomputer = new SpaceProject(PathToFolder, SenderEmail, SenderPassword, RecipientEmail);
                            MainSupercomputer.SendEmailToUpperManagement();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(ExitMessage);
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }

            }
        }
    }
}

