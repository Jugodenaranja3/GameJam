using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;  // Referencia al Text UI

    private int score = 0;  // Puntuación inicial

    // Start is called before the first frame update
    void Awake()
    {
        // Asegurarse de que solo haya un GameManager en la escena
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicializar el texto de la puntuación
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Método para aumentar la puntuación
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Actualizar el texto de la puntuación
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
