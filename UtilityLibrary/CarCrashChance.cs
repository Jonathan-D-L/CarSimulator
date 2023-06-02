namespace UtilityLibrary;

public static class CarCrashChance
{
    public static bool CrashChance(int crashThreshold)
    {
        if (crashThreshold == 0) { return false; }
        var crashOnMatch = new List<int>();
        var rand = new Random();
        var crash = rand.Next(1, 101);
        for (int i = 0; i < crashThreshold; i++)
        {
            var chance = rand.Next(1, 101);
            while (crashOnMatch.Contains(chance))
            {
                chance = rand.Next(1, 101);
            }
            crashOnMatch.Add(chance);
        }
        if (crashOnMatch.Contains(crash))
        {
            return true;
        }
        return false;
    }
}