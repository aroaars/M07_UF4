using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    private float range = 1.1f;
    private Vector3 offset = new Vector3(0,1f,0);
    private  Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + offset, -transform.up);
        Debug.DrawLine(transform.position +offset, transform.position +offset -transform.up * range, Color.red); //offset = new Vector3 (0,1f,0)
        if(Physics.Raycast(ray, out hit, range))
        {
            //Debug.DrawLine(transform.position + new Vector3(0,1f,0), -transform.up * hit.distance * range, Color.red);
            if(hit.collider.gameObject.layer == 6)
            {
                animator.SetBool("Grounded", true);
            }
            else
            {
                animator.SetBool("Grounded", false);
            }

        }

        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

         if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }
}
