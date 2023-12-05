using UnityEngine;

public class PokemonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    // Variable für die zusätzliche Rotation
    private Quaternion additionalRotation = Quaternion.identity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Bewegungssteuerung mit den Pfeiltasten
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        // Richtung des Charakters
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            // Nur die Rotation aktualisieren, wenn sich die Richtung ändert
            if (angle != 0)
            {
                // Setze die zusätzliche Rotation basierend auf der Himmelsrichtung
                SetAdditionalRotation(angle);

                // Animationen steuern basierend auf der Richtung
                UpdateAnimations(movement);
            }
        }
        else
        {
            // Wenn keine Bewegung stattfindet, stoppe den Charakter und spiele die Idle-Animation
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0f);
        }

        // Charakter bewegen
        rb.velocity = movement * moveSpeed;
    }

    void UpdateAnimations(Vector2 movement)
    {
        // Setze die entsprechende Richtungsanimation
        animator.SetFloat("Speed", 1f);

        // Feststellen, in welche Himmelsrichtung sich der Charakter bewegt
        if (movement.x > 0)
        {
            // Bewegung nach rechts
            animator.Play("RightAnimation");
        }
        else if (movement.x < 0)
        {
            // Bewegung nach links
            animator.Play("LeftAnimation");
        }

        if (movement.y > 0)
        {
            // Bewegung nach oben
            animator.Play("UpAnimation");
        }
        else if (movement.y < 0)
        {
            // Bewegung nach unten
            animator.Play("DownAnimation");
        }
    }

    void SetAdditionalRotation(float angle)
    {
        // Setze die zusätzliche Rotation basierend auf der Himmelsrichtung
        if (angle > -45 && angle <= 45)
        {
            // Bewegung nach rechts
            additionalRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (angle > 45 && angle <= 135)
        {
            // Bewegung nach oben
            additionalRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (angle > 135 || angle <= -135)
        {
            // Bewegung nach links
            additionalRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (angle > -135 && angle <= -45)
        {
            // Bewegung nach unten
            additionalRotation = Quaternion.Euler(0f, 0f, 0);
        }

        // Setze die zusätzliche Rotation für den Charakter
        transform.rotation = additionalRotation;
    }
}
