using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EndGameSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<CollisionEvent> _collision = null;
        readonly EcsFilter<RecordComponent> _record = null;
        readonly EcsFilter<UIComponent> _gui = null;

        void IEcsRunSystem.Run() {
            foreach (var i in _collision)
            {
                if (_collision.Get1(i).tag == null)
                    return;

                if (_collision.Get1(i).tag == "Player")
                {
                    Time.timeScale = 0;
                    _gui.Get1(1).deathConvas.SetActive(true);
                    _gui.Get1(1).recordDeath.text = $"Record: {_record.Get1(1).coinsText.text}";
                }
            }
        }
    }
}