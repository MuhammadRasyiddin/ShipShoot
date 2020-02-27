using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAttribute{
    public static int health = 100;
    public static int mana = 100;
    public static float movementSpeed = 10f;
    public static Rigidbody2D rigidBody;
}

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioFx;
    public AudioClip canonFx;
    public float move;
    private float yUpBound = 2.45f;
    private float yBottomBound = -4.25f;
    private ContactPoint2D lastContactPoint;
    private Vector2 trajectoryOrigin;
    public GameObject ball;
    public float ballDistance;
     void Start()
    {
        EnemyAttribute.rigidBody = GetComponent<Rigidbody2D>();
        audioFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 ballPos = new Vector2(this.transform.position.x, ball.transform.position.y);
        Vector2 curentPos = this.transform.position;

        if(Vector2.Distance(curentPos, ballPos) > ballDistance)
        {
            if (ball.transform.position.y > yUpBound || ball.transform.position.y < yBottomBound)
            {
                curentPos = new Vector2(this.transform.position.x, this.transform.position.y);
            }
            transform.position = Vector2.MoveTowards(curentPos, ballPos, EnemyAttribute.movementSpeed * Time.deltaTime);
        }
             
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
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
