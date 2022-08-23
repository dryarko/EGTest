// StreamExtensions.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;

namespace Core.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Convert a String into a Stream. Don't forget to Dispose() once not needed.
        /// </summary>
        /// <param name="stream">this Stream</param>
        /// <param name="source">Streamed String</param>
        /// <returns>Stream from a String</returns>
        public static Stream GetStreamFromString(this Stream stream, String source)
        {
            MemoryStream memStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memStream);
            writer.Write(source);
            writer.Flush();

            return memStream;
        }
    }
}