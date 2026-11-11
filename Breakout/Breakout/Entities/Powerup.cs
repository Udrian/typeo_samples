using TypeOEngine.Typedeaf.Basic2d.Engine.Graphics;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.TypeOBasic2d.Entities;

namespace Breakout.Entities
{
    abstract partial class Powerup : Entity2d, IHasScene
    {
        public Scene Scene { get; set; }

        // Functions
        protected virtual void InternalInitialize()
        {
            Speed = Scene.Window.Size.Y / 2;
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Update(double dt)
        {
            Position = Position.TransformY(Speed * dt);

            if(Position.Y >= Scene.Window.Size.Y)
            {
                Remove();
            }
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            canvas.DrawRectangle(Position, Size, true, Color);
        }

        public abstract void Pickup();
    }
}
