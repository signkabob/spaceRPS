using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject paper;
    public GameObject rock;
    public GameObject parent;

    public float minX = -7f;
    public float maxX = 7;
    public float minY = -7;
    public float maxY = 7f;

    public float minSpawnTime = 3f;
    public float maxSpawnTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(PauseForSeconds(3f));
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PauseForSeconds(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomInterval = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomInterval);
            Spawn();
        }
    }

    private void Spawn()
    {
        RockSpawn();
        RockSpawn();
        PaperSpawn();
    }

    private void RockSpawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZRotation = Random.Range(0f, 360f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, randomZRotation);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        GameObject rockObject = Instantiate(rock, spawnPosition, spawnRotation);
        rockObject.name = "Rock";
        rockObject.transform.SetParent(parent.transform, true);
    }

    private void PaperSpawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZRotation = Random.Range(0f, 360f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, randomZRotation);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        GameObject paperObject = Instantiate(paper, spawnPosition, spawnRotation);
        paperObject.name = "Paper";
        paperObject.transform.SetParent(parent.transform, true);
    }
}
