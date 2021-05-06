using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefab;
    private const float spawnrate = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

   IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnrate);
            Instantiate(prefab[Random.Range(0, prefab.Count)]);
        }
    }
}
