using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class InputSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<StateSwichEvent> ecsFilter = null;

        bool stopper;

        void IEcsRunSystem.Run () {
            if (Input.touchCount > 0)
            {
                if (stopper)
                    return;

                if (Input.GetTouch(0).deltaPosition.x > 30)
                {
                    _world.NewEntity().Get<StateSwichEvent>().state = State.RIGHT;
                    stopper = true;
                }

                if (Input.GetTouch(0).deltaPosition.x < -30)
                {
                    _world.NewEntity().Get<StateSwichEvent>().state = State.LEFT;
                    stopper = true;
                }
            }
            else
            if (stopper)
                stopper = false;
        }
    }
}