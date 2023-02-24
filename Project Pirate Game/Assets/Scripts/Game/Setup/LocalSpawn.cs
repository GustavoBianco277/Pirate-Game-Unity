using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpawn : MonoBehaviour
{
    [Tooltip("Prefab that will Spawn")]
    [SerializeField] private GameObject SpawnPrefab;

    [Tooltip("Time to spawn")]
    [SerializeField] private float SpawnTime = 30;

    [Tooltip("If spawn is visible")]
    [SerializeField] private bool IsVisible = false;

    public bool Actived = true; // Active Spawn

    // Privates
    private DurationMatch Match;
    private Transform SpawnLocal;
    private float Timer;

    void Start()
    {
        Match = FindObjectOfType<DurationMatch>();
        SpawnLocal = GameObject.Find("EnemyShips").transform;
        Spawner();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnTime && !Match.EndOfGame)
            Spawner();

        else if (Match.EndOfGame)
        {
            foreach(Transform child in SpawnLocal.transform)
            {
                Destroy(child.gameObject);
            }
        }

    }
    private void OnBecameVisible()
    {
        IsVisible= true;
        print("visible");
    }

    private void OnBecameInvisible()
    {
        IsVisible= false;
        print("invisible");
    }

    private void Spawner()
    {
        if (Actived && !IsVisible)
        {
            Instantiate(SpawnPrefab, SpawnLocal);
            Timer = 0;
        }
    }
}
