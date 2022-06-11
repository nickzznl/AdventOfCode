namespace AdventOfCode.Day25
{
    public class Day25SeaCucumber
    {        
        public long GetStepsUntilNoMoreMovesCanBeMade(string input)
        {
            var hasMoved = true;
            long totalMoves = 0;
            if (input == null)
            {
                input = @"..\..\..\ExampleForTest.txt";
            }
            var fileLines = File.ReadAllLines(input).ToList();

            var maxStepsXandY = GetMaxLinesXAndY(fileLines);
            var maxX = maxStepsXandY[0];
            var maxY = maxStepsXandY[1];

            while(hasMoved)
            {
                hasMoved = false;

                for (var i = 0; i < maxY; i++)
                {
                    if (fileLines[i].Contains(">"))
                    {
                        var lineCharArray = fileLines[i].ToCharArray();

                        for(var j = 0; j < maxX; j++)
                        {
                            if (j < maxX - 1 && lineCharArray[j] == '>' && lineCharArray[j + 1] == '.')
                            {
                                lineCharArray[j] = '.';
                                lineCharArray[j + 1] = '>';

                                fileLines[i] = new string(lineCharArray);

                                hasMoved = true;
                            }

                            if (j == maxX - 1 && lineCharArray[j] == '>' && lineCharArray[0] == '.')
                            {
                                lineCharArray[j] = '.';
                                lineCharArray[0] = '>';

                                fileLines[i] = new string(lineCharArray);

                                hasMoved = true;
                            }
                        }
                    }

                    if (fileLines[i].Contains("v"))
                    {
                        var lineCharArray = fileLines[i].ToCharArray();
                        var lineCharArrayToMoveTo = CreateDownMovementCharArray(fileLines, i, maxY);
                        var previousLine = CreatePreviousLineToCheck(fileLines, i, maxY, maxX);

                        for (var k = 0; k < maxX; k++)
                        {
                            if (k < maxX - 1 && lineCharArray[k] == 'v' && lineCharArrayToMoveTo[k] == '.')
                            {
                                lineCharArray[k] = '.';
                                lineCharArrayToMoveTo[k] = 'v';

                                fileLines[i] = new string(lineCharArray);
                                if (i < maxY - 1)
                                {
                                    fileLines[i + 1] = new string(lineCharArrayToMoveTo);
                                }

                                else fileLines[0] = new string(lineCharArrayToMoveTo);

                                hasMoved = true;
                            }

                            if (i == maxY && lineCharArray[k] == 'v' && lineCharArrayToMoveTo[k] == '.')
                            {
                                lineCharArray[k] = '.';
                                lineCharArrayToMoveTo[k] = 'v';

                                fileLines[i] = new string(lineCharArray);
                                if (i < maxY - 1)
                                {
                                    fileLines[i + 1] = new string(lineCharArrayToMoveTo);
                                }

                                else fileLines[0] = new string(lineCharArrayToMoveTo);

                                hasMoved = true;
                            }
                        }
                    }
                }
                if (hasMoved)
                {
                    totalMoves++;
                }
            }
            return totalMoves;
        }

        private object CreatePreviousLineToCheck(List<string> fileLines, int lineToUse, int maxY, int maxX)
        {
            if (lineToUse == 0)
            {
                return fileLines[maxY];
            }
            else return fileLines[lineToUse - 1];
        }

        private static char[] CreateDownMovementCharArray(List<string>? fileLines, int lineToUse, int totalLines) => lineToUse == totalLines ? fileLines[lineToUse + 1].ToCharArray() : fileLines[0].ToCharArray();

        private static int[] GetMaxLinesXAndY(List<string>? fileLines)
        {
            if(fileLines == null)
            {
                return null;
            }

            var maxX = fileLines[0].Length - 1;
            var maxY = fileLines.Count;

            return new int[] { maxX, maxY };
        }
    }
}
