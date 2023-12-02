using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022;

class Day6
{
    public static int Part1()
    {
        int result = FindUniqueBuffer(4);
        return result;
    }

    public static int Part2()
    {
        int result = FindUniqueBuffer(14);
        return result;
    }

    static int FindUniqueBuffer(int bufferSize)
    {
        string source = Source.GetEntireSource(6);
        List<char> buffer = new List<char>();


        for (int i = 0; i < source.Length; i++)
        {
            if (buffer.Count == bufferSize)
            {
                buffer.RemoveAt(0);
            }

            buffer.Add(source[i]);

            bool allUnique = CharsAreUnique(buffer.ToArray());

            if (allUnique && buffer.Count == bufferSize)
            {
                return i + 1;

            }
        }
        return 0;
    }

    static bool CharsAreUnique(char[] characters)
    {
        if (characters == null || characters.Length == 0) { return false; }

        HashSet<char> charactersSet = characters.ToHashSet();
        int length = characters.Count();

        return charactersSet.Count == length;
    }

}
