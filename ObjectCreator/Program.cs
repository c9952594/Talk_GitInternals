using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System;
using System.Diagnostics;

namespace GitHashObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var contents = "Craigs Blob";

            // Put the header on the contents => "blob <length of content>0<content>"
            var blobContents = $"blob {contents.Length}{(char)0}{contents}";
            Debugger.Break();

            // Calculate the SHA1 hash of the contents
            var sha1Hasher = new SHA1Managed();
            var contentsAsBytes = Encoding.UTF8.GetBytes(blobContents);
            var sha1Bytes = sha1Hasher.ComputeHash(contentsAsBytes);
            var sha1Base64 = sha1Bytes.Select(b => b.ToString("x2"));
            var sha1 = string.Join("", sha1Base64);
            Debugger.Break();

            // Work out where it should be written to based off the hash
            var filepath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, /* Where this exe is */
                    "../../../../DemoArea",
                    ".git/objects",
                    sha1.Substring(0, 2),
                    sha1.Substring(2)
                )
            );
            Debugger.Break();

            // Make sure the directory is there
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            Debugger.Break();

            // Write it using the ZLib algorithm (Deflater)
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            using (var deflaterStream = new DeflaterOutputStream(fileStream))
            {
                var writeBytes = Encoding.UTF8.GetBytes(blobContents);
                deflaterStream.Write(writeBytes, 0, writeBytes.Length);
            }

            // Show the SHA1 to the user
            Console.WriteLine(sha1);
            Debugger.Break();
        }
    }
}
