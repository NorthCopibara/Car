using Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitWorld : MonoBehaviour
{
    public List<GameObject> tiles;

    public float speedParalacs;
    public float tpDistance;
    private int tylesCount;
    public int TylesCount => tylesCount;

    public Transform player;

    public Transform spawn;
    public List<GameObject> obstacles;
    public float dTime;
    public float distance;
    public float complexityDeltaTime;
    public float defoulSpeed;

    public Text coins;

    public GameObject deathConvas;
    public GameObject pauseConvas;
    public Text recordDeath;

    private void Awake()
    {
        tylesCount = tiles.Count;
    }
}
