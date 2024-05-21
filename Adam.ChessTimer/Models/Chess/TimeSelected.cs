namespace Adam.Web.Models.Chess
{
    public class TimeSelected
    {
        public string? GameDurationLabel { get; set; }

        public string? CurrentTime { get; set; }
        /// <summary>
        /// Game Duration (Seconds)
        /// </summary>
        public double GameDuration { get; set; }
        /// <summary>
        /// Turn Increment (Seconds)
        /// </summary>
        public double TurnTimeIncrement { get; set; }

        public string? CssClass{ get; set; }
        public bool FirstRun { get; internal set; } = true;
    }
}
