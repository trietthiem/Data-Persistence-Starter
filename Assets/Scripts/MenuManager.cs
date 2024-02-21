using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI hintText;
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        if (BestScore.Instance != null)
        {
            SetBestScoreText(BestScore.Instance.bestScore, BestScore.Instance.bestPlayer);
            inputField.text = BestScore.Instance.playerName;
        }
        inputField.onEndEdit.AddListener(ChangeName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMain()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            hintText.text = "Enter player name!";
            return; // Không chạy tiếp các lệnh khác
        }
        hintText.text = "";
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ChangeName(string name)
    {
        if (BestScore.Instance != null)
        {
            BestScore.Instance.playerName = name;
        }
    }

    private void SetBestScoreText(int bestScore, string bestPlayer)
    {
        bestScoreText.text = "Best Score: " + bestPlayer + " : " + bestScore;
    }
}
