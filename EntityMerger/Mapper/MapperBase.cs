namespace EntityMerger.Mapper
{
    public abstract class MapperBase<TEntity, TObject>
        where TEntity : class
        where TObject : class
    {
        private TObject _object;
        private readonly TEntity _entity;

        protected MapperBase(TEntity entity)
        {
            _entity = entity;
        }

        public TObject Object
        {
            get { return _object ?? (_object = Map(_entity)); }
        }

        protected abstract TObject Map(TEntity entity);

    }
}
