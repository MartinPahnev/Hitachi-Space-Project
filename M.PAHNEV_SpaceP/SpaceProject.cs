using System;
using System.Net;
using System.Net.Mail;

namespace M.PAHNEV_SpaceP
{
    public class SpaceProject
    {

        private string _senderEmail;
        private string _senderPassword;
        private string _recipientEmail;
            
        public List<LocationOfPossibleLaunch> BestDayForLaunchPerSite
        { get; private set; }

        public SpaceProject(string FolderPath, string SenderEmail,
                            string SenderEmailPassword, string RecipientEmail)
        {
            _senderEmail = SenderEmail;
            _senderPassword = SenderEmailPassword;
            _recipientEmail = RecipientEmail;


            BestDayForLaunchPerSite = ParseFolder(FolderPath);
            SortLocations(BestDayForLaunchPerSite);

        }

        public void SendEmailToUpperManagement()
        {
            string AnalysisReport = GenerateLaunchAnalysisReport(BestDayForLaunchPerSite);
            LocationOfPossibleLaunch BestLocation = BestDayForLaunchPerSite.First();
            SendEmailWithReport(BestLocation, _senderEmail, _senderPassword, _recipientEmail, AnalysisReport);

        }

        private static List<LocationOfPossibleLaunch> ParseFolder(string PathToDataFolder)
        {
            List<LocationOfPossibleLaunch> DaysForLaunch = new List<LocationOfPossibleLaunch>();
            string[] files = Directory.GetFiles(PathToDataFolder);
            
            foreach (var fileName in files)
            {
                DaysForLaunch.Add(CSVParser.ParseLocation(fileName));
            }
            return DaysForLaunch;
        } 
        private static void SendEmailWithReport(LocationOfPossibleLaunch BestLocation,string senderEmail, string senderEmailPassword, string recipientEmail,string ReportFilePath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Condensed weather report for the Space Program Shuttle Launch.";
                mail.Body = BestLocation.BestDayOfLaunch.Weight == 0.0 ?
                    $"The best day for the launch can't be determined." 
                                            : $"is July {BestLocation.BestDayOfLaunch.Day.Date}"
                                            + $" and the location is { BestLocation.Name}.";
                mail.IsBodyHtml = false;

                if (!string.IsNullOrEmpty(ReportFilePath))
                {
                    Attachment attachment = new Attachment(ReportFilePath);
                    mail.Attachments.Add(attachment);
                }

                SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587, 
                    Credentials = new NetworkCredential(senderEmail, senderEmailPassword),
                    EnableSsl = true
                };

                smtpClient.Send(mail);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

        }

        private void SortLocations(List<LocationOfPossibleLaunch> locations)
        {
            locations.Sort((x, y) =>
            {
                int weightComparison = y.BestDayOfLaunch.Weight.CompareTo(x.BestDayOfLaunch.Weight);
                if (weightComparison == 0)
                {
                    return x.PositionRelativeToEquator.CompareTo(y.PositionRelativeToEquator);
                }
                return weightComparison;
            });
        }

        public string GenerateLaunchAnalysisReport(List<LocationOfPossibleLaunch> locationsForLaunch)
        {
            string filePath = Constants.ResultingFilePath;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Spaceport, Best Date");

                foreach (LocationOfPossibleLaunch location in locationsForLaunch)
                {
                    if(location.BestDayOfLaunch.Weight == 0)
                    {
                        writer.WriteLine($"{location.Name}, No Suitable Day");
                        continue;
                    }
                    writer.WriteLine($"{location.Name},{location.BestDayOfLaunch.Day.Date}");
                }
            }

            return filePath;
        }
    }
}
