using Adam.Web.Helpers;
using Adam.Web.Models.Chess;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Adam.Web.Components.Pages
{
    public partial class ChessTimerSetup : ComponentBase
    {
        Collapse collapse1 = new Collapse() { };
        bool toggle = true;

        private async Task ToggleContentAsync()
        {
            toggle = !toggle;
            await collapse1.ToggleAsync();

            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        async Task TimeSelectedBtnAsync(FluentButton? fluentButton)
        {
            if (fluentButton != null)
            {
                await ToggleContentAsync();

                var data = ((TimeSelected)fluentButton.Data);

                timeSelected.GameDuration = data.GameDuration;
                timeSelected.GameDurationLabel = data.GameDurationLabel;
                timeSelected.TurnTimeIncrement = data.TurnTimeIncrement;
                timeSelected.CurrentTime = "Start";
                timeSelected2.GameDuration = data.GameDuration;
                timeSelected2.GameDurationLabel = data.GameDurationLabel;
                timeSelected2.TurnTimeIncrement = data.TurnTimeIncrement;
                timeSelected2.CurrentTime = "-";

                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
        }



        private async void setTimer(System.Timers.Timer timerToStart, System.Timers.Timer timerToStop, TimeSelected timeSelectedToDisable, TimeSelected timeSelectedToEnable)
        {
            // Create a timer with a two second interval.
            // Hook up the Elapsed event for the timer.

            if (timeSelected.GameDuration > 0 || timeSelected2.GameDuration > 0)
            {
                timeSelectedToDisable.CssClass = "btn-disabled";
                timeSelectedToEnable.CssClass = "btn-enabled";

                timerToStart.Enabled = true;
                timerToStart.Start();

                timerToStop.Stop();
                if (!timeSelectedToDisable.FirstRun && timeSelected.TurnTimeIncrement != 0 )
                {
                    timeSelectedToDisable.GameDuration += timeSelected.TurnTimeIncrement;
                }
                else
                {
                    timeSelectedToDisable.FirstRun = false;
                }
            }
            else
            {
                hideAlert = false;
                await Task.Delay(2000);
                hideAlert = true;
            }
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private void OnTimedEvent(System.Timers.Timer sender, EventArgs e, ref TimeSelected time)
        {
            time.GameDuration -= 0.1;

            if (time.GameDuration <= 0)
            {
                sender.Stop();
            }
            else
            {
                time.CurrentTime = TimerStringHelper.ConvertSecondsToTimeString(time.GameDuration);

                InvokeAsync(() =>
                {

                    StateHasChanged();
                });
            }
        }

        private async Task ResetOnClickAsync()
        {
            aTimer.Stop();
            bTimer.Stop();

            timeSelected = new TimeSelected();
            timeSelected2 = new TimeSelected();


            await collapse1.ShowAsync();
            toggle = false;

            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}
