using System.Collections;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public int WaveNum = 1;
    public int Timer = 10;
    public int CountDown = 5;
    public int EnemyNumber;

    void Update()
    {
        if (CountDown <= 0)
        {
            WaveSpawn();
        }
    }

    public void WaveSpawn()
    {

    }

}
