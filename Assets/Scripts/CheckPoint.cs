using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Transform[] CPs;

    void Awake()
    {
        CPs = new Transform[transform.childCount];
        for (int i = 0; i < CPs.Length; i++)
        {
            CPs[i] = transform.GetChild(i);
        }



    }


}
