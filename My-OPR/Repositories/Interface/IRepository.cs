﻿namespace My_OPR.Repositories.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get();
        Entity Get(Key key);
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(Entity entity);
    }
}
