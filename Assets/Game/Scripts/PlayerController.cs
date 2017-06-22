using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float rotateSpeed;
    public float speed;

    public CallMixinActions fireWeapon;
    public KeyCode fire1;

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalAxis * speed);
        transform.Rotate(Vector3.up * rotateSpeed * horizontalAxis);

        if(Input.GetKey(fire1))
        {
            fireWeapon.CallActions();
        }
    }
}
