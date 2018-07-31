using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager instance;
    public Inventory sharedInventory;
    public Inventory completeInventory;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F9))
        {
            sharedInventory = completeInventory;
        }
    }
}
