using System;
using System.IO;

namespace EntityMerger.Mapper
{
    public class FileMapper<TObject> : MapperBase<FileInfo, TObject> where TObject : class
    {
        private readonly Func<FileInfo, TObject> _mapFunc;

        public FileMapper(FileInfo entity,Func<FileInfo,TObject> mapFunc )
            : base(entity)
        {
            _mapFunc = mapFunc;
        }

        protected override TObject Map(FileInfo entity)
        {
            return _mapFunc(entity);
        }
    }
}
