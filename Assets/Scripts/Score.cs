using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject panel;

    Blade blade;
    Spawner spawner;




    int score;
    private void Awake()
    {
        blade = FindAnyObjectByType<Blade>();
        spawner = FindAnyObjectByType<Spawner>();
       // scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void UpScore( int num )
    {
        score += num; 
      
        scoreText.text = score.ToString();

        
    }

    public void bombSliced()
    {
        spawner.enabled = false;
        blade.enabled = false;


        panel.SetActive(true);
    }

    public void RestartGame()
    {
        panel.SetActive(false);
        StartCoroutine(restartCourtine());
        score = 0;
        scoreText.text = score.ToString();
        
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    IEnumerator restartCourtine()
    {
        yield return new WaitForSeconds( 2f);
        spawner.enabled = true; 
        blade.enabled=true;
    }
    
}
