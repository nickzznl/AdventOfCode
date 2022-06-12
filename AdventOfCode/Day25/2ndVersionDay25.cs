namespace AdventOfCode.Day25
{
    public class _2ndVersionDay25
    {
        private int _maxX;
        private int _maxY;
        private bool _hasMoved;

        public int GetStepsUntilMovementStops(string fileLocation)
        {
            //first we get the input from a file
            var fileInputInStringArray = File.ReadAllLines(fileLocation);
            //we set it to a char[][], which is a grid of the input characters    
            var fileInputInCharArray = fileInputInStringArray.Select(iv => iv.ToCharArray()).ToArray();
            var stepsTaken = 0;

            //set initial value to true other while loop won't work
            _hasMoved = true;

            while (_hasMoved)
            {
                _maxX = fileInputInStringArray[0].Length;
                _maxY = fileInputInStringArray.Count();

                fileInputInCharArray = MoveSeaCucumbers(fileInputInCharArray);

                stepsTaken++;
            }

            return stepsTaken;
        }

        public char[][]? MoveSeaCucumbers(char[][] initialInput)
        {
            var firstResult = new char[_maxY][];
            _hasMoved = false;

            //loop through each line in the file
            for (int i = 0; i < _maxY; i++)
            {
                firstResult[i] = new char[_maxX];
                //loop through each char in the line
                for(int j = 0; j < _maxX; j++)
                {
                    //fill lines so that values that don't move are still filled with correct values
                    if (firstResult[i][j] == 0)
                    {
                        firstResult[i][j] = initialInput[i][j];
                    }
                    //all characters other then last, since that one should move back to first char
                    if (j < _maxX - 1 && initialInput[i][j] == '>' && initialInput[i][j + 1] == '.')
                    {
                        firstResult[i][j] = '.';
                        firstResult[i][j + 1] = '>';

                        _hasMoved = true;
                    }
                    //movement for last char
                    if (j == _maxX - 1 && initialInput[i][j] == '>' && initialInput[i][0] == '.')
                    {
                        firstResult[i][j] = '.';
                        firstResult[i][0] = '>';

                        _hasMoved = true;
                    }
                    
                }
            }

            var secondResult = new char[_maxY][];
            //make all lines for south movement to check one line further down

            for (int i = 0; i < _maxY; i++)
            {
                secondResult[i] = new char[_maxX];
            }

            //loop through each line in the file
            for (int i = 0; i < _maxY; i++)
            {
                //loop through each char in the line
                for (int j = 0; j < _maxX; j++)
                {
                    if (secondResult[i][j] == 0)
                    {
                        secondResult[i][j] = firstResult[i][j];
                    }
                    if (i < _maxY - 1 && firstResult[i][j] == 'v' && firstResult[i + 1][j] == '.')
                    {
                        secondResult[i][j] = '.';
                        secondResult[i + 1][j] = 'v';

                        _hasMoved = true;
                    }

                    if (i == _maxY - 1 && firstResult[i][j] == 'v' && firstResult[0][j] == '.')
                    {
                        secondResult[i][j] = '.';
                        secondResult[0][j] = 'v';

                        _hasMoved = true;
                    }
                }
            }

            return secondResult;
        }
    }
}
