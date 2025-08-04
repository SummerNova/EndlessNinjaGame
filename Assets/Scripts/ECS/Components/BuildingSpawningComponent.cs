using Unity.Entities;

namespace ECS.Components
{
    public struct BuildingSpawningComponent : IComponentData
    {
        public float SpawnInterval;
        public float TimeSinceLastSpawn;
        public Entity EasyPrefab;
        public Entity MediumPrefab;
        public Entity HardPrefab;

    }
}