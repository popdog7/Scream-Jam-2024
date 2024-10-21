using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    public float speed = 5f;

    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jump_height = 3f;

    private bool is_grounded;

    public gameInput gameInput;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        gameInput.on_jump_action += GameInput_on_jump_action;
    }


    private void Update()
    {
        is_grounded = controller.isGrounded;
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        Vector2 input = gameInput.getMovementVector();

        Vector3 movementDirection = new Vector3(input.x, 0, input.y);
        controller.Move(transform.TransformDirection(movementDirection) * (speed * Time.deltaTime));

        velocity.y += gravity * Time.deltaTime;
        if (is_grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void GameInput_on_jump_action(object sender, System.EventArgs e)
    {
        if (is_grounded)
        {
            velocity.y = Mathf.Sqrt(jump_height * -3f * gravity);
        }
    }
}
