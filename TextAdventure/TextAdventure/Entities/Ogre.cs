using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Entities;

namespace TextAdventure.Entities
{
    partial class Ogre : Entity
    {
        // Functions
        protected virtual void InternalInitialize()
        {
        }
        
        protected override void Cleanup()
        {
        }
        
        public virtual void Update(double dt)
        {
        }
        
        public virtual void Draw(ICanvas canvas)
        {
            Console.WriteLine("OGRE!");
        }
    }
}
