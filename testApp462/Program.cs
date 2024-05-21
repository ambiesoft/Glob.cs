using Ganss.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp462
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var globOptions = new GlobOptions
            {
                IgnoreCase = true,
                DirectoriesOnly = false,
                ThrowOnError = false,
            };

            //var path = @"c:\windows\system32\**\*.dll";
            var path = @"c:\T\**";
            var glob = new Glob(path,
                globOptions, new FileSystem());
            var dlls = glob.Expand();
            foreach (IFileSystemInfo fsi in dlls)
            {
                try
                {
                    Console.WriteLine(fsi.FullName);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
}
