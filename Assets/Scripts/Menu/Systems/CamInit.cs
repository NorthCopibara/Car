using Leopotam.Ecs;

namespace Client {
    sealed class CamInit : IEcsInitSystem {
        
        readonly EcsWorld _world = null;
        readonly InitMenu init = null;

        public void Init () {
            var cam = _world.NewEntity();
            ref var transform = ref cam.Get<CamComponent>();
            transform.camTransform = init.cam;
        }
    }
}