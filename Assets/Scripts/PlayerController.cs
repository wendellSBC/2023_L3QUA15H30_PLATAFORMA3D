using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController playerController;
    public Animator anim;
    public Transform playerTransform;

    public float inputX;
    public float inputZ;
    private Vector3 direction;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;

    void Start()
    {
        
    }
    
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        direction = new Vector3(inputX, 0, inputZ);

        //Debug.Log(inputX + " " + inputZ);

        //VERIFICA SE O PLAYER ESTA NO CHAO
        if (playerController.isGrounded)
        {
            anim.SetBool("isJumping", false);
        }


        //VERIFICA SE A MOVIMENTAÇÃO E NULA
        if (inputX != 0 || inputZ != 0)
        {
            anim.SetBool("isRunning", true);

            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            playerTransform.rotation = Quaternion.LookRotation(lookDirection);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            direction.y = jumpSpeed;
            anim.SetBool("isJumping", true);
        }
        else
        {
            direction.y -= gravity;
        }

        playerController.Move(direction * Time.deltaTime * moveSpeed);

    }

}
