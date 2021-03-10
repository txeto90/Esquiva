using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : MonoBehaviour
{

    public static GameFactory Instance;

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
            Debug.LogError("Game Factory has initialised twice. Removing this isntance. Please investigate as this is a singleton case, it only should exist one instance of this class.");
            Destroy(this);
        }
        #endregion
    }

    public GameObject InstantiateObject(GameObject objectToInstantiate, Vector3 position, Quaternion rotation, Transform parent)
    {
        return Instantiate(objectToInstantiate, position, rotation, parent);
    }

}
