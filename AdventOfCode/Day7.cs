using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022;

class Day7
{
    public static int Part1()
    {
        string[] commands = Source.GetSourceLines(7);
        
        foreach (string command in commands)
        {
            string[] words = command.Split(' ');
            
            
        }

        return 0;
    }
}



class Directory
{
    string Filepath { get; set; }

    public Directory(string filepath) 
    {
        this.Filepath = filepath;
    }
}

class FileNode
{
    string Filepath { get; set; }

    public FileNode(string filepath)
    {
        this.Filepath = filepath;
    }
}