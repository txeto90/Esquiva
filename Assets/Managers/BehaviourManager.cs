using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{

    // Static access to the class
    public static BehaviourManager Instance;

    private List<IBulletSpawner> spawners;
    private List<IBulletMovement> bulletMovements;

    void Awake()
    {
        #region Singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Debug.LogError("SpawnerManager has initialised twice. Removing this isntance. Please investigate as this is a singleton case, it only should exist one instance of this class.");
            Destroy(this);
        }
        #endregion

        // Find and register all shoot spawners patterns types
        RegisterAllSpawnersPatterns();

        // Find and register all bullets movement types
        RegisterAllBulletMovementPattern();
    }

    /// <summary>
    /// This functions, search in assemblies all the classes that inherite from "IBulletSpawner", create an instance of the class and add them to the Collection<T>.
    /// Automatically find all the IBulletSpawner and add them to the Collection<T>
    /// </summary>
    private void RegisterAllSpawnersPatterns()
    {
        if (spawners == null)
        {
            spawners = new List<IBulletSpawner>();
        }

        // Basically , get all types in assemblies , then get the interfaces that contains "IBulletSpawner"
        // this will give us all the classes that inheritance from IBulletSpawner, so we can add them to our own array not need of register anything manually.
        foreach (Type bulletSpawnerType in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                 .Where(mytype => mytype.GetInterfaces().Contains(typeof(IBulletSpawner))))
        {

            Debug.Log(string.Format("Found Spanwer type with name  [{0}]. Initialising and adding to list of spawner availables.", bulletSpawnerType.Name));

            // Create a instance of the type found
            var obj = Activator.CreateInstance(bulletSpawnerType);

            // cast the new instance and add it to the array
            spawners.Add((IBulletSpawner)obj);

        }

    }
    /// <summary>
    /// This functions, search in assemblies all the classes that inherite from "IBulletMovement", create an instance of the class and add them to the Collection<T>.
    /// Automatically find all the IBulletMovement and add them to the Collection<T>
    /// </summary>
    private void RegisterAllBulletMovementPattern()
    {
        if (bulletMovements == null)
        {
            bulletMovements = new List<IBulletMovement>();
        }

        // Basically , get all types in assemblies , then get the interfaces that contains "IBulletSpawner"
        // this will give us all the classes that inheritance from IBulletSpawner, so we can add them to our own array not need of register anything manually.
        foreach (Type bulletMovementType in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                 .Where(mytype => mytype.GetInterfaces().Contains(typeof(IBulletMovement))))
        {

            Debug.Log(string.Format("Found Bullet Movement type with name  [{0}]. Initialising and adding to list of bullet movement availables.", bulletMovementType.Name));

            // Create a instance of the type found
            var obj = Activator.CreateInstance(bulletMovementType);

            // cast the new instance and add it to the array
            bulletMovements.Add((IBulletMovement)obj);

        }

    }

    /// <summary>
    /// Return a random spawner from the availables
    /// </summary>
    public IBulletSpawner GetRandomShooter()
    {
        return spawners[UnityEngine.Random.Range(0, spawners.Count)];
    }

    /// <summary>
    /// Return a random bullet movement from the availables
    /// </summary>
    public IBulletMovement GetRandomBulletMovement()
    {
        // return bulletMovements[UnityEngine.Random.Range(0, bulletMovements.Count)];
        return bulletMovements[0];
    }

}
