using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;
    private void Awake()
    {
       // scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void UpScore( int num )
    {
        score += num; 
      
        scoreText.text = score.ToString();

        
    }
    
}
