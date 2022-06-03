using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private int _score = 0;
    private int _lives = 3;
    private int _gameScoreToWin = 900;
    [SerializeField] private Text _playerScore;
    [SerializeField] private Text _playerLives;
    [SerializeField] private Text _gameResult;

    public void AlienHit() {
        this._score += 10;
        if (this._score < _gameScoreToWin)
        {
            _playerScore.text = "Score: " + _score;
        }
        else {
            Result();
        }
    
    }

    public void ShipHit() {
        this._lives--;
        if (this._lives > 0)
        {
            _playerLives.text = "Lives: " + _lives;
        }
        else {
            Result();
        }
        
    }
    public void Result() {
        if (_score == _gameScoreToWin) {
            _gameResult.text = "YOU WIN ";
        }
        else if (_lives == 0)
        {
            _playerLives.text = "Lives: 0" ;
            
            _gameResult.text = "GAME OVER";
        }
        Destroy(GameObject.FindGameObjectWithTag("Player"), 1.0f);
        _gameResult.gameObject.SetActive(true);

    }  

}
