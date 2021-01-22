using System;

public static class Utils
{
    public static int HelperParseToInt(string _toParse)
    {
        int seconds = 0;

        var parts = _toParse.Split(':');

        if (parts.Length == 3)
        {
            seconds = short.Parse(parts[0]) * 3600 + short.Parse(parts[1]) * 60 + short.Parse(parts[2]);
        }
        else if (parts.Length == 2 && parts[0] == "")
        {
            seconds = short.Parse(parts[1]);
        }
        else if (parts.Length == 2)
        {
            seconds = short.Parse(parts[0]) * 60 + short.Parse(parts[1]);
        }

        return seconds;
    }

    public static string HelperParseToString(int _toParse)
    {
        string buttonText;

        TimeSpan time = TimeSpan.FromSeconds(_toParse);

        if (_toParse <= 59)
        {
            buttonText = time.ToString(@"\:ss");
        }
        else if (_toParse <= 3600)
        {
            buttonText = time.ToString(@"m\:ss");
        }
        else
        {
            buttonText = string.Format("{0}:{1:D2}:{2:D2}", (int)time.TotalHours, time.Minutes, time.Seconds);

        }

        return buttonText;
    }

}
