using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class ObstacleMove : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<ObstaclesComponent> ecsFilter_1 = null;
        

        void IEcsRunSystem.Run () {
            foreach (var i in ecsFilter_1)
            {
                Rigidbody x = ecsFilter_1.Get1(i).rb;
                x.velocity = new Vector3(x.velocity.x, x.velocity.y, -ecsFilter_1.Get1(i).defoultSpeed);
            }
        }
    }
}