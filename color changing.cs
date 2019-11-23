using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 96; i < 256; i++)
            {
                Process.Start("uploader.exe", $"#{i.ToString("X")}{(i - 32).ToString("X")}ff"); //m - b
                Thread.Sleep(50);
            }

            for (int i = 255; i >= 96; i--)
            {
                Process.Start("uploader.exe", $"#ffff{i.ToString("X")}"); //b - z
                Thread.Sleep(50);
            }

            for(int i = 96; i < 256; i++)
            {
                Process.Start("uploader.exe", $"#ffff{i.ToString("X")}"); //z - b
                Thread.Sleep(50);
            }

            for (int i = 255; i >= 96; i--)
            {
                Process.Start("uploader.exe", $"#{i.ToString("X")}{(i - 32).ToString("X")}ff");  //b - m
                Thread.Sleep(50);
            }
        }
    }
}
