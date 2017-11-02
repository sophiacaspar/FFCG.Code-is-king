using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.Generation.Reverser
{
    public class Reverser
    {
        public string Reverse(string stringToReverse)
        {
            var words = stringToReverse.Split(' ');
            var wordList = new List<string>();

            foreach (string word in words)
            {
                var uppercaseIndex = GetUppercaseIndex(word);
                string reversedString = new String(word.Reverse().ToArray());

                if (uppercaseIndex.Count > 0)
                {
                    reversedString = SetUppercaseOnIndexLetters(reversedString, uppercaseIndex);
                }

                wordList.Add(reversedString);
            }
         
            return string.Join(" ", wordList.ToArray());
        }

        public List<int> GetUppercaseIndex(string word)
        {
            var uppercaseIndex = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsUpper(word[i]))
                {
                    uppercaseIndex.Add(i);
                }
            }
            return uppercaseIndex;
        }

        public string SetUppercaseOnIndexLetters(string word, List<int> index)
        {
            word = word.ToLower();
            var letters = word.ToCharArray();
            for (int i = 0; i < index.Count; i++)
            {
                letters[index[i]] = char.ToUpper(letters[index[i]]);
            }
            return new string(letters);
        }
    }

}
