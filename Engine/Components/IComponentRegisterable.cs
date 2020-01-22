namespace Altseed
{
    internal interface IComponentRegisterable<in T> where T : Component
    {
        void __AddComponent(T component);
        void __RemoveComponent(T component);
    }
}
