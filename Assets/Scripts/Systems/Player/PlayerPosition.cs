using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class PlayerPosition : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<PlayerTransform> ecsFilter_1 = null;

        void IEcsRunSystem.Run () {
            foreach (var i in ecsFilter_1)
            {
                Vector3 pos = ecsFilter_1.Get1(i).newPos;

                switch (ecsFilter_1.Get1(i).state)
                {
                    case State.RIGHT:
                        ecsFilter_1.Get1(i).newPos = new Vector3(pos.x + 3.5f, pos.y, pos.z);
                        ecsFilter_1.Get1(i).state = State.IDLE;
                        break;
                    case State.LEFT:
                        ecsFilter_1.Get1(i).newPos = new Vector3(pos.x - 3.5f, pos.y, pos.z);
                        ecsFilter_1.Get1(i).state = State.IDLE;
                        break;
                    case State.IDLE:
                        break;
                }

                ecsFilter_1.Get1(i).transform.position = Vector3.Lerp(ecsFilter_1.Get1(i).transform.position, pos, 10f * Time.deltaTime);
            }
        }
    }
}