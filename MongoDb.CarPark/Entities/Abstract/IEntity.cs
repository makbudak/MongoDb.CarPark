﻿using System;

namespace MongoDb.CarPark.Entities.Abstract
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }

        DateTime CreatedAt { get; set; }
    }
}
