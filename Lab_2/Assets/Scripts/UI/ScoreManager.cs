using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        scoreText.text = $"Score: {score}";
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }
}
