using Particles.Scenes;
using TypeOEngine.Typedeaf.Basic2d.Engine.Graphics;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Entities;
using TypeOEngine.Typedeaf.Core.Interfaces;

namespace Particles.Entities
{
    class Particle
    {
        public double Speed { get; set; } = 50;
        public Vec2 Position { get; set; } = Vec2.Zero;
        public Vec2 Velocity { get; set; } = Vec2.Zero;
    }
    
    partial class ParticleManager : Entity, IHasScene<StartScene>
    {
        public Random Random { get; set; }
        public List<Particle> Particles { get; set; }
        public StartScene Scene { get ; set; }
        public bool ParticleSpawned { get; set; } = false;

        // Functions
        protected virtual void InternalInitialize()
        {
            Random = new Random();
            Particles = new List<Particle>();
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Update(double dt)
        {
            if(Particles.Count != ParticlesAmount)
                ParticleSpawned = false;
            if(!ParticleSpawned)
            {
                Particles.Clear();

                for (int i = 0; i < ParticlesAmount; i++)
                {
                    Particles.Add(new Particle() { Position = new Vec2(Random.Next(0, (int)ParticlesGame.ScreenSize.X), Random.Next(0, (int)ParticlesGame.ScreenSize.Y)) });
                }
                ParticleSpawned = true;
            }

            var gravityPoints = Scene.Entities.List<GravityPoint>();
            var repellingPoints = Scene.Entities.List<RepellingPoint>();

            for (int i = 0; i < Particles.Count; i++)
            {
                var particle = Particles[i];

                for (int j = 0; j < gravityPoints.Count; j++)
                {
                    var normDir = Vec2.Direction(particle.Position, gravityPoints[j].Position).Normalize();
                    particle.Velocity += normDir * particle.Speed * dt * gravityPoints[j].Strength;
                }
                for (int j = 0; j < repellingPoints.Count; j++)
                {
                    var normDir = Vec2.Direction(particle.Position, repellingPoints[j].Position).Normalize();
                    particle.Velocity += normDir * -(particle.Speed * (0.25f * repellingPoints[j].Strength) ) * dt;
                }

                particle.Position += particle.Velocity * dt;

                Particles[i] = particle;
            }
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            var gravityPoints = Scene.Entities.List<GravityPoint>();
            var repellingPoints = Scene.Entities.List<RepellingPoint>();

            foreach (var particle in Particles)
            {
                var color = Color.Lerp(Color.Cyan, Color.DarkCyan, particle.Velocity.LengthSquared() / 1000);
                Vec2? closestGravityPoint = null;
                foreach (var gravityPoint in gravityPoints)
                {
                    if (closestGravityPoint is null)
                        closestGravityPoint = gravityPoint.Position;
                    else if (closestGravityPoint?.DistanceSquared(particle.Position) > gravityPoint.Position.DistanceSquared(particle.Position))
                    {
                        closestGravityPoint = gravityPoint.Position;
                    }
                }
                Vec2? closestRepellingPoint = null;
                foreach (var repellingPoint in repellingPoints)
                {
                    if (closestRepellingPoint is null)
                        closestRepellingPoint = repellingPoint.Position;
                    else if (closestRepellingPoint?.DistanceSquared(particle.Position) > repellingPoint.Position.DistanceSquared(particle.Position))
                    {
                        closestRepellingPoint = repellingPoint.Position;
                    }
                }
                if(closestGravityPoint != null)
                    color = Color.Lerp(Color.Red, color, Vec2.Distance(particle.Position, closestGravityPoint.Value) / 100);
                if(closestRepellingPoint != null)
                    color = Color.Lerp(Color.Blue, color, Vec2.Distance(particle.Position, closestRepellingPoint.Value) / 100);

                canvas.DrawRectangle(particle.Position, new Vec2(5, 5), true, color);
            }
        }
    }
}
