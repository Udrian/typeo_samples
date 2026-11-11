using TypeOEngine.Typedeaf.Core;

namespace TextAdventure.Scenes
{
    partial class StartScene : Scene
    {
        // Functions
        protected virtual void InternalInitialize()
        {
        }
        
        protected override void Cleanup()
        {
        }
        
        public override void OnEnter(Scene from)
        {
            Console.WriteLine($"Hello");
            var input = Console.ReadLine();
            Console.WriteLine($"You wrote: {input}");
        }
        
        public override void OnExit(Scene to)
        {
        }
    }
}
