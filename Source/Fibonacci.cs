namespace teste_target.Source;

public static class Fibonacci
{
    public static bool IsInFibonacci(int num)
    {
        int a = 0, b = 1;
        while (b < num)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        return b == num;
    }
}
