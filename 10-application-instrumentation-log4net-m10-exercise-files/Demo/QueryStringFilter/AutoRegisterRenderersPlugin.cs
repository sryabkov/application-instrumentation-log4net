﻿using System;
using System.Linq;
using log4net.ObjectRenderer;
using log4net.Plugin;

namespace QueryStringFilter
{
    public class AutoRegisterRenderersPlugin : PluginSkeleton
    {
        public AutoRegisterRenderersPlugin() : base("AutoRegisterRenderers")
        {
        }

        public override void Attach(log4net.Repository.ILoggerRepository repository)
        {
            var renderMap = log4net.LogManager.GetRepository().RendererMap;

            var renderers = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from type in assembly.GetTypes()
                            from attr in type.GetCustomAttributes(typeof (RendersAttribute), true)
                            let renderAttr = attr as RendersAttribute
                            let renderer = Activator.CreateInstance(type) as IObjectRenderer
                            select new {RenderType = renderAttr.RendersType, Renderer=renderer};

            renderers.ToList().ForEach( r=> renderMap.Put( r.RenderType, r.Renderer ));

            base.Attach(repository);
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}