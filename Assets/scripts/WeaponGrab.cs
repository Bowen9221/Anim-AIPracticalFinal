using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrab : MonoBehaviour
{
    public GameObject weapon;
    public Transform HoldPoint;
    private bool isHoldingDagger = false;
    private bool isHoldingAxe = false;

    void Start()
    {
        weapon = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (!isHoldingDagger && !isHoldingAxe)
            {
                Debug.Log("Press E To Equip");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingDagger = true;
                    weapon.transform.position = HoldPoint.transform.position;
                }
            }
            else if (!isHoldingDagger && isHoldingAxe)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingAxe = false;
                    isHoldingDagger = true;
                }
            }
        }
    }
}
