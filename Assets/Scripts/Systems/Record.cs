using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Record : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<RecordComponent> _record = null;

        void IEcsRunSystem.Run () {
            foreach (var j in _record)
            {
                _record.Get1(j).time += Time.deltaTime * 100;

                if (_record.Get1(j).time > 2)
                {
                    _record.Get1(j).time = 0;
                    _record.Get1(j).coins += _record.Get1(j).deltaCoins;
                    _record.Get1(j).coinsText.text = _record.Get1(j).coins.ToString();
                }
            }
        }
    }
}