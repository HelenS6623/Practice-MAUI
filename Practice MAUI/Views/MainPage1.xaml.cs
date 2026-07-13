

using System.ComponentModel.Design;
using System.Diagnostics;

namespace Practice_MAUI.Views;

public partial class MainPage1 : ContentPage
{
    public MainPage1()
    {
        InitializeComponent();
    }

    double wage = 12.55;
    string itemPriceString = "";
    double timeInMinutes;
    double timeInMinutesRaw;
    int hours;
    string timeText;
    string hourText;
    string minuteText;
    string andTrue;

    private void calculateButton_Clicked(object sender, EventArgs e)
    {
        hours = 0;
        timeInMinutes = 0;
        itemPriceString = itemPriceBox.Text;
        timeInMinutesRaw = Double.Parse(itemPriceString) / wage;
        timeInMinutes = timeInMinutesRaw * 60;
        timeInMinutes = (int)Math.Round(timeInMinutes);

        if (timeInMinutes >= 60)
        {
            while (timeInMinutes >= 60)
            {
                hours += 1;
                timeInMinutes -= 60;
            }
        }

        timeOutput.Text = timeTextOutput(hours, timeInMinutes);
    }

    string timeTextOutput(int hours, double minutes)
    {
        if (hours > 0)
        {
            if (hours > 1) { hourText = hours + " hours "; }
            else { hourText = hours + " hour "; }
        }

        else { hourText = ""; }

        if (minutes > 0)
        {

            if (minutes > 1) { minuteText = minutes + " minutes"; }
            else { minuteText = minutes + " minute"; }
        }

        else { minuteText = ""; }

        if (minutes == 0)
        {
            andTrue = "";
        }
        else if (hours > 0 && minutes > 0) {andTrue = "and "; }

        timeText = hourText + andTrue + minuteText;
        return timeText;
    }
}