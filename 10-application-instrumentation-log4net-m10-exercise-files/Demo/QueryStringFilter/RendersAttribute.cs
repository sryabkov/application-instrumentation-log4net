using System;

namespace QueryStringFilter
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RendersAttribute : Attribute
    {
        private readonly Type _type;

        public RendersAttribute( Type type)
        {
            _type = type;
        }

        public Type RendersType
        {
            get { return _type; }
        }
    }
}