namespace Adam.Web.Helpers
{
    internal static class TimerStringHelper
    {
        internal static string ConvertSecondsToTimeString(double timeElapsed)
        {
            string output = "";
            TimeSpan time = TimeSpan.FromSeconds(timeElapsed);

            //hour long format
            if (timeElapsed > 3600)
            {
                output = time.ToString(@"hh\:mm\:ss") + " hour";
            }
            else if (timeElapsed > 60)
            {
                output = time.ToString(@"mm\:ss") + " min";
            }
            else
            {
                output = time.ToString(@"ss\.ff");
            }
            return output;
        }
    }
}
