using System;
namespace M.PAHNEV_SpaceP
{
    public abstract class Controls
    {
        public string ExitMessage { get; protected set; } = "";
        public string StartingMessage { get; protected set; } = "";
        public string PathToFolderMessage { get; protected set; } = "";
        public string SenderEmailMessage { get; protected set; } = "";
        public string SenderPasswordMessage { get; protected set; } = "";
        public string RecipientEmailMessage { get; protected set; } = "";



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
                            Console.WriteLine(PathToFolderMessage);
                            PathToFolder = Console.ReadLine();
                            Console.WriteLine(SenderEmailMessage);
                            SenderEmail = Console.ReadLine();
                            Console.WriteLine(SenderPasswordMessage);
                            SenderPassword = Console.ReadLine();
                            Console.WriteLine(RecipientEmailMessage);
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

