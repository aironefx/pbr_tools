using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary1
{
    public class Class1
    {
        public static IList<String> GetWorkingFolders(IEnumerable<String> textureFolders)
        {
            var workingFolders = new List<String>();
            
            foreach (var directory in textureFolders)
            {
                var innerDirectories = Directory.GetDirectories(directory);
                if (innerDirectories.Length > 0)
                {
                    workingFolders.AddRange(innerDirectories);
                }
                
                if (Directory
                    .GetFiles(directory)
                    .Any(x => 
                        x.ToLower().EndsWith(".dds") || 
                        x.ToLower().EndsWith(".bmp")))
                {
                    workingFolders.Add(directory);
                }
            }

            return workingFolders;
        }
    }
}