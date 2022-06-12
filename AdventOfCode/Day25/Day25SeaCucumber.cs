namespace AdventOfCode.Day25
{
    public class Day25SeaCucumber
    {
        private bool _hasMoved;
        private List<string> _linesToCompareTo;

        public long GetStepsUntilNoMoreMovesCanBeMade(string input)
        {
            _hasMoved = true;
            long totalMoves = 0;
            if (input == null)
            {
                input = @"..\..\..\ExampleForTest.txt";
            }

            _linesToCompareTo = File.ReadAllLines(input).ToList();
            var linesToChange = File.ReadAllLines(input).ToList();

            var maxStepsXandY = GetMaxLinesXAndY(_linesToCompareTo);
            var maxX = maxStepsXandY[0];
            var maxY = maxStepsXandY[1];

            while (_hasMoved)
            {
                _hasMoved = false;

                linesToChange = MoveEast(maxY, maxX, _linesToCompareTo, linesToChange);
                _linesToCompareTo = CopyValues(linesToChange);
                linesToChange = MoveSouth(maxY, maxX, _linesToCompareTo, linesToChange);

                if (_hasMoved)
                {
                    totalMoves++;
                    _linesToCompareTo = CopyValues(linesToChange);
                }
            }
            
            return totalMoves;

        }

        private List<string> MoveEast(int maxY, int maxX, List<string> linesToCompareTo, List<string> linesToChange)
        {
            for (var i = 0; i < maxY; i++)
            {
                if (linesToCompareTo[i].Contains(">"))
                {
                    var lineCharArray = linesToCompareTo[i].ToCharArray();

                    for (var j = 0; j <= maxX; j++)
                    {
                        if (j < maxX - 1 && lineCharArray[j] == '>' && lineCharArray[j + 1] == '.')
                        {
                            lineCharArray[j] = '.';
                            lineCharArray[j + 1] = '>';

                            linesToChange[i] = new string(lineCharArray);
                            j++;

                            _hasMoved = true;
                        }

                        if (j == maxX && lineCharArray[j] == '>' && lineCharArray[0] == '.')
                        {
                            lineCharArray[j] = '.';
                            lineCharArray[0] = '>';

                            linesToChange[i] = new string(lineCharArray);

                            _hasMoved = true;
                        }
                    }


                }
            }

            return linesToChange;
        }

        private List<string> CopyValues(List<String> initialList)
        {
            List<String> returnList = new List<string>(initialList);
            return returnList;
        }

        private List<string> MoveSouth(int maxY, int maxX, List<string> linesToCompareTo, List<string> linesToChange)
        {
            for (int i = 0; i < maxY; i++)
            {
                if (linesToCompareTo[i].Contains("v"))
                {
                    var lineCharArray = linesToChange[i].ToCharArray();
                    var lineCharArrayToMoveTo = CreateDownMovementCharArray(linesToCompareTo, linesToChange, i, maxY - 1);
                    var lineAboveOld = CreateLineAboveCharArray(linesToCompareTo, i, maxX);
                    var lineAboveNew = CreateLineAboveCharArray(linesToChange, i, maxX);

                    

                    for (var k = 0; k <= maxX; k++)
                    {
                        if (i < maxY - 1 && lineCharArray[k] == 'v' && lineCharArrayToMoveTo[k] == '.')
                        {
                            if (i == 0)
                            {
                                lineCharArray[k] = '.';
                                lineCharArrayToMoveTo[k] = 'v';

                                linesToChange[i] = new string(lineCharArray);
                                if (i < maxY - 1)
                                {
                                    linesToChange[i + 1] = new string(lineCharArrayToMoveTo);
                                }

                                else linesToChange[0] = new string(lineCharArrayToMoveTo);

                                _hasMoved = true;
                            }
                            else if (lineAboveOld[k] != 'v' || lineAboveNew[k] != '.')
                            {
                                lineCharArray[k] = '.';
                                lineCharArrayToMoveTo[k] = 'v';

                                linesToChange[i] = new string(lineCharArray);
                                if (i < maxY - 1)
                                {
                                    linesToChange[i + 1] = new string(lineCharArrayToMoveTo);
                                }

                                else linesToChange[0] = new string(lineCharArrayToMoveTo);

                                _hasMoved = true;
                            }
                        }

                        if (i == maxY - 1 && lineCharArray[k] == 'v' && linesToCompareTo[0][k] == '.')
                        {
                            if (lineAboveOld[k] != 'v' || lineAboveNew[k] != '.')
                            {
                                lineCharArray[k] = '.';
                                lineCharArrayToMoveTo[k] = 'v';

                                linesToChange[i] = new string(lineCharArray);

                                linesToChange[0] = new string(lineCharArrayToMoveTo);

                                _hasMoved = true;
                            }
                        }
                    }
                }
            }

            return linesToChange;
        }

        private static char[]? CreateLineAboveCharArray(List<string>? fileLines, int lineToUse, int maxX) =>
            lineToUse != 0 ? fileLines?[lineToUse - 1].ToCharArray() : new char[maxX];

        private static char[] CreateDownMovementCharArray(List<string> fileLineForInitialLine, List<string>? fileLines, int lineToUse, int totalLines) => 
            lineToUse != totalLines ? fileLines[lineToUse + 1].ToCharArray() : fileLines[0].ToCharArray();

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
