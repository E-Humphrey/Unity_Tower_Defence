using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float Speed = 50f;

    public void Find(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float DistTravelled = Speed * Time.deltaTime;


        if (dir.magnitude <= DistTravelled)
        {
            TargetHit();
        }

        transform.Translate(dir.normalized * DistTravelled, Space.World);
    }


    void TargetHit()
    {
        Destroy(gameObject);
    }


}
