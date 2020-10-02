using Leopotam.Ecs;

namespace Client {
    sealed class GUIInit : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly InitWorld init = null;

        public void Init () {
            var ui = _world.NewEntity();
            ref var gui = ref ui.Get<UIComponent>();
            gui.deathConvas = init.deathConvas;
            gui.pauseConvas = init.pauseConvas;
            gui.recordDeath = init.recordDeath;
        }
    }
}