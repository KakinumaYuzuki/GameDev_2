using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _currentScore = 0;

    public int CurrentScore
    {
        get => _currentScore;
        set => _currentScore = value;
    }

    void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    void Update()
    {
        _scoreText.text = _currentScore.ToString();
    }
}
