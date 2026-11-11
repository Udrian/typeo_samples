using TypeOEngine.Typedeaf.Basic2d.Engine.Graphics;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;
using TypeOEngine.Typedeaf.TypeOBasic2d.Entities;

namespace Breakout.Entities
{
    partial class Pad : Entity2d, IHasScene, IHasGame
    {
        public Scene Scene { get; set; }
        public Game Game { get; set; }
        public KeyboardInputService KeyboardInputService { get; set; }
        public int Blocks { get { return (int)Size.X; } set { Size = new Vec2(value * BlockSize, BlockSize); } }

        // Functions
        protected virtual void InternalInitialize()
        {
            Blocks = 10;
            Position = new Vec2((Scene.Window.Size.X - Size.X) / 2, Scene.Window.Size.Y - (Size.Y * 2));
            Speed = Scene.Window.Size.X;
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Update(double dt)
        {
            if(KeyboardInputService.IsDown("Quit") || Scene.Entities.List<Ball>().Count == 0)
            {
                Game.Exit();
            }
            if (KeyboardInputService.IsDown("Left") && Position.X > 0)
            {
                Position = Position.TransformX(-Speed * dt);
            }
            else if (KeyboardInputService.IsDown("Right") && Position.X + Size.X < Scene.Window.Size.X)
            {
                Position = Position.TransformX(Speed * dt);
            }

            if(Position.X < 0) Position = Position.SetX(0);
            if(Position.X > Scene.Window.Size.X - Size.X) Position = Position.SetX(Scene.Window.Size.X - Size.X);

            foreach(var ball in Scene.Entities.List<Ball>())
            {
                var r1x = Position.X;
                var r1y = Position.Y;
                var r1w = Size.X;
                var r1h = Size.Y;

                var r2x = ball.Position.X;
                var r2y = ball.Position.Y;
                var r2w = ball.Size.X;
                var r2h = ball.Size.Y;

                if (r1x + r1w >= r2x &&
                    r1x <= r2x + r2w &&
                    r1y + r1h >= r2y &&
                    r1y <= r2y + r2h)
                {
                    var p = ((ball.Position.X + ball.Size.X / 2) - (Position.X + Size.X / 2)) / Size.X;

                    if(p >= -0.15 && p <= 0.15)
                        ball.Direction = new Vec2(0, -1);
                    else
                        ball.Direction = new Vec2(ball.Direction.X + p, -ball.Direction.Y);
                    ball.Direction.Normalize();
                    ball.Position = ball.Position.SetY(Position.Y - ball.Size.Y - 1);
                }
            }

            foreach(var entity in Scene.Entities.ListAll())
            {
                if(!(entity is Powerup)) continue;
                var powerup = entity as Powerup;

                var r1x = Position.X;
                var r1y = Position.Y;
                var r1w = Size.X;
                var r1h = Size.Y;

                var r2x = powerup.Position.X;
                var r2y = powerup.Position.Y;
                var r2w = powerup.Size.X;
                var r2h = powerup.Size.Y;

                if (r1x + r1w >= r2x &&
                    r1x <= r2x + r2w &&
                    r1y + r1h >= r2y &&
                    r1y <= r2y + r2h)
                {
                    powerup.Pickup();
                    powerup.Remove();
                }
            }
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            canvas.DrawRectangle(Position, Size, true, Color.CapeHoney);
        }
    }
}
