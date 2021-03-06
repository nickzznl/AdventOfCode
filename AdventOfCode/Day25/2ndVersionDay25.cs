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

            //we set it to a char[,], which is a grid of the input characters    
            _maxX = fileInputInStringArray[0].Length;
            _maxY = fileInputInStringArray.Count();

            var fileInputInCharArray = CreateCharArray(null, fileInputInStringArray);

            //var fileInputInCharArray = fileInputInStringArray.Select(iv => iv.ToCharArray()).ToArray();


            var stepsTaken = 0;

            //set initial value to true other while loop won't work
            _hasMoved = true;

            while (_hasMoved)
            {
                fileInputInCharArray = MoveSeaCucumbers(fileInputInCharArray);

                //only to check for myself inside test no actual use case
                for (int i = 0; i < _maxY; i++)
                {
                    for (int j = 0; j < _maxX; j++)
                    {
                        Console.Write(fileInputInCharArray[i, j] + "\t");
                    }
                    Console.WriteLine('\t');
                }

                Console.WriteLine('\t');

                stepsTaken++;
            }

            return stepsTaken;
        }

        private char[,] MoveSeaCucumbers(char[,] initialInput)
        {
            //char[,] firstResult = new char[_maxY, _maxX];
            _hasMoved = false;

            var resultMoveEast = CreateCharArray(initialInput, null);


            //loop through each line in the file
            for (int i = 0; i < _maxY; i++)
            {
                //loop through each char in the line
                for(int j = 0; j < _maxX; j++)
                {
                    //fill lines so that values that don't move are still filled with correct values
                    if (resultMoveEast[i, j] == 0)
                    {
                        resultMoveEast[i, j] = initialInput[i, j];
                    }
                    //all characters other then last, since that one should move back to first char
                    if (j < _maxX - 1 && initialInput[i, j] == '>' && initialInput[i, j + 1] == '.')
                    {
                        resultMoveEast[i,j] = '.';
                        resultMoveEast[i,j + 1] = '>';

                        _hasMoved = true;
                    }
                    //movement for last char
                    if (j == _maxX - 1 && initialInput[i, j] == '>' && initialInput[i, 0] == '.')
                    {
                        resultMoveEast[i, j] = '.';
                        resultMoveEast[i, 0] = '>';

                        _hasMoved = true;
                    }
                    
                }
            }

            var resultMoveSouth = CreateCharArray(resultMoveEast, null);

            //loop through each line in the file
            for (int i = 0; i < _maxY; i++)
            {
                //loop through each char in the line
                for (int j = 0; j < _maxX; j++)
                {
                    if (resultMoveSouth[i, j] == 0)
                    {
                        resultMoveSouth[i, j] = resultMoveEast[i, j];
                    }
                    if (i < _maxY - 1 && resultMoveEast[i, j] == 'v' && resultMoveEast[i + 1, j] == '.')
                    {
                        resultMoveSouth[i,j] = '.';
                        resultMoveSouth[i + 1,j] = 'v';

                        _hasMoved = true;
                    }

                    if (i == _maxY - 1 && resultMoveEast[i, j] == 'v' && resultMoveEast[0, j] == '.')
                    {
                        resultMoveSouth[i, j] = '.';
                        resultMoveSouth[0, j] = 'v';

                        _hasMoved = true;
                    }
                }
            }

            return resultMoveSouth;
        }

        private char[,]? CreateCharArray(char[,]? charArray, string[]? stringArray)
        {
            var fileInputInCharArray = new char[_maxY, _maxX];

            if (stringArray != null)
            {
                for (int i = 0; i < _maxY; i++)
                for (int j = 0; j < _maxX; j++)
                {
                    fileInputInCharArray[i, j] = stringArray[i][j];
                }
            }
            if (charArray != null)
            {
                for (int i = 0; i < _maxY; i++)
                for (int j = 0; j < _maxX; j++)
                {
                    fileInputInCharArray[i, j] = charArray[i, j];
                }
            }

            return fileInputInCharArray;
        }

    }
}
