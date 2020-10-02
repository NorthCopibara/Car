using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Player: IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<StateSwichEvent> ecsFilter_1 = null;
        readonly EcsFilter<PlayerComponent> ecsFilter_2 = null;
        readonly EcsFilter<PlayerTransform> ecsFilter_3 = null;


        void IEcsRunSystem.Run () {
            foreach (var i in ecsFilter_1)
            {
                switch (ecsFilter_1.Get1(i).state)
                {
                    case State.LEFT:
                        switch (ecsFilter_2.Get1(i).state)
                        {
                            case State.RIGHT:
                                ecsFilter_2.Get1(i).state = State.IDLE;
                                ecsFilter_3.Get1(i).state = State.LEFT;
                                break;
                            case State.IDLE:
                                ecsFilter_2.Get1(i).state = State.LEFT;
                                ecsFilter_3.Get1(i).state = State.LEFT;
                                break;
                            case State.LEFT:
                                break;
                        }
                        break;
                    case State.RIGHT:
                        switch (ecsFilter_2.Get1(i).state)
                        {
                            case State.LEFT:
                                ecsFilter_2.Get1(i).state = State.IDLE;
                                ecsFilter_3.Get1(i).state = State.RIGHT;
                                break;
                            case State.IDLE:
                                ecsFilter_2.Get1(i).state = State.RIGHT;
                                ecsFilter_3.Get1(i).state = State.RIGHT;
                                break;
                            case State.RIGHT:
                                break;
                        }
                        break;
                }

            }
        }
    }
}