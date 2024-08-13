using System.Collections.Generic;

public class MyService : IMyService
{
    public static List<byte[]> bytes = new List<byte[]>();

    public MyService()
    {
        MyWork();
    }

    public void MyWork()
    {
        // Simulate a memory leak
        for(int i = 0; i < 15; i++)
        {
            bytes.Add(new byte[1024 * 1024 * 500]);
        }
    }
}