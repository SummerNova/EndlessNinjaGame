using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Authoring
{
    public class BuildingMovementAuthoring : MonoBehaviour
    {
         public float3 velocity;
        class Baker : Baker<BuildingMovementAuthoring>
        {
            public override void Bake(BuildingMovementAuthoring authoring)
            {
                AddComponent(new BuildingMovementComponent
                {
                    Value = authoring.velocity
                });
            }
        }
    }
}