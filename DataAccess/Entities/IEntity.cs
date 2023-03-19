namespace Infrastructure.DataAccess.Entities
{
    internal interface IEntity<T>
    {
        public bool IsMatching( T entity );
        public bool IsValidUpdate( T entity );
    }
}
