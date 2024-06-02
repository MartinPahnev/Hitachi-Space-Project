using System;
namespace M.PAHNEV_SpaceP
{
	public class EnglishControls : Controls
	{
		const string EnglishStartingMessage = "You have the following options in front of you: \n" +
            "1. Input the control parameters. \n" +
            "2. Send the Report to HQ. \n" +
            "3. Exit the app.";
		const string EnglishExitMessage = "Thank you for using our System. Goodbye!";
		const string EnglishPathToFolderMessage = "Please input the path to the folder containing the weather reports.";
        const string EnglishSenderEmailMessage = "Please input your email.";
        const string EnglishSenderPasswordMessage = "Please input your email password.";
        const string EnglishRecipientEmailMessage = "Please input recipient email";


        public EnglishControls()
		{
			StartingMessage = EnglishStartingMessage;
			ExitMessage = EnglishExitMessage;
			PathToFolderMessage = EnglishPathToFolderMessage;
			SenderEmailMessage = EnglishSenderEmailMessage;
			SenderPasswordMessage = EnglishSenderPasswordMessage;
			RecipientEmailMessage = EnglishRecipientEmailMessage;
		}
	}
}

