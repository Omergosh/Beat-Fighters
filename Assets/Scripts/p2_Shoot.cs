using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2_Shoot : MonoBehaviour {
    public GameObject bullet;
    private Transform firePos;

    private void Start()
    {
        firePos = transform.Find("firePos2");
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown("j"))
        {
            Fire();
        }
	}   

    void Fire()
    {
        Instantiate(bullet, firePos.position, Quaternion.identity);
    }
}
