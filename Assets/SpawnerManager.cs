using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;
    public List<GameObject> spawners;
    public GameObject bulletCanon;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Debug.LogError("caca");
            Destroy(this);
        }
    }

}
