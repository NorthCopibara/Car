using Leopotam.Ecs;

namespace Client {
    sealed class SpawnInit : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly InitWorld init = null;

        public void Init () {
            var spawn = _world.NewEntity();
            ref var obstacles = ref spawn.Get<SpawnComponent>();
            obstacles.complexityDeltaTime = init.complexityDeltaTime;
            obstacles.obstacles = init.obstacles;
            obstacles.dTime = init.dTime;
            obstacles.distance = init.distance;
            obstacles.time = 0;
            obstacles.transform = init.spawn;
            obstacles.speedObstacle = init.defoulSpeed;
        }
    }
}