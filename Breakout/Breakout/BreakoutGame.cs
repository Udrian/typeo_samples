using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace Breakout
{
    partial class BreakoutGame : Game
    {
        public WindowService WindowService { get; set; }
        public KeyboardInputService KeyboardInputService { get; set; }
        public Vec2i ScreenSize { get; set; } = new Vec2i(1280, 1024);
        
        // Functions
        protected void InternalInitialize()
        {
            KeyboardInputService.SetKeyAlias("Quit", KeyboardKey.Escape);
            KeyboardInputService.SetKeyAlias("Left", KeyboardKey.Left);
            KeyboardInputService.SetKeyAlias("Right", KeyboardKey.Right);

            MainWindow = WindowService.CreateWindow("Brakeout", new Vec2i(100, 100), ScreenSize);
        }
        
        protected void InternalCleanup()
        {
        }
    }
}
