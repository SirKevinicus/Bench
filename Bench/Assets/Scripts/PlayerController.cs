using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // REFS
    Animator animator;
    Transform cameraT;
    CameraManager cameraManager;
    CharacterController controller;

    // MOVE
    public float walkSpeed = 2;
    public float runSpeed = 6;
    float currentSpeed;

    // GROUND
    bool isGrounded;
    public GameObject groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.1f; // radius of the CheckSphere method

    // JUMP
    float velocityY;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float gravity = -19;
    public float jumpHeight = 1;
    [Range(0,1)]
    public float airControlPercent;

    // SMOOTHING
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cameraManager = GameObject.Find("CamManager").GetComponent<CameraManager>();
        cameraT = cameraManager.getDefaultCamera().transform;

        // PLACE THE GROUND CHECK SO THE BOTTOM OF THE SPHERE IS JUST BELOW THE MODEL.
        groundCheck.transform.localPosition = new Vector3(0,groundDistance - 0.07f,0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        Vector2 inputDir = input.normalized;

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);

        // Check if running
        bool running = Input.GetKey(KeyCode.LeftShift);

        Fall();

        // Jump
        if(Input.GetKeyDown (KeyCode.Space)){
            Jump();
        }

        // Move
        if(cameraManager.isThirdPerson())
            ThirdPersonMove(inputDir, running);
        else if(cameraManager.isFirstPerson())
            FirstPersonMove(inputDir,running);

        // ANIMATOR
        float animationSpeedPercent = ((running)? currentSpeed/runSpeed : currentSpeed/walkSpeed * .5f);
        animator.SetFloat("speedPercent", animationSpeedPercent, GetModifiedSmoothTime(speedSmoothTime), Time.deltaTime);
    }

/*=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    Movement
  =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+*/

    void FirstPersonMove(Vector2 inputDir, bool running){
        // set the speed depending on if we're running
        // the inputDir.magnitude ensures this method works for joysticks
        float targetSpeed = ((running)? runSpeed : walkSpeed) * inputDir.magnitude;
        // the ref keyword means this variable won't be updated outside of the SmoothDamp function
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        Vector3 move = transform.right * inputDir.x + transform.forward * inputDir.y;
        controller.Move(move * currentSpeed * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
    }

    void ThirdPersonMove(Vector2 inputDir, bool running){
        // If a non-zero input is detected, rotate the character to face the direction the camera is facing
        if (inputDir != Vector2.zero){
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        float targetSpeed = ((running)? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));
        
        controller.Move(transform.forward * currentSpeed * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
    }

/*=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    Jump / Fall
  =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+*/

    void Jump(){
        if(isGrounded){
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
            controller.Move(Vector3.up * jumpVelocity * Time.deltaTime);
        } else {
            print("NOT GROUNDED");
        }
    }

    void Fall(){
        if(isGrounded && velocityY < 0){
            velocityY = -2f;
        } else {
            velocityY += Time.deltaTime * gravity;
            controller.Move(Vector3.up * velocityY * Time.deltaTime);
        }
    }

    // reduce air control
    float GetModifiedSmoothTime(float smoothTime){
        //if character is grounded, don't modify the smooth time
        if(controller.isGrounded) return smoothTime;

        // return infinite smooth time (since we can't divide by zero below)
        if(airControlPercent == 0) return float.MaxValue;

        // if the player is in the air, reduce the smooth time / control by airControlPercent
        return smoothTime / airControlPercent;
    }

/*=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    Camera
  =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+*/

    public void ChangeCameraMode(Transform newCameraTransform){
        cameraT = newCameraTransform;
    }

/*=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    Debug
  =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+*/

    private void OnDrawGizmos() {
        
        //Show the ground collision sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundDistance);
       
    }
}
