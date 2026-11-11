using TypeOEngine.Typedeaf.Basic2d.Engine.Graphics;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.TypeOBasic2d.Entities;

namespace Breakout.Entities
{
    partial class Ball : Entity2d, IHasScene
    {
        public Scene Scene { get; set; }
        
        // Functions
        protected virtual void InternalInitialize()
        {
            Speed = Scene.Window.Size.Y / 4;
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Update(double dt)
        {
            Position += Direction * Speed * dt;
            if(Position.Y <= 0)
            {
                Position = Position.SetY(0);
                Direction = Direction.SetY(-Direction.Y);
            }
            if(Position.X <= 0)
            {
                Position = Position.SetX(0);
                Direction = Direction.SetX(-Direction.X);
            }
            if(Position.X >= Scene.Window.Size.X - Size.X)
            {
                Position = Position.SetX(Scene.Window.Size.X - Size.X);
                Direction = Direction.SetX(-Direction.X);
            }
            if(Position.Y >= Scene.Window.Size.Y)
            {
                Remove();
            }

            foreach(var brick in Scene.Entities.List<Brick>())
            {
                var w = 0.5 * (Size.X + brick.Size.X);
                var h = 0.5 * (Size.Y + brick.Size.Y);
                var dx = (Position + Size / 2).X - (brick.Position + brick.Size / 2).X;
                var dy = (Position + Size / 2).Y - (brick.Position + brick.Size / 2).Y;

                if(Math.Abs(dx) <= w && Math.Abs(dy) <= h)
                {
                    var wy = w * dy;
                    var hx = h * dx;

                    if(wy > hx)
                    {
                        if(wy > -hx)
                        {
                            Direction = Direction.SetY(Math.Abs(Direction.Y));
                        }
                        else
                        {
                            Direction = Direction.SetX(-Math.Abs(Direction.X));
                        }
                    }

                    else
                    {
                        if(wy > -hx)
                        {
                            Direction = Direction.SetX(Math.Abs(Direction.X));
                        }
                        else
                        {
                            Direction = Direction.SetY(-Math.Abs(Direction.Y));
                        }
                    }

                    brick.Hit();
                }
            }
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            canvas.DrawRectangle(Position, Size, true, Color.CapeHoney);
        }
    }
}
