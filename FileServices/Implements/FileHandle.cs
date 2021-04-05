using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace testC01.FileServices.Implements
{
    public class FileHandle : IFileHandle
    {
        public List<string> GetAllLineOfFile(string filePath, string filter)
        {
            List<string> allLine = new List<string>();
            StreamReader reader = new StreamReader(filePath);
            string line;
            while((line = reader.ReadLine())!= null)
            {
                if (line.Contains(filter))
                {
                    allLine.Add(line);
                }
            }
            return allLine;
        }

        public List<string> GetAllLineOfFIleInputFoder(string foderPath, string filter)
        {
            List<string> allLines = new List<string>();
            string[] listPath = Directory.GetFiles(foderPath);
            foreach (var path in listPath)
            {
                var lines = GetAllLineOfFile(path, filter);
                allLines.AddRange(lines);
            }
            return allLines;
        }

        public void WriteTimeToFile(DateTime startTime, DateTime stopTime, string path)
        {
            double Milliseconds = stopTime.Subtract(startTime).TotalMilliseconds;
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Begin=" + startTime);
                    sw.WriteLine("End=" + stopTime);
                    sw.WriteLine("ElapsedMilliseconds=" + Milliseconds);
                }     
        }

        public void WriteToNewFile(string filePath, List<string> allLines)
        {
            for (int i = 0; i < allLines.Count; i++)
            {
                string line = Regex.Replace(allLines[i], @"34=\d+", "34=" + (i + 1));
                File.AppendAllText(filePath, line + Environment.NewLine);
            }
        }
    }
}
