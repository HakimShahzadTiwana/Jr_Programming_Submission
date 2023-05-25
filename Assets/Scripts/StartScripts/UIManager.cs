using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TMP_InputField nameInput;
    void Start()
    {

    }

    public void setNameInput()
    {
        Singleton.Instance.currentPlayer = nameInput.text;
    }

    public void onPlayButtonClicked() {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }
}
