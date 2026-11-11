using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace Particles
{
    partial class ParticlesGame : Game
    {
        public WindowService WindowService { get; set; }
        public static Vec2i ScreenSize { get; set; } = new Vec2i(1024, 768);
        
        // Functions
        protected void InternalInitialize()
        {
            MainWindow = WindowService.CreateWindow("Particles", new Vec2i(100, 100), ScreenSize);
        }
        
        protected void InternalCleanup()
        {
        }
    }
}
