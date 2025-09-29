using UnityEngine;

public class Bumpers : MonoBehaviour
{

    Light lightbumper;
    ParticleSystem particles;
    float wTimer;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightbumper = GetComponent<Light>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(lightbumper.color == Color.blue)
        {
            wTimer += Time.deltaTime;
        }
        if(wTimer >= 0.5)
        {
            lightbumper.color = Color.white;
            wTimer = 0;
            particles.Stop(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(lightbumper.color == Color.white)
        {
            lightbumper.color = Color.blue;
            particles.Play(true);
            
            Vector2 bounceDirection = -collision.contacts[0].normal;
            bounceDirection.x += Random.Range(-0.8f, 0.8f); 
            bounceDirection.Normalize();
            collision.rigidbody.AddForce(bounceDirection * 20, ForceMode2D.Impulse);
          
        }
        
    }
}
