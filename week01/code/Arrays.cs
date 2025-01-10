public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array of size 'length' to store the multiples
        // 2. Use a loop that will iterate 'length' times
        // 3. For each iteration i:
        //    - Calculate the multiple by multiplying number by (i + 1)
        //    - Store the result in the array at position i
        // 4. Return the array of multiples

        // Implementation of the plan:
        // 1. Create result array of specified length
        double[] result = new double[length];

        // 2 & 3. Fill array with multiples
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // 4. Return the completed array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Get the portion of the list that needs to move to the front:
        //    - This will be the last 'amount' elements
        // 2. Get the portion of the list that needs to move to the back:
        //    - This will be everything else (from start to length-amount)
        // 3. Clear the original list
        // 4. Add the elements back in the correct order:
        //    - First add the elements that were at the end
        //    - Then add the elements that were at the beginning

        // Implementation of the plan:
        // 1. Get the elements that will move to the front
        var rotatedPart = data.GetRange(data.Count - amount, amount);

        // 2. Get the elements that will move to the back
        var remainingPart = data.GetRange(0, data.Count - amount);

        // 3. Clear the original list
        data.Clear();

        // 4. Add elements back in their new order
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }
}
