using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Monedas")]
    public int totalCoins = 15;

    private int collectedCoins = 0;

    [Header("UI")]
    public TMP_Text coinText;
    public GameObject levelCompleteText;

    void Start()
    {
        UpdateCoinText();

        levelCompleteText.SetActive(false);
    }

    public void CollectCoin()
    {
        collectedCoins++;

        UpdateCoinText();

        if (collectedCoins >= totalCoins)
        {
            CompleteLevel();
        }
    }

    void UpdateCoinText()
    {
        coinText.text =
            "Monedas: " + collectedCoins + " / " + totalCoins;
    }

    void CompleteLevel()
    {
        levelCompleteText.SetActive(true);

        Debug.Log("LEVEL COMPLETE");
    }
}