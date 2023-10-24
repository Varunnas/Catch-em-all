using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficulttyLevel : MonoBehaviour
{
    // Start is called before the first frame update        
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager= GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void SetDifficulty()
    {
        if(gameObject.name == "Easy")
        {
            gameManager.StartGame(1.0f);
        }
        else if(gameObject.name == "Medium")
        {
            gameManager.StartGame(0.7f);
        }
        else if (gameObject.name == "Hard")
        {
            gameManager.StartGame(0.3f);
        }
        gameManager.titleScreen.SetActive(false);
    }
}
