using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttribute{
    public static int health = 100;
    public static int mana = 100;
    public static float movementSpeed = 10f;
    public static Rigidbody2D rigidBody;
}

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioFx;
    public AudioClip canonFx;
    public float move;
    private float yUpBound = 2.45f;
    private float yBottomBound = -4.25f;

    private ContactPoint2D lastContactPoint;
    private Vector2 trajectoryOrigin;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttribute.rigidBody = GetComponent<Rigidbody2D>();
        audioFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement(){
        
        move = Input.GetAxis("Vertical1") * PlayerAttribute.movementSpeed * Time.deltaTime;
        float position = transform.position.y + move;
        if (position > yUpBound)
        {
            move = 0;
        }
        if (position < yBottomBound)
        {
            move = 0;
        }
        transform.Translate(0, move, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ball"){
            lastContactPoint = collision.GetContact(0);
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball"){
            audioFx.PlayOneShot(canonFx);
        }
        trajectoryOrigin = transform.position;
    }

    public ContactPoint2D LastContactPoint()
    {
        return lastContactPoint;
    }

    public Vector2 TrajectoryOrigin()
    {
        return trajectoryOrigin;
    }
}
