﻿namespace MaidataConverter
{
    public class Tokenizer : ITokenizer
    {
        public Tokenizer()
        {
        }

        public string[] Tokens(string location)
        {
            try
            {
                string[] result = System.IO.File.ReadAllLines(location);
                return result;
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(location);
            }
        }
    }
}

