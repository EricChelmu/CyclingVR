using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool firstVehicleStopped = false;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetVehicleStopped(bool val)
    {
        Debug.Log($"new value {val}");
        firstVehicleStopped = val;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
