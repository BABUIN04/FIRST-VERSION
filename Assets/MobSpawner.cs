using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private List<GameObject> enemys = new List<GameObject>();
    public void Spawn()
    {
        enemys.Add(Object.Instantiate(prefab));
    }
    public void Start()
    {
        //InvokeRepeating("Spawn", 5f, 1f);
        Spawn();
    }
}
