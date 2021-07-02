using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.x < transform.position.x)
        {
            //Left
            anim.SetFloat("Direction", 0);
        }
        else
        {
            //Right
            anim.SetFloat("Direction", 1);
        }
    }
}
