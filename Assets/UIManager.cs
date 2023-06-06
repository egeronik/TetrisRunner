using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameMenu;
    [FormerlySerializedAs("EndScoreText")] public TextMeshProUGUI endScoreText;
    [FormerlySerializedAs("MapManager")] public MapManager mapManager;

    
    public void ShowGameOverMenu(int score)
    {
        gameOverMenu.SetActive(true);
        gameMenu.SetActive(false);
        endScoreText.text = score + " POINTS";
    }

    
    public void NewGame()
    {
        gameOverMenu.SetActive(false);
        gameMenu.SetActive(true);
        mapManager.ResetLevel();
        mapManager.SpawnNewTarget();
    }
}
