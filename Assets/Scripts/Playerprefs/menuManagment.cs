using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class menuManagment : MonoBehaviour
{
    public Text EnterText;
    public string playerName;

    public GameObject loadingScene;
    public Image loadingBarFill;
    private InputField enterInput;
    private void Start()
    {
        enterInput = EnterText.GetComponentInParent<InputField>();
        enterInput.characterLimit = 11;
        Debug.Log(PlayerPrefs.GetString("playerName"));
    }
    public void LoadScene(int sceneId)
    {
        PlayerPrefs.SetString("playerName", playerName);
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    public void Update()
    {
        playerName = EnterText.text;
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.fillAmount = progressValue;

                yield return null;
        }
    }
    
    


  
}
