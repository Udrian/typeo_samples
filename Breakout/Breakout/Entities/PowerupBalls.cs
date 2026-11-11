using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;

namespace Breakout.Entities
{
    partial class PowerupBalls : Powerup
    {
        // Functions
        protected override void InternalInitialize()
        {
            base.InternalInitialize();
        }
        
        protected override void Cleanup()
        {
            base.Cleanup();
        }
        
        public override void Update(double dt)
        {
            base.Update(dt);
        }
        
        public override void Draw(ICanvas canvas)
        {
            base.Draw(canvas);
        }

        public override void Pickup()
        {
            var ball = Scene.Entities.Create<Ball>();
            ball.Position = Position;
            ball.Direction = new Vec2(0, -1);
        }
    }
}
