using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject unitychan;
    [SerializeField] GameObject attackarea;
    
     
    void Start()
    {
        attackarea.SetActive(false);
        this.animator = unitychan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            attackarea.SetActive(true);
            this.animator.SetBool("Attack", true);
        }
        else
        {
            this.animator.SetBool("Attack", false);
            attackarea.SetActive(false);
        }
    }
}
