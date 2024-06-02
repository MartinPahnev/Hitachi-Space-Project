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

        const string GermanPathToFolderMessage = "Bitte geben Sie den Pfad zu dem Ordner mit den Wetterberichten ein.";
        const string GermanSenderEmailMessage = "Bitte geben Sie Ihre E-Mail-Adresse ein.";
        const string GermanSenderPasswordMessage = "Bitte geben Sie Ihr E-Mail-Passwort ein.";
        const string GermanRecipientEmailMessage = "Bitte geben Sie die E-Mail-Adresse des Empfängers ein.";


        public GermanControls() 
		{
			StartingMessage = GermanStartingMessage;
            ExitMessage = GermanExitMessage;
            PathToFolderMessage = GermanPathToFolderMessage;
            SenderEmailMessage = GermanSenderEmailMessage;
            SenderPasswordMessage = GermanSenderPasswordMessage;
            RecipientEmailMessage = GermanRecipientEmailMessage;
		}
    }
}

