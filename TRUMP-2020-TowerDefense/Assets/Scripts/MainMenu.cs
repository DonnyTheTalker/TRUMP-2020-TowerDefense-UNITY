using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string LevelToLoad = "MainLevel";
    [SerializeField] private GameObject _turret;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _progressText;

    public void Play()
    {
        StartCoroutine(LoadAsynchronously());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsynchronously()
    {
         
        _turret.SetActive(false);
        _loadingScreen.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelToLoad); 

        while (!operation.isDone) {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _progressBar.fillAmount = progress;
            _progressText.text = String.Format("{0:f0}", progress * 100f) + "%";

            yield return null;

        }

    }

    void Start()
    {
        _turret.SetActive(true);
        _loadingScreen.SetActive(false);
    }

}
