using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;

namespace Breakout.Entities
{
    partial class PowerupSpeedUp : Powerup
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
            foreach(var ball in Scene.Entities.List<Ball>())
            {
                ball.Speed *= 2;
            }
        }
    }
}
