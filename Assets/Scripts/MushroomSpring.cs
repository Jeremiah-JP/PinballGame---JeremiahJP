using UnityEngine;

public class FoongusSpring : MonoBehaviour
{
    Light lightbumper;
    ParticleSystem particles;
    float wTimer;

    void Start()
    {
        lightbumper = GetComponent<Light>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop(true);
    }

    void Update()
    {
        if (lightbumper.color == Color.blue)
        {
            wTimer += Time.deltaTime;
        }
        if (wTimer >= 0.5f)
        {
            lightbumper.color = Color.white;
            wTimer = 0;
            particles.Stop(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (lightbumper.color == Color.white)
        {
            lightbumper.color = Color.blue;
            particles.Play(true);

            Vector2 bounceDirection = -collision.contacts[0].normal;
            bounceDirection.Normalize();

            collision.rigidbody.AddForce(bounceDirection * 35, ForceMode2D.Impulse);

            Destroy(gameObject, 0.05f);
        }
    }
}


