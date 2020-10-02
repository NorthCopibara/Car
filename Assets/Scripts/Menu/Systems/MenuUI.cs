using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine.SceneManagement;

namespace Client {
    sealed class MenuUI : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<EcsUiClickEvent> clickActions = null;

        void IEcsRunSystem.Run () {
            foreach (var i in clickActions)
            {
                switch (clickActions.Get1(i).WidgetName)
                {
                    case "Game":
                        SceneManager.LoadScene("Game");
                        break;
                }
            }
        }
    }
}