using Qbik;
using Qbik.Game.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMenu : MonoBehaviour
{
    public Transform cam;

    public Text record;

    private void Awake()
    {
        int pointRecord = 0;
        if (!ChekJson.ChekJsonData("SaveRecord"))
            pointRecord = GetJson<SaveData>.GetJsonData("SaveRecord")[0].recordPoints;

        record.text = $"Record: {pointRecord}";
    }
}
