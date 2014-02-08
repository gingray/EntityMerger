using System;
using System.IO;

namespace EntityMerger.Mapper
{
    public class TextFileMapper : FileMapper<string>
    {
        public TextFileMapper(string filename)
            : base(new FileInfo(filename), MapToText)
        {

        }
        protected TextFileMapper(FileInfo entity, Func<FileInfo, string> mapFunc)
            : base(entity, mapFunc)
        {

        }

        private static string MapToText(FileInfo file)
        {
            using (var stream = file.OpenText())
            {
                return stream.ReadToEnd();
            }

        }
    }
}
