using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Enemy"))
        {

        }
        Debug.Log(collision.gameObject.name);
    }
}