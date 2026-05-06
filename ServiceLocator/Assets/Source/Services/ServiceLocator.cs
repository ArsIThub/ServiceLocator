using System;
using System.Collections.Generic;

public interface IService
{
    T GetService<T>();
}

public class ServiceLocator : IService
{
    private Dictionary<Type, object> _services = new();

    public ServiceLocator(IFadeService fade, ISoundPlayer sound, ISaver saver)
    {
        _services[typeof(IFadeService)] = fade;
        _services[typeof(ISoundPlayer)] = sound;
        _services[typeof(ISaver)] = saver;
    }

    public T GetService<T>()
    {
        return (T)_services[typeof(T)];
    }
}