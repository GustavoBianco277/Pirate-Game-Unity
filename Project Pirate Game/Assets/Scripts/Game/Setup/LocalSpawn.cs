using UnityEngine;

public class LocalSpawn : MonoBehaviour
{
    [Tooltip("Prefabs that will Spawn")]
    [SerializeField] private GameObject[] SpawnPrefab;

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
        SpawnTime = PlayerPrefs.GetInt("Spawntime") * 10;
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
    }

    private void OnBecameInvisible()
    {
        IsVisible= false;
    }

    private void Spawner()
    {
        if (Actived && !IsVisible)
        {
            GameObject ship = Instantiate(SpawnPrefab[Random.Range(0,SpawnPrefab.Length)], transform.position, transform.rotation);
            ship.transform.SetParent(SpawnLocal);
            Timer = 0;
        }
    }
}
