using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, 3f);
        Invoke(nameof(explode), 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void explode()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        animator.SetBool("exploable", true);
    }
}
