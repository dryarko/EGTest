// DomainObject.cs
// Created by Yaroslav Nevmerzhytskyi

using System;

namespace Core.Domain.Impl
{
    [Serializable]
    public class DomainObject : IDomainObject
    {
        public String Id { get; set; }

        public DomainObject()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}