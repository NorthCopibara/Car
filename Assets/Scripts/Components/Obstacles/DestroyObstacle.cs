using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class DestroyObstacle : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<CollisionEvent> _collision = null;
        readonly EcsFilter<ObstaclesComponent> ecsFilter_1 = null;

        void IEcsRunSystem.Run () {
            foreach (var i in _collision)
            {
                foreach (var j in ecsFilter_1) 
                {
                    if (_collision.Get1(i).obj == ecsFilter_1.Get1(j).rb.gameObject.transform) 
                    {
                        GameObject.Destroy(ecsFilter_1.Get1(j).rb.gameObject);
                        ecsFilter_1.GetEntity(j).Destroy();
                        break;
                    }
                }
            }
        }
    }
}