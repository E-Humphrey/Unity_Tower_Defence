using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    private Transform target;
    public Transform RotatePart;

    public GameObject BulletPrefab;

    public Transform PointToFire;

    public float range = 35f;

    public string TagForEnemy = ("Enemy");

    public float FireRate = 1f;
    private float FireCountDown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TargetEnemy", 0f, 0.5f);
    }

    void TargetEnemy()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(TagForEnemy);

        float ShortestDistance = Mathf.Infinity;
        GameObject ClosestEnemy = null;

        foreach (GameObject enemy in Enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ClosestEnemy = enemy;
            }
        }

        if (ClosestEnemy != null && ShortestDistance <= range)
        {
            target = ClosestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 Rotation = lookRotation.eulerAngles;
        RotatePart.rotation = Quaternion.Euler(0f, Rotation.y, 0f);

        if (FireCountDown <= 0)
        {
            Fire();
            FireCountDown = 1f / FireRate;
        }
        FireCountDown -= Time.deltaTime;

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Fire()
    {
        GameObject BulletObject = (GameObject)Instantiate(BulletPrefab, PointToFire.position, PointToFire.rotation);
        Bullet bullet = BulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Find(target);
        }
    }

}
