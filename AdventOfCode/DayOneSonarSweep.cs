namespace AdventOfCode
{
    public class DayOneSonarSweep
    {
        public int CountIncreasesForSonarSweep(string sonarSweepsDistance)
        {
            if (sonarSweepsDistance != null)
            {
                var sweepsDistanceArray = sonarSweepsDistance.Split(",");
                var amountOfIncreases = 0;

                for (int i = 1; i < sweepsDistanceArray.Length; i++)
                {
                    if(int.Parse(sweepsDistanceArray[i]) > int.Parse(sweepsDistanceArray[i - 1]))
                    {
                        amountOfIncreases++;
                    }
                }

                return amountOfIncreases;
            }

            return 0;
        }
    }
}