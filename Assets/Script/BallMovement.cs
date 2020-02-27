using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallAttribute{
    public static Rigidbody2D rigidBody;
    public static Collider2D ballCol;
    public static Vector2 trajectoryOrigin;
}
public class BallMovement : MonoBehaviour
{
        private int damage = 10;
        private float xForce = 10f;
        private float yForce = 10f;

        private AudioSource audioFx;
        public AudioClip boomFx;

    private float ballRand;
    // Start is called before the first frame update
    void Start()
    {
        BallAttribute.rigidBody = GetComponent<Rigidbody2D>();
        audioFx = GetComponent<AudioSource>();
        BallPush();
    }

    // Update is called once per frame
    void Update()
    { 
        ResetBallPoss();
    }

    public void BallPush()
    {
        if(xForce > 20f)
        {
            xForce = 10f;
        }
        float yRandomInitialForce = Random.Range(-yForce, yForce);
        ballRand = Random.Range(0f, 2f);
        if (ballRand > 1)
        {
            BallAttribute.rigidBody.velocity = new Vector2(-xForce, yRandomInitialForce);
        }
        else
        {
            BallAttribute.rigidBody.velocity = new Vector2(xForce, yRandomInitialForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float playerDistance = this.transform.position.y - GameObject.Find("Player").transform.position.y;
        float enemyDistance = this.transform.position.y - GameObject.Find("Enemy").transform.position.y;
        if(collision.gameObject.name == "Player"|| collision.gameObject.name == "Enemy")
        {
            xForce += 1f;
            damage += 10;
        }
        if (collision.gameObject.name == "Player")
        {
            BallAttribute.rigidBody.velocity = new Vector2(xForce, playerDistance * 5f);   
        }
        if (collision.gameObject.name == "Enemy")
        {
            BallAttribute.rigidBody.velocity = new Vector2(-xForce, enemyDistance * 5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.gameObject.name == "EnemyTrigger")
        {
            audioFx.PlayOneShot(boomFx);
            EnemyAttribute.health-=damage;
            xForce = 10f;
            damage = 10;
        }
        if(other.gameObject.name == "PlayerTrigger")
        {
            audioFx.PlayOneShot(boomFx);
            PlayerAttribute.health-=damage;
            xForce = 10f;
            damage = 10;
        }
    }
    private void ResetBallPoss()
    {
        if (Mathf.Abs(this.transform.position.x) > 10f)
        {   
            this.transform.position = Vector2.zero;
            BallPush();
        }
    }
}
