using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text TimerText;
    [SerializeField] private float Timer;

    public GameObject Enemy;
    [SerializeField] private int RandomSpawn;
    [SerializeField] private float currentTime;
    private int RandomSpawnCordX;
    private int RandomSpawnCordY;
    public Image[] hearts;
    public Sprite isLife, nonLife;

    //Bools
    public bool isGame;
    void Start()
    {
        RandomSpawn = Random.Range(5, 10);
        isGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
        currentTime += Time.deltaTime;
        StartCoroutine(SpawnRand());
        if(currentTime > RandomSpawn)
        {
            SpawnEnemy();
            currentTime = 0;
            RandomSpawn = Random.Range(5, 10);
        }

    }
    public void SpawnEnemy()
    {
        Instantiate(Enemy, new Vector2(RandomSpawnCordX, RandomSpawnCordY), transform.rotation);
    }
    IEnumerator SpawnRand()
    {
        RandomSpawnCordX = Random.Range(-15, 15);
        RandomSpawnCordY = Random.Range(-15, 15);
        yield return new WaitForSeconds(3);
    }

    private void TimerCount()
    {
        if(isGame)
        {
            Timer += Time.deltaTime;
        }
    }
}
