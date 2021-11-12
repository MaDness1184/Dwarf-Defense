using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    public GameObject winLabel;
    public GameObject gameOverLabel;
    public float waitToLoad = 12f;
    private bool isActive = false;

    public void Start()
    {
        winLabel.SetActive(false);
        gameOverLabel.SetActive(false);
        
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(WinnerCo());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    private IEnumerator WinnerCo()
    {
        if (!isActive)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad);
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    public void HandleGameOverCondition()
    {
        gameOverLabel.SetActive(true);
        gameOverLabel.GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        isActive = true;
    }
}
