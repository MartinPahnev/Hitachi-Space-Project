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

		public EnglishControls()
		{
			StartingMessage = EnglishStartingMessage;
			ExitMessage = EnglishExitMessage;
		}
	}
}

