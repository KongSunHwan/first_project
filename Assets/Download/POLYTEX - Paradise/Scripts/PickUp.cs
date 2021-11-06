using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpEffect;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Instantiate(PickUpEffect, transform.position, transform.rotation);
            Score.score += 1;
            Destroy(gameObject);
        }
    }
}
