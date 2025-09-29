using UnityEngine;

public class PinballBall : MonoBehaviour
{
    //serialize field gives lets me set the variable in the inspector
    //without having to make that variable public
    AudioSource myAudioSource;

    [SerializeField]
    Rigidbody2D myBody; //var ref to this game object's rigidbody

    [SerializeField]
    PinballManager myManager;

    [SerializeField]
    AudioClip bumperClip, launcherClip, flipperHit, miniClip, teleporterClip, magnetClip, springClip;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the left mouse button is pressed
       // if (Input.GetMouseButtonDown(0))
        {
            //set the ball's body to dynamic (allow physics forces to act on it)
          //  myBody.bodyType = RigidbodyType2D.Dynamic;
         //   myBody.linearVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
      
        switch (collision.gameObject.tag)
        {
            case "Bumper":
                myBody.AddForce(transform.up * 350);
                myAudioSource.PlayOneShot(bumperClip);
                myManager.AddScore(200);
                break;
            case "Launcher":
                myAudioSource.PlayOneShot(launcherClip);
                break;
            case "MiniBumper":
                myAudioSource.PlayOneShot(miniClip);
                myManager.AddScore(25);
                break;
            case "Spring":
                myAudioSource.PlayOneShot(springClip);
                myManager.AddScore(1500);
                break;
            case "Flipper":
                myBody.AddForce(transform.up * 350);
                myAudioSource.PlayOneShot(flipperHit);
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("direction"))
        {
            myManager.AddScore(100);
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up * 10;
        }
        else if (collision.CompareTag("Teleporter"))
        {
            myAudioSource.PlayOneShot(teleporterClip);
            myManager.AddScore(1000);
        }
        else if (collision.CompareTag("Magnet"))
        {
            myAudioSource.PlayOneShot(magnetClip);
            myManager.AddScore(250);

            ;
        }
    }
}
