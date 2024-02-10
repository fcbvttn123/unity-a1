using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private CharacterController charControl;
    public float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move() {
        float horiz = Input.GetAxis("Horizontal");   
        float vert = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * vert + transform.right * horiz;
        charControl.Move(move);
    }
}
