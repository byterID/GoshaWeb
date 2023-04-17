using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject deadPanel;
    Animator anim;

    public int Score;
    public Text ScoreText;
    //Bools
    public bool isGame;
    void Start()
    {
        anim = deadPanel.GetComponent<Animator>();
        RandomSpawn = Random.Range(5, 10);
        isGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
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
    public void ShowDeadCanvas()
    {
        deadPanel.SetActive(true);
        anim.Play("DeadAnim");
    }
}
