using System;

public static class IOUtils
{
    public static void WriteEllipses(int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine(".");
        }
    }

    public static void PromptAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
