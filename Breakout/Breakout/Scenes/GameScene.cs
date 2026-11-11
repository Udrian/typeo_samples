using Breakout.Entities;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;

namespace Breakout.Scenes
{
    partial class GameScene : Scene
    {
        public Random Random { get; set; } = new Random();
        
        // Functions
        protected virtual void InternalInitialize()
        {
            Entities.Create<Pad>();
            var ball = Entities.Create<Ball>();
            ball.Position = (Window.Size - ball.Size) / 2;
            ball.Direction = new Vec2(0, 1);

            for (int x = 1; x < 16; x++)
            {
                for (int y = 1; y < 14; y++)
                {
                    CreateBrick(new Vec2(x, y), new Color(Random.NextDouble(), Random.NextDouble(), Random.NextDouble()));
                }
            }
        }
        
        protected override void Cleanup()
        {
        }

        public void CreateBrick(Vec2 pos, Color color)
        {
            var brick = Entities.Create<Brick>();
            brick.Position = new Vec2(brick.Size * pos);
            brick.Color = color;
        }
        
        public override void OnEnter(Scene from)
        {
        }
        
        public override void OnExit(Scene to)
        {
        }
    }
}
