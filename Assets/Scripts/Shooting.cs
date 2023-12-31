using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private bool canFire;
    private float timer;

    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > 0.3){
                timer = 0;
                canFire = true;
            }
        }



        if(SwitchBody.inGhost && Input.GetKey(KeyCode.Mouse0) && canFire){
            canFire = false;
            Instantiate(bullet, bulletTransform);
        }
        
    }
}