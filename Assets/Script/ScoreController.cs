using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject popUp;
    public Text winLoseCondition;
    public Text playerHpText;
    private string playerHp;
    public Text enemyHpText;
    private string enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHp = "HP: "+ PlayerAttribute.health;
        enemyHp = "HP: "+ EnemyAttribute.health;

        playerHpText.text = playerHp;
        enemyHpText.text = enemyHp;

        if(PlayerAttribute.health <= 0)
        {
            PlayerAttribute.health = 0;
            Time.timeScale = 0;
            winLoseCondition.text =  "You Lose!";
            popUp.SetActive(true);
            
        }else if(EnemyAttribute.health <= 0)
        {
            EnemyAttribute.health = 0;
            Time.timeScale = 0;
            winLoseCondition.text =  "You Win!";
            popUp.SetActive(true);
        }
    }

    public void BackToMain(){
        Application.LoadLevel("MainMenu");
    }
}
