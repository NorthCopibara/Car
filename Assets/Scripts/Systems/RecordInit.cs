using Leopotam.Ecs;

namespace Client {
    sealed class RecordInit : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly InitWorld init = null;

        public void Init () {
            var rec = _world.NewEntity();
            ref var record = ref rec.Get<RecordComponent>();
            record.coins = 0;
            record.time = 0;
            record.deltaCoins = 10;
            record.coinsText = init.coins;
        }
    }
}