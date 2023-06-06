using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Serialization;

public class MapManager : MonoBehaviour
{
    #region Publics

    [Header("Objects")] public GameObject roadPrefab;
    public List<GameObject> roads = new List<GameObject>();
    [FormerlySerializedAs("PlayerController")]
    public PlayerController playerController;
    public UIManager uiManager;
    public GameObject target;
    public TextMeshProUGUI TextMeshPro;

    [Header("Speeds")] public float maxSpeed;
    public float startSpeed;
    
    [SerializeField] private float speed;
    public float speedMultiplayer;
    public float spaceMultiplayer;
    
    [Header("Generation")] public int maxRoadCount = 5;
    public float roadOffset = 10;
    public float targetOffset = 20;
    [Header("Misc")] public int score = 0;

    #endregion

    #region Privates

    private GameObject _currentTarget = null;
    private bool speedUp = false;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
        SpawnNewTarget();
    }

    private void Update()
    {
        TextMeshPro.text = score.ToString();     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedUp = true;
        }
    }

    void FixedUpdate()
    {
        if (speed == 0) return;
        var mult = 1f;
        if (speedUp)
        {
            mult = spaceMultiplayer;
        }

        foreach (var road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (_currentTarget)
        {
            _currentTarget.transform.position -= new Vector3(0, 0, mult * speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < -roadOffset)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
            CreateNextRoad();
        }
    }

    public void ResetLevel()
    {
        speedUp = false;
        if (_currentTarget)
            Destroy(_currentTarget);
        _currentTarget = null;
        speed = startSpeed;
        score = 0;

        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }

        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0)
        {
            pos = roads[^1].transform.position + new Vector3(0, 0, roadOffset);
        }

        GameObject go = Instantiate(roadPrefab, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }

    public void SpawnNewTarget()
    {
        if (_currentTarget)
        {
            Debug.Log("Destroying");
            Destroy(_currentTarget);
            _currentTarget = null;
            playerController.allowMovement = true;
            if (speed <= maxSpeed)
                speed *= speedMultiplayer;
            score += (int)(1.5f*speed);
        }

        //Increase score here
        _currentTarget = Instantiate(target, new Vector3(0, 1, targetOffset), Quaternion.identity);
    }

    public void ResetTarget()
    {
        speedUp = false;
        score += (int)(0.5*speed);
        _currentTarget.transform.position = new Vector3(0, 1, targetOffset);
    }

    public void GameOver()
    {
        uiManager.ShowGameOverMenu(score);
    }
}