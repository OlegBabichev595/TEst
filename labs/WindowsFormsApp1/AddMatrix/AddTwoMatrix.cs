namespace AddMatrix
{
    public static class AddTwoMatrix
    {
        public static int[,] AddMatrix(int[,] matrixFirst, int[,] matrixSecond)
        {
            var resultMatrix = new int[matrixSecond.Length, matrixSecond.Length];
            for (var i = 0; i < matrixSecond.GetLength(0); i++)
            {
                for (var j = 0; j < matrixSecond.GetLength(0); j++)
                {
                    resultMatrix[i, j] = matrixFirst[i, j] + matrixSecond[i, j];
                }
            }

            return resultMatrix;
        }
    }
}