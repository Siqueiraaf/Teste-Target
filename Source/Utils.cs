namespace teste_target.Source;
public static class Utils
{
    public static int CalculateSum()
    {
        int index = 13, sum = 0, k = 0;
        while (k < index)
        {
            k++;
            sum += k;
        }
        return sum;
    }

    public static string ReverseString(string str)
    {
        char[] charArray = new char[str.Length];
        for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
        {
            charArray[i] = str[j];
        }
        return new string(charArray);
    }
}
