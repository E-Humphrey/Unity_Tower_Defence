using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public Color ColourForHover;
    public Color StartColour;

    private GameObject turret;
    public GameObject TurretPrefab;

    public Renderer _Renderer;

    private void Start()
    {
        _Renderer = GetComponent<Renderer>();
        StartColour = _Renderer.material.color;

    }

    void OnMouseDown()
    {
        if (Main.MainCash < 100)
        {
            _Renderer.material.color = Color.red;
            return;
        }
        else
        {
            if (turret != null)
            {
                Debug.Log("Can't build here");
                return;
            }
            else
            {
                Instantiate(TurretPrefab, transform.position, transform.rotation);
                Main.MainCash -= 100;
            }
            
        }

        
    }

    void OnMouseEnter()
    {
        _Renderer.material.color = ColourForHover;
    }

    void OnMouseExit()
    {
        _Renderer.material.color = StartColour;
    }


    void BuyTurret()
    {

    }
}
