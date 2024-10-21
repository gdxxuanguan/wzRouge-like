using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    //private Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        //rd=GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, -30);
    }
}
