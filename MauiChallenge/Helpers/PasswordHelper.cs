namespace MauiChallenge.Helpers;

public static class PasswordHelper
{
    public static string Rot13Password(string input)
    {
        var password = "";
        var endMay = (int)'Z';
        var startMay = (int)'A';
        var endMin = (int)'z';
        var startMin = (int)'a';
        foreach (char letter in input)
        {
            var val = (int)(letter);
            if(val >= startMay && val <= endMay)
            {
                if ((val + 13) > endMay) val = startMay + (((val + 13) - 1) - endMay);
                else val = val + 13;
            }
            else if (val >= startMin && val <= endMin)
            {
                if ((val + 13) > endMin) val = startMin + (((val + 13) - 1) - endMin);
                else val = val + 13;
            }
            password += (char)(val);
        }
        return input + " " + password;
    }
}