using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // public Button button;
    // public int difficulty;

    private GameManager5 gameManager5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager5 = GameManager5.Instance;
        // button = gameObject.GetComponent<Button>();   
        // button.onClick.AddListener(SetDifficulty);
    }


    void SetDifficulty(int difficulty)
    {
        Debug.Log(gameObject.name + " was pressed");
        gameManager5.SetDifficulty(difficulty);
    }
}
