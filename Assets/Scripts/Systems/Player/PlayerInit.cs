using Leopotam.Ecs;
using System.Xml;

namespace Client {
    sealed class PlayerInit : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly InitWorld init = null;

        public void Init () {
            var playerEntity = _world.NewEntity();
            ref var player = ref playerEntity.Get<PlayerComponent>();
            ref var playerTransform = ref playerEntity.Get<PlayerTransform>();


            playerTransform.newPos = init.player.position;
            playerTransform.transform = init.player;
            playerTransform.state = State.IDLE;
            player.state = State.IDLE;
        }
    }
}