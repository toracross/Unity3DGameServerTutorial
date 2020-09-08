using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public GameObject playerPrefab;

    #region Instance
    public static NetworkManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    #endregion

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Server.Start(50, 26950);
    }

    private void OnApplicationQuit()
    {
        Server.Stop();
    }

    public Player InstantiatePlayer()
    {
        Vector3 spawnPosition = new Vector3(0f, 0.5f, 0f);
        return Instantiate(playerPrefab, spawnPosition, Quaternion.identity).GetComponent<Player>();
    }
}
