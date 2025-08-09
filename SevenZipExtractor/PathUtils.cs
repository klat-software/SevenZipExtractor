using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SevenZipExtractor
{
    internal sealed class PathUtils
    {
        public static string ReplaceInvalidChars(string path)
        {
            // Get the invalid file name characters and path characters.
            // char[] invalidFileChars = Path.GetInvalidFileNameChars();
            char[] invalidPathChars = Path.GetInvalidPathChars();

            // Replace the invalid characters with an underscore.
            //foreach (char c in invalidFileChars)
            //{
            //    fileName = fileName.Replace(c, '_');
            //}

            foreach (char c in invalidPathChars)
            {
                path = path.Replace(c, '_');
            }

            IEnumerable<string> splits;
#if NET5_0_OR_GREATER
            splits = path.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            path = string.Join(Path.DirectorySeparatorChar, splits);
#else
            splits = path.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
            path = string.Join(Path.DirectorySeparatorChar.ToString(), splits);
#endif

            return path;
        }
    }
}
