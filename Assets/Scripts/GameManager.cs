using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefab;
    private const float spawnrate = 1.5f;
    public TextMeshProUGUI Scoretext;
    private int score = 0;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

   IEnumerator SpawnTarget()
    {
        while (true)
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
}