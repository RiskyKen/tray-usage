using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskyKen.TrayUsage.Render
{
    static class RenderRegistry
    {
        private static Dictionary<String, Type> Renderers = new Dictionary<String, Type>();

        public static void Init()
        {
            RegisterRenderer<RendererBasic>("Basic");
            RegisterRenderer<RendererHistory>("History");
            RegisterRenderer<RendererImage>("Image");
        }

        public static string[] GetRendererNames()
        {
            string[] names = new string[Renderers.Count];
            for (int i = 0; i < Renderers.Count; i++)
            {
                names[i] = Renderers.ElementAt(i).Key;
            }
            return names;
        }

        public static void RegisterRenderer<RendererType>(string name)
        {
            Renderers.Add(name, typeof(RendererType));
        }
    }
}
