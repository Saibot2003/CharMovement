using UnityEngine;

public class PokemonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    private Animator animator;

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
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * rotationSpeed);

            // Animationen steuern basierend auf der Richtung
            UpdateAnimations(movement);
        }
        else
        {
            // Wenn keine Bewegung stattfindet, spiele die Idle-Animation
            animator.SetFloat("Speed", 0f);
        }

        // Charakter bewegen
        rb.velocity = movement * moveSpeed;
    }

    void UpdateAnimations(Vector2 movement)
    {
        // Berechnung des Winkels
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

        // Feststellen, in welche Himmelsrichtung sich der Charakter bewegt
        if (angle > -45 && angle <= 45)
        {
            // Bewegung nach rechts
            PlayAnimation("Right");
        }
        else if (angle > 45 && angle <= 135)
        {
            // Bewegung nach oben
            PlayAnimation("Up");
        }
        else if (angle > 135 || angle <= -135)
        {
            // Bewegung nach links
            PlayAnimation("Left");
        }
        else if (angle > -135 && angle <= -45)
        {
            // Bewegung nach unten
            PlayAnimation("Down");
        }
    }

    void PlayAnimation(string direction)
    {
        // Setze die entsprechende Richtungsanimation
        animator.SetFloat("Speed", 1f);
        animator.Play(direction + "Animation");
    }
}
