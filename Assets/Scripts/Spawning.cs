using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawning : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform FenemyPrefab;
    public Transform WenemyPrefab;

    public Transform StartPos;

    public Text CountDownText;
    public Text WaveText;
    public Text LivesText;
    public Text CashText;

    public GameObject DeadUI;
    public GameObject AliveUI;

    public int WaveNum = 0;

    public int N_WaveNum = 0;
    public int W_WaveNum = 0;
    public int F_WaveNum = 0;
    public int A_WaveNum = 0;

    public float Timer = 20f;
    public float CountDown = 5f;
    public float WaitBetweenSpawns = 0.75f;
    public float A_WaitBetweenSpawns = 2.5f;

    void Update()
    {

        if (Main.MainHealth <= 0)
        {
            GameOver();
        }
        else
        {
            if (CountDown <= 0)
            {
                if (WaveNum < 3)
                {
                    StartCoroutine(W_WaveSpawn());
                }
                else if (WaveNum < 6)
                {
                    StartCoroutine(N_WaveSpawn());
                }
                else if (WaveNum < 9)
                {
                    StartCoroutine(F_WaveSpawn());
                }
                else
                {
                    StartCoroutine(A_WaveSpawn());
                }

                CountDown = Timer;
            }
        }

        CountDown -= Time.deltaTime;

        CountDownText.text = ("Until Next Round:" + Mathf.Round(CountDown).ToString());

        WaveText.text = ("Wave: " + WaveNum);

        LivesText.text = ("Lives: " + (Main.MainHealth.ToString()));

        CashText.text = ("Cash: " + (Main.MainCash.ToString()));
    }

    IEnumerator W_WaveSpawn()
    {
        WaveNum += 1;
        W_WaveNum += 1;

        for (int i = 0; i < W_WaveNum; i++)
        {
            W_Spawn();
            yield return new WaitForSeconds(WaitBetweenSpawns);
        }


    }

    IEnumerator N_WaveSpawn()
    {
        WaveNum += 1;
        N_WaveNum += 1;

        for (int i = 0; i < N_WaveNum; i++)
        {
            N_Spawn();
            yield return new WaitForSeconds(WaitBetweenSpawns);
        }


    }

    IEnumerator F_WaveSpawn()
    {
        WaveNum += 1;
        F_WaveNum += 1;

        for (int i = 0; i < F_WaveNum; i++)
        {
            F_Spawn();
            yield return new WaitForSeconds(WaitBetweenSpawns);
        }


    }

    IEnumerator A_WaveSpawn()
    {
        WaveNum += 1;
        A_WaveNum += 1;

        for (int i = 0; i < A_WaveNum; i++)
        {
            StartCoroutine(A_Spawn());
            yield return new WaitForSeconds(WaitBetweenSpawns);
        }

        WaitBetweenSpawns += 0.5f;
        A_WaitBetweenSpawns += 1.5f;
        Timer += 10f;

    }

    public void W_Spawn()
    {
        Instantiate(WenemyPrefab, StartPos.position, StartPos.rotation);
    }


    public void N_Spawn()
    {
        Instantiate(enemyPrefab, StartPos.position, StartPos.rotation);
    }

    public void F_Spawn()
    {
        Instantiate(FenemyPrefab, StartPos.position, StartPos.rotation);
    }

    IEnumerator A_Spawn()
    {
        Instantiate(WenemyPrefab, StartPos.position, StartPos.rotation);
        yield return new WaitForSeconds(A_WaitBetweenSpawns);
        Instantiate(enemyPrefab, StartPos.position, StartPos.rotation);
        yield return new WaitForSeconds(A_WaitBetweenSpawns);
        Instantiate(FenemyPrefab, StartPos.position, StartPos.rotation);
        yield return new WaitForSeconds(A_WaitBetweenSpawns);

    }

    void GameOver()
    {

        FastEnemy.FastWalkSpeed = 0f;
        WeakEnemy.WeakWalkSpeed = 0f;
        Enemy.NormalWalkSpeed = 0f;
        DeadUI.SetActive(true);
        AliveUI.SetActive(false);
        CountDown = 9999999999999999f;
    }

}

