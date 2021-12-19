using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public static int playerSpeed = 5;
    private float gravityValue = -3.0f;
    private Vector3 playerVelocity;

    public Joystick playerJoystick;
    public Joystick cameraJoystick;

    public Transform camTransform;

    public PhotonView view;

    // Update is called once per frame
    void Update()
    {

        if (view.IsMine)
        {
            PlayerMove();
            CameraControls();
        }

    }

    public void PlayerMove()
    {
        //This is for moving the character
        Vector3 move = new Vector3(playerJoystick.Horizontal, 0, playerJoystick.Vertical); //had to flip it (* -1)
        controller.Move(move * Time.deltaTime * playerSpeed); //multiply move vector by time and speed

        // This turns the player to face the direction they are moving in if not zero
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime; //adds the gravity(y) value
        controller.Move(playerVelocity * Time.deltaTime);  //applies gravity
    }

    public void CameraControls()
    {
        Vector3 cameraPos = controller.transform.position;
        cameraPos.y += 7;
        cameraPos.z -= 8;

        camTransform.position = cameraPos;
        camTransform.LookAt(controller.transform.position);

        camTransform.RotateAround(controller.transform.position, Vector3.up, cameraJoystick.Horizontal * 180);
    }

    public void SetJoysticks(GameObject camera) //*
    {
        Joystick[] tempJoystickList = camera.GetComponentsInChildren<Joystick>();
        foreach(Joystick temp in tempJoystickList)
        {
            if (temp.tag == "Movement")
                playerJoystick = temp;
            if (temp.tag == "CameraJoystick")
                cameraJoystick = temp;
        }

        camTransform = camera.transform;
    }

}