using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void MenuGlowne()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

    public void Zasady()
    {
        SceneManager.LoadScene("Zasady", LoadSceneMode.Single);
    }
}
