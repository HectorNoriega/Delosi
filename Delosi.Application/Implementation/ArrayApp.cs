using Delosi.Application.Interface;

namespace Delosi.Application
{
    public class ArrayApp : IArrayApp
    {
        public int[][] rotateArray(int[][] array) {

            if (validateArray(array))
            {
                return rotate(array);
            }
            else
            {
                throw new Exception("Bad Array");
            }
        }

        private int[][] rotate(int[][] array) {
            int arraySize = array.Length;

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize / 2; j++)
                {
                    var x = array[i][j];
                    array[i][j] = array[i][arraySize - j - 1];
                    array[i][arraySize - j - 1] = x;
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i; j < arraySize; j++)
                {
                    var x = array[i][j];
                    array[i][j] = array[j][i];
                    array[j][i] = x;
                }
            }

            return array;
        }

        private bool validateArray(int[][] array)
        {
            int arraySize = array.Length;

            foreach (int[] arrayIntern in array) { 
                if (arrayIntern.Length != arraySize) return false;
            }

            return true;
        }
    }
}
