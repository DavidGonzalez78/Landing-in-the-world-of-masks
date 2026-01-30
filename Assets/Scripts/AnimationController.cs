using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite[] walkSprites;   // spritesheet separado en frames
    public float animationSpeed = 10f;

    [Header("Movement")]
    public Rigidbody rb;           // o asigna velocidad manualmente
    public float minMoveSpeed = 0.1f;

    private SpriteRenderer sr;
    private float frameTimer;
    private int currentFrame;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;

        // ───── PERSONAJE PARADO ─────
        if (speed < minMoveSpeed)
        {
            currentFrame = 0;
            frameTimer = 0f;
            sr.sprite = walkSprites[0];
            return;
        }

        // ───── ANIMACIÓN SEGÚN VELOCIDAD ─────
        frameTimer += Time.deltaTime * speed * animationSpeed;

        if (frameTimer >= 1f)
        {
            frameTimer = 0f;
            currentFrame = (currentFrame + 1) % walkSprites.Length;
            sr.sprite = walkSprites[currentFrame];
        }

        // ───── MIRROR IZQ / DER ─────
        if (rb.velocity.x != 0)
        {
            sr.flipX = rb.velocity.x < 0;
        }
    }
}
