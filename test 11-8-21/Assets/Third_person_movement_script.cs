using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_person_movement_script : MonoBehaviour
{
   public CharacterController controller;
   public Transform cam;
   public float speed = 6f;
   public float tunrSmoothTime = 0.1f;
   float turnSmoothVelocity;
   Vector3 velocity;
   public float gravity = -9.81f;
   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;
   bool isGrounded;
   Vector3 moveDirection;
   public float jumpHeight = 3f;

  
   
   
 
 

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0 ){
            velocity.y = -2f;
        }

        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;       

        if (direction.magnitude >= 0.1f){
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, tunrSmoothTime );
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            controller.Move(moveDirection.normalized*speed*Time.deltaTime);
            
        }
          
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
           velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
         }  

          
         controller.Move(moveDirection.normalized*speed*Time.deltaTime);
         velocity.y += gravity*Time.deltaTime;
         controller.Move(velocity*Time.deltaTime);
            
    }
}
