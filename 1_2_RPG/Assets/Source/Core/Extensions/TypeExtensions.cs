// TypeExtensions.cs
// Created by Yaroslav Nevmerzhytskyi

using System;

namespace Core.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns the first occurrence of the specified attribute
        /// </summary>
        /// <typeparam name="TAttribute">Custom attribute type</typeparam>
        public static TAttribute GetFirstAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            Object[] customAttributes = type.GetCustomAttributes(typeof(TAttribute), true);

            if(customAttributes.Length > 0)
                return customAttributes[0] as TAttribute;

            return null;
        }
    }
}