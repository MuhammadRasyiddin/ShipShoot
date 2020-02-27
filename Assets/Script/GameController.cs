using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject popUpPause;
    public GameObject Ball;
    //For debugging Purpose.
    public PlayerMovement player;
    public EnemyMovement enemy;
    public Rigidbody2D ball;
    public Collider2D bola;
    private float ballMass;
    private Vector2 ballVelocity;
    private float ballSpeed;
    private Vector2 ballMomentum;
    private float ballFriction;
    private float impulsePlayerX;
    private float impulsePlayerY;
    private float impulseEnemyX;
    private float impulseEnemyY;
    private string debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DebugGame()
    {
        ballMass = ball.mass;
        ballVelocity = ball.velocity;
        ballSpeed = ball.velocity.magnitude;
        ballMomentum = ballMass * ballVelocity;
        ballFriction = bola.friction;
        impulsePlayerX = player.LastContactPoint().normalImpulse;
        impulsePlayerY = player.LastContactPoint().tangentImpulse;
        impulseEnemyX = enemy.LastContactPoint().normalImpulse;
        impulseEnemyY = enemy.LastContactPoint().tangentImpulse;

        debugText =
                "Ball mass = " + ballMass + "\n" +
                "Ball velocity = " + ballVelocity + "\n" +
                "Ball speed = " + ballSpeed + "\n" +
                "Ball momentum = " + ballMomentum + "\n" +
                "Ball friction = " + ballFriction + "\n" +
                "Last impulse from player 1 = (" + impulsePlayerX + ", " + impulsePlayerY + ")\n" +
                "Last impulse from player 2 = (" + impulseEnemyX + ", " + impulseEnemyY + ")\n"; 

        Debug.Log(debugText);
    }

    public void Paused(){
        popUpPause.SetActive(true);
        Time.timeScale = 0;
        Ball.SetActive(false);
    }

    public void BackToMain(){
        Application.LoadLevel("MainMenu");
    }
}
