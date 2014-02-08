using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityMerger.Mapper;
using EntityMerger.Merger;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new TextFileMapper("temp1.txt");
            var t2 = new TextFileMapper("temp2.txt");
            var merger = new Merger<TextFileMapper, TextFileMapper>(new[] {t}, new[] {t2}, MergeFunc);
            var result = merger.Merge();
            foreach (var mergedObject in result)
            {
                Console.WriteLine("{0} {1}", mergedObject.MainObject, mergedObject.ConnectedObjects.Count());
            }
        }

        private static IEnumerable<TextFileMapper> MergeFunc(TextFileMapper arg1, IEnumerable<TextFileMapper> arg2)
        {
            return arg2.Where(c => c.Object.Contains(arg1.Object));
        }
    }
}
