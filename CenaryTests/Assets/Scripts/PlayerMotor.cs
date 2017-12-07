using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class PlayerMotor : MonoBehaviour
{


    public float timer;
    public Text tempo;
    public Text bestTime_txt;


    private CharacterController controller;
    public float speed = 6.0f;
    public float otherspeed = 2.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 15.0f;
    public Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    public DeathMenu deathMenuScript;


    public DeathMenu deathMenu;
    // Use this for initialization
    void Start()
    {
        timer = 100f;
        tempo.text = "TIME: " + timer;
        controller = GetComponent<CharacterController>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Time.timeScale = 1;
    }


    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = 0.5f;
            if (CrossPlatformInputManager.GetButton("Jump"))
            {
                verticalVelocity = 6.0f;
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }

        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * 50 * Time.deltaTime, Space.World);
        }


        moveVector.x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * otherspeed;
        moveVector.z = speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);

        timer -= Time.deltaTime;
        tempo.text = ((int)timer).ToString();



        if (timer <= 0.0f)
        {
            speed = 0;
            otherspeed = 0;
            timer = 0;
            //Time.timeScale = 0;
            deathMenuScript.ToggleEndMenu(timer);
        }
    }

    /*void OnCollisionEnter(Collision coll)
    {
        if (gameObject != null && coll.gameObject.CompareTag("prop"))
        {
           // timer = timer - 3.0f;
        }
    }*/

    public void SetSpeed(int modifier)
    {
        speed = 5 + modifier;
    }
}
