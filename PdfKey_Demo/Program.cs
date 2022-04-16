using PdfKey_Demo.Test;
using System;
using System.IO;

namespace PdfKey_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            DirectoryInfo directory = new DirectoryInfo(C1_02_DigestBC.DEST);
            directory.Create();

            C1_02_DigestBC.TestAll();
        }
    }
}
