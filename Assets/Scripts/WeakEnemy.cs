using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemy : MonoBehaviour
{
    public int Health;

    public int Take_Lives = 1;



    public static float WeakWalkSpeed = 5f;

    public Transform Nextpos;
    public int cpindex;

    void Start()
    {
        Nextpos = CheckPoint.CPs[0];
    }

    void Update()
    {
        Vector3 direction = Nextpos.position - transform.position;
        transform.Translate(direction.normalized * WeakWalkSpeed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, Nextpos.position) <= 0.1f)
        {
            ToNextpos();
        }

    }

    void ToNextpos()
    {

        if (cpindex >= CheckPoint.CPs.Length - 1)
        {
            Main.MainHealth -= Take_Lives;

            Destroy(gameObject);
            return;
        }

        cpindex++;
        Nextpos = CheckPoint.CPs[cpindex];
    }
}
