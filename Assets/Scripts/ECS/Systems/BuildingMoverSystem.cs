using ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace ECS.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct BuildingMoverSystem : ISystem
    {
        private float Timer;
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            Timer += deltaTime;
            // Create a command buffer to queue entity destruction
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (var (transform, velocity, entity) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRW<BuildingMovementComponent>>().WithEntityAccess())
            {
                transform.ValueRW.Position += velocity.ValueRW.Value * (math.clamp(Timer * 0.05f, 1, 10)) * deltaTime;

                if (transform.ValueRW.Position.x < -50f)
                {
                    ecb.DestroyEntity(entity);
                }
            }

            // Playback the commands (actually destroy the entities)
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}