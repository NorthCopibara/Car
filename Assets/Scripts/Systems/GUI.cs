using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Actions;
using Leopotam.Ecs.Ui.Components;
using Qbik;
using Qbik.Game.Save;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client {
    sealed class GUI : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<EcsUiClickEvent> clickActions = null;
        readonly EcsFilter<RecordComponent> _record = null;
        readonly EcsFilter<UIComponent> _gui = null;

        void IEcsRunSystem.Run () {
            foreach (var i in clickActions) 
            {
                switch (clickActions.Get1(i).WidgetName) 
                {
                    case "ReScen":
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Game");
                        break;
                    case "ReScenDeath":
                        int pointsCount = _record.Get1(1).coins;
                        int maxPoints = 0;
                        if (!ChekJson.ChekJsonData("SaveRecord"))
                            maxPoints = GetJson<SaveData>.GetJsonData("SaveRecord")[0].recordPoints;

                        if (maxPoints < pointsCount)
                        {
                            SaveData data = new SaveData(pointsCount);
                            List<SaveData> dataList = new List<SaveData> { data };
                            SetJson<SaveData>.SetJsonData("SaveRecord", dataList);
                        }
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Game");
                        break;
                    case "DeathMenu":
                        int pointsCount_2 = _record.Get1(1).coins;
                        int maxPoints_2 = 0;
                        if (!ChekJson.ChekJsonData("SaveRecord"))
                            maxPoints_2 = GetJson<SaveData>.GetJsonData("SaveRecord")[0].recordPoints;

                        if (maxPoints_2 < pointsCount_2)
                        {
                            SaveData data = new SaveData(pointsCount_2);
                            List<SaveData> dataList = new List<SaveData> { data };
                            SetJson<SaveData>.SetJsonData("SaveRecord", dataList);
                        }
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Menu");
                        break;
                    case "PauseMenu":
                        Time.timeScale = 1;
                        SceneManager.LoadScene("Menu");
                        break;
                    case "PauseStart":
                        _gui.Get1(1).pauseConvas.SetActive(true);
                        Time.timeScale = 0;
                        break;
                    case "PauseStop":
                        _gui.Get1(1).pauseConvas.SetActive(false);
                        Time.timeScale = 1;
                        break;
                }
            }
        }
    }
}