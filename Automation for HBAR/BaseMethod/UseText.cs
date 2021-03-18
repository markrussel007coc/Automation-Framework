using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_for_HBAR.BaseMethod
{
    public class UseText
    {
        static string path;
        /// <summary>
        /// Specify the directory and filename where the text file will be located. Directory and file will be created if not exist
        /// </summary>
        public void TextDirectoryFileName(string textpath)
        {
            string[] splitTextPath = textpath.Split('\\');
            string filename = splitTextPath[splitTextPath.Length - 1];
            string directory = textpath.Substring(0, textpath.Length - filename.Length);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(@textpath))
            {
                var newFile = File.Create(@textpath);
                path = @textpath;
                newFile.Close();
            }
            else
                path = @textpath;
        }

        /// <summary>
        /// Write the text string to the file. This will overwrite the current text content.
        /// </summary>
        public void TextWrite(string overwriteText)
        {
            File.WriteAllText(path, overwriteText);
        }

        /// <summary>
        /// Write the text string to the file. This will append to the current text content.
        /// </summary>
        public void TextAppend(string appendText)
        {
            File.AppendAllText(path, DateTime.Now.ToString("h:mm:sstt") + " ");
            File.AppendAllText(path, appendText + Environment.NewLine);
            Console.WriteLine(DateTime.Now.ToString("h:mm:sstt") + " " + appendText);
        }

        /// <summary>
        /// Open the file through the Notepad application.
        /// </summary>
        public void TextOpenInNotepad()
        {
            Process.Start("Notepad", path);
        }

        public string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

  
    }
}
