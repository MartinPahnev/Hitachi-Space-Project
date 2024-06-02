using System;
namespace M.PAHNEV_SpaceP
{

	public class GermanControls : Controls
	{
        const string GermanStartingMessage = "Sie haben die folgenden Optionen vor sich: \n" +
            "1. Geben Sie die Steuerparameter ein. \n" +
            "2. Senden Sie den Bericht an das Hauptquartier. \n" +
            "3. Beenden Sie die App.";

        const string GermanExitMessage = "Vielen Dank für die Nutzung unseres Systems. Auf Wiedersehen!";


        public GermanControls() 
		{
			this.StartingMessage = GermanStartingMessage;
			this.ExitMessage = GermanExitMessage;
		}
    }
}

