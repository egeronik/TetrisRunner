using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class KillScript : MonoBehaviour
{

    private MapManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        manager = GameObject.Find("/GameMaster").GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // manager.GameOver();
        manager.GameOver();
        Debug.Log("Game Over");
    }
}
