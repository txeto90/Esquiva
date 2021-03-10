using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager Instance;

    [SerializeField]
    private List<GameObject> bulletsPrefabs;

    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Debug.LogError("PrefabManager has initialised twice. Removing this isntance. Please investigate as this is a singleton case, it only should exist one instance of this class.");
            Destroy(this);
        }
        #endregion
    }

    /// <summary>
    /// Return a random bullet from the availables
    /// </summary>
    public GameObject GetRandomBullet()
    {
        return bulletsPrefabs[UnityEngine.Random.Range(0, bulletsPrefabs.Count)];
    }

}
