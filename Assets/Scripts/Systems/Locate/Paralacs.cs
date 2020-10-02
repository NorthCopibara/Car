using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Paralacs : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsFilter<RbComponent, LocateProperty> ecsFilter = null;

        void IEcsRunSystem.Run () {
            foreach (var i in ecsFilter)
            {
                Rigidbody x = ecsFilter.Get1(i).rb;
                x.velocity = new Vector3(x.velocity.x, x.velocity.y, -ecsFilter.Get2(i).speed);

                if (x.transform.localPosition.z < -ecsFilter.Get2(i).tpDistance * 2)
                {
                    x.transform.localPosition = new Vector3(x.transform.localPosition.x, x.transform.localPosition.y, ecsFilter.Get2(i).tpDistance * 2 * (ecsFilter.Get2(i).tylesCount - 1));
                }
            }
        }
    }
}