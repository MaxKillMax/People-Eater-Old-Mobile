using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Starter : MonoBehaviour
{
    [SerializeField] Text[] ScoreText = new Text[4];
    // Ётот метод просто расскидывает счЄт в меню и в класс Score
    void Start()
    {
        Score.Starter(
            PlayerPrefs.GetInt("LastSnakeLength"),
            PlayerPrefs.GetInt("LastDistance"),
            PlayerPrefs.GetInt("BestSnakeLength"),
            PlayerPrefs.GetInt("BestDistance"));

        if (PlayerPrefs.HasKey("LastSnakeLength")) ScoreText[0].text = PlayerPrefs.GetInt("LastSnakeLength").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("LastDistance")) ScoreText[1].text = PlayerPrefs.GetInt("LastDistance").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("BestSnakeLength")) ScoreText[2].text = PlayerPrefs.GetInt("BestSnakeLength").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("BestDistance")) ScoreText[3].text = PlayerPrefs.GetInt("BestDistance").ToString("N0", CultureInfo.CurrentCulture);
    }
}
