using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameObject player;
    public bool isFirstStageEnd = false;
    public bool isGameOver = false;
    private bool isEliteGenerated = false;
    public bool isPlayerInMainRoom = false;
    public bool isPlayerInBossRoom = false;
    public PlayerStats playerStats;
    public GameObject[] blueRewardBoxes;
    public GameObject transitionDoor;

    public List<GameObject> enemiesOne = new List<GameObject>();
    public List<GameObject> enemiesTwo = new List<GameObject>();
    public GameObject[] elites;
    public bool playerDead
    {
        get { return player.GetComponent<PlayerStats>().isDead; }
    }
    protected override void Awake()
    {
        base.Awake();
        Time.timeScale = 1;
        player = FindObjectOfType<PlayerController>().gameObject;
        playerStats = player.GetComponent<PlayerStats>();
    }
    private void Update()
    {
        GenerateNextRoundEnemy();
        GenerateRewardBox();
        if (isGameOver) transitionDoor.SetActive(true);
    }
    void GenerateRewardBox()
    {
        if (enemiesOne.Count == 0 && enemiesTwo.Count == 0 && isFirstStageEnd == false)
        {
            isFirstStageEnd = true;
            for (int i = 0; i < blueRewardBoxes.Length; i++)
            {
                blueRewardBoxes[i].SetActive(true);
            }
        }
    }

    void GenerateNextRoundEnemy()
    {
        if (enemiesOne.Count == 0 && isEliteGenerated == false)
        {
            for (int i = 0; i < elites.Length; i++)
            {
                elites[i].SetActive(true);
            }
            isEliteGenerated = true;
        }
    }
}
