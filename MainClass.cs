﻿using System;
using System.IO;

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
            Console.WriteLine ("line = {0, -5} token = {1, -30} value = {2}",
                decafToken.LineInfo, decafToken.TokenType.ToString (), decafToken.Value);
        }
    }
}