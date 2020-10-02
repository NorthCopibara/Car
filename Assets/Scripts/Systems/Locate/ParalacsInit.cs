using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class ParalacsInit : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly InitWorld init = null;

        public void Init() {
            for (int i = 0; i < init.tiles.Count; i++) {
                var tiles = _world.NewEntity();
                ref var rbTiles = ref tiles.Get<RbComponent>();
                ref var propertyTiles = ref tiles.Get<LocateProperty>();

                rbTiles.rb = init.tiles[i].GetComponent<Rigidbody>();

                propertyTiles.speed = init.speedParalacs;
                propertyTiles.tpDistance = init.tpDistance;
                propertyTiles.tylesCount = init.TylesCount;
            }
        }
    }
}