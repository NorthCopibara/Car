using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Spawn : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<SpawnComponent> ecsFilter_1 = null;
        readonly EcsFilter<ObstaclesComponent> ecsFilter_2 = null;
        readonly EcsFilter<RecordComponent> _record = null;

        void IEcsRunSystem.Run () {
            foreach (var i in ecsFilter_1)
            {
                ecsFilter_1.Get1(i).time += Time.deltaTime;

                if (ecsFilter_1.Get1(i).time > ecsFilter_1.Get1(i).dTime) 
                {
                    float randTime = Random.Range(-ecsFilter_1.Get1(i).dTime / 2, ecsFilter_1.Get1(i).dTime / 2);
                    ecsFilter_1.Get1(i).time = randTime;

                    int who = Random.Range(0, 3);
                    GameObject obs = ecsFilter_1.Get1(i).obstacles[who];

                    var obstacle = _world.NewEntity();
                    ref var obj = ref obstacle.Get<ObstaclesComponent>();
                    obj.defoultSpeed = ecsFilter_1.Get1(i).speedObstacle;

                    float dPos = 0;
                    int pos = Random.Range(0, 1000);
                    if (pos < 333)
                        dPos = ecsFilter_1.Get1(i).distance;
                    else
                    if(pos < 666)
                        dPos = -ecsFilter_1.Get1(i).distance;

                    Vector3 d = new Vector3(dPos, 0, 0);

                    obs = GameObject.Instantiate(obs, ecsFilter_1.Get1(i).transform.position + d, Quaternion.identity) as GameObject;
                    obs.transform.eulerAngles = new Vector3(0, -90, 0);
                    obj.rb = obs.GetComponent<Rigidbody>();
                    obs.AddComponent<CollisionEmitter>().world = _world;


                    if (ecsFilter_1.Get1(i).dTime > 0.6f)
                        ecsFilter_1.Get1(i).dTime -= ecsFilter_1.Get1(i).complexityDeltaTime;

                    ecsFilter_1.Get1(i).speedObstacle += 1;

                    foreach (var x in _record) 
                    {
                        _record.Get1(x).deltaCoins += 1;
                    }

                    foreach (var j in ecsFilter_2)
                    {
                        ecsFilter_2.Get1(j).defoultSpeed = ecsFilter_1.Get1(i).speedObstacle;
                    }
                }
            }
        }
    }
}