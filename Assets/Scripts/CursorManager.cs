using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        ChangeCursorLockMode(CursorLockMode.Confined);
    }

    public void ChangeCursorLockMode(CursorLockMode lockState)
    {
        Cursor.lockState = lockState;
    }
}
