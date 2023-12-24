using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBody : MonoBehaviour
{
    public Sprite ghost;
    public Sprite body;
    public Animator animator;
    public BoxCollider2D col;

    public static bool inGhost = false;

    // For left behind body.
    public GameObject humanBody;
    public GameObject bodyLeft;
    public GameObject bodyRight;
    public Transform bodyPosition;

    // To determine distance from body when in ghost form.
    [SerializeField] Transform point;
    float distance;


    void Update()
    {
        distance = (point.transform.position - transform.position).magnitude;

        // If not in ghost, become ghost and leave behind body.
        if (Input.GetKey(KeyCode.Space) && inGhost == false){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ghost;
            if (animator.GetFloat("lastX") < 0){
                humanBody = Instantiate(bodyLeft, bodyPosition);
            }
            else if (animator.GetFloat("lastX") > 0){
                humanBody = Instantiate(bodyRight, bodyPosition);
            }
            inGhost = true;
            System.Threading.Thread.Sleep(500);
        }
        // If ghost and close to body, become human.
        else if (distance <= 5f && Input.GetKey(KeyCode.Space)){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = body;
            Destroy(humanBody);
            inGhost = false;
            System.Threading.Thread.Sleep(500);
        }

        if (inGhost == false){
            col.enabled = true;
            animator.SetBool("inGhost", false);
        }
        else if (inGhost == true){
            col.enabled = false;
            animator.SetBool("inGhost", true);
        }
    }
}
