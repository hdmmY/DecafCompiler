using System;
using System.IO;

namespace DecafCompiler
{
    class MainClass
    {
        static void Main (string[] args)
        {
            string testFilePath = @"C:\Users\HY\Desktop\文档\课业\编译原理\DecafCompiler\test.decaf";

            StreamReader reader = new StreamReader (testFilePath);

            string decafScirpt = reader.ReadToEnd ();

            Tokenizer tokenier = new Tokenizer ();

            foreach (var decafToken in tokenier.Tokenize (decafScirpt))
            {
                Console.WriteLine ("token = {0, -30} value = {1}",
                    decafToken.TokenType.ToString (), decafToken.Value);
            }
        }
    }
}