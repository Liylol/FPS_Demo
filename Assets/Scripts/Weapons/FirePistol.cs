using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirePistol : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject flash;
    public bool isFiring = false;
    public AudioSource pistolShoot;
    public float toTarget;



    // Update is called once per frame
    void Update()
    { if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }
        
    }
    IEnumerator FireThePistol()
    {
        isFiring = true;
        toTarget = PlayerCasting.distanceFromTarget;
        Pistol.GetComponent<Animator>().Play("Fire_Pistol");
        pistolShoot.Play();
        flash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        flash.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Pistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
