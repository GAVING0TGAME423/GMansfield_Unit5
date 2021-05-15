using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> prefab;
    private float spawnrate = 2f;
    public TextMeshProUGUI Scoretext;
    public TextMeshProUGUI GameOverText;
    public bool gameactive = false;
    public Button Restart;
    public GameObject titlescreen;
    private int score = 0;

    public void StartGame(int difficulty)
    {
        gameactive = true;
        score = 0;
        spawnrate = spawnrate / difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titlescreen.gameObject.SetActive(false);

    }

    void Start()
    {    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        gameactive = false;
        Restart.gameObject.SetActive(true);
    }

   IEnumerator SpawnTarget()
    {
        while (gameactive == true)
        {
            yield return new WaitForSeconds(spawnrate);
            Instantiate(prefab[Random.Range(0, prefab.Count)]);
           
        }
    }
   public void UpdateScore(int scoredelta)
    {
        score += scoredelta;
        if (score < 0)
        {
            score = 0;
        }
        Scoretext.text = "Score: " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}