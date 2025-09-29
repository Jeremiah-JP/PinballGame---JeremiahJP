using UnityEngine;

public class MagnetBumper : MonoBehaviour
{

    Light lights;
    ParticleSystem particles;
    float timer = 0;
    float hit;

   // [SerializeField] private ParticleSystem particles;
    private ParticleSystem particlesInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hit = 0;
        GetComponent<PointEffector2D>().enabled = false;
        lights = GetComponent<Light>();
        particles = GetComponent<ParticleSystem>();
        particles.Stop(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PointEffector2D>().enabled == true)
        {
            timer += Time.deltaTime;
            lights.color = Color.cyan;
            particles.Play(true);
        }
        if (timer > 1.2)
        {
            GetComponent<PointEffector2D>().enabled = false;
            lights.color = Color.white;
            particles.Stop(true);
            timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<PointEffector2D>().enabled = true;
        timer = 0;
    }

}


