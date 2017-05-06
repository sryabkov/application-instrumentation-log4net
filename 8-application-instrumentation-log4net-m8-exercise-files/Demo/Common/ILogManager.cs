using System;

namespace Common
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
    }
}