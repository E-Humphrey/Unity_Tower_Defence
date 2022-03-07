using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawning : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform StartPos;

    public Text CountDownText;
    public Text WaveText;

    public int WaveNum = 0;
    public float Timer = 10f;
    public float CountDown = 5f;
    public int EnemyNumber;
    public float WaitBetweenSpawns = 0.35f;

    void Update()
    {
        if (CountDown <= 0)
        {
            StartCoroutine(WaveSpawn());
            CountDown = Timer;
        }

        CountDown -= Time.deltaTime;

        CountDownText.text = Mathf.Round(CountDown).ToString();
        
        WaveText.text = ("Wave: "+WaveNum);
    }

    IEnumerator WaveSpawn()
    {

        WaveNum+=1;

        for (int i = 0; i < WaveNum; i++)
        {
            Spawn();
            yield return new WaitForSeconds(WaitBetweenSpawns);
        }

        
    }

    public void Spawn()
    {
        Instantiate(enemyPrefab, StartPos.position, StartPos.rotation);
    }

}
