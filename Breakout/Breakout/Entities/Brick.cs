using TypeOEngine.Typedeaf.Basic2d.Engine.Graphics;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.TypeOBasic2d.Entities;

namespace Breakout.Entities
{
    partial class Brick : Entity2d, IHasScene
    {
        public Scene Scene { get; set; }

        public Random Random { get; set; } = new Random();

        // Functions
        protected virtual void InternalInitialize()
        {
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            canvas.DrawRectangle(Position, Size, true, Color);
        }

        public void Hit()
        {
            Remove();

            var randSpawn = Random.NextDouble();

            if(randSpawn <= 0.25)
            {
                var randPower = Random.NextDouble();
                if(randPower <= 0.3)
                {
                    Scene.Entities.Create<PowerupSpeedUp>().Position = Position + new Vec2(Size.X / 3, 0);
                }
                else if(randPower <= 0.6)
                {
                    Scene.Entities.Create<PowerupSpeedDown>().Position = Position + new Vec2(Size.X / 3, 0);
                }
                else
                {
                    Scene.Entities.Create<PowerupBalls>().Position = Position + new Vec2(Size.X / 3, 0);
                }
            }
        }
    }
}
