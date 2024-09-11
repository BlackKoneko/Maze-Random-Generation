using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController controller;
    public float speed;
    Vector3 dir;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v) * speed;

        if(dir != Vector3.zero)
        {

            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(h, v) * Mathf.Rad2Deg, 1 * Time.deltaTime);
        }


        controller.Move(dir*Time.deltaTime);

    }
}
