using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject winText;

    [Header("Configuracion de Monedas")]
    public int totalItems = 10; 

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;

        
        if (winText != null)
        {
            winText.SetActive(false);
        }

        UpdateUI();
    }

    public void CollectItem()
    {
        score++;
        UpdateUI();

        
        if (score >= totalItems)
        {
            if (winText != null)
            {
                winText.SetActive(true);
            }
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Items: " + score + " / " + totalItems;
        }
    }
}