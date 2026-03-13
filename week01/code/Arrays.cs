public static class Arrays
{
    // PLAN FOR MultiplesOf
    // 1. Receive startNumber and count
    // 2. Create a list to store multiples
    // 3. Loop from 1 to count
    // 4. Multiply startNumber by the loop number
    // 5. Add result to the list
    // 6. Return the list as an array
    public static int[] MultiplesOf(int startNumber, int count)
    {
        List<int> numbers = new List<int>();

        for (int i = 1; i <= count; i++)
        {
            numbers.Add(startNumber * i);
        }

        return numbers.ToArray();
    }

    // PLAN FOR RotateRight
    // 1. Save the last value
    // 2. Move each element to the right
    // 3. Put the last value at the first position
    public static void RotateRight(int[] data)
    {
        int last = data[data.Length - 1];

        for (int i = data.Length - 1; i > 0; i--)
        {
            data[i] = data[i - 1];
        }

        data[0] = last;
    }
}
