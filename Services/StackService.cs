using System;
using System.Diagnostics;
using System.IO;

namespace QandAn.Services
{
    public class StackService
    {
        public Tuple<string, string>  GetData(string url)
        {
            var output = ExecuteBashCommand("python3 stack.py \"" + url+ "\"");
            
            string currentDirectory = Directory.GetCurrentDirectory();
            
            string titlePath = System.IO.Path.Combine(currentDirectory, "title.txt");
            string bodyPath = System.IO.Path.Combine(currentDirectory, "body.txt");

            string title = System.IO.File.ReadAllText(titlePath);
            string body = System.IO.File.ReadAllText(bodyPath);

            return Tuple.Create(title, body);
        }

       
        public static string ExecuteBashCommand(string command)
        {
            command = command.Replace("\"","\"\"");

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \""+ command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            proc.WaitForExit();

            return proc.StandardOutput.ReadToEnd();
        } 
    }
}