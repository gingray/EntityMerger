using System;

namespace EntityMerger.Mapper
{
    public class ObjectMapper<TEntity, TObject> : MapperBase<TEntity, TObject>
        where TEntity : class
        where TObject : class
    {
        private readonly Func<TEntity, TObject> _mapFunc;

        public ObjectMapper(TEntity entity, Func<TEntity, TObject> mapFunc)
            : base(entity)
        {
            _mapFunc = mapFunc;
        }

        protected override TObject Map(TEntity entity)
        {
            return _mapFunc(entity);
        }
    }
}
