using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    Vector2 input;

    public string animatorHorizontalParamName = "Horizontal";
    public string animatorVerticalParamName = "Vertical";

    public string ainmatorJumpParamName = "Jump";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat(animatorHorizontalParamName, input.x);
        animator.SetFloat(animatorVerticalParamName, input.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(ainmatorJumpParamName);
        }
    }
}
