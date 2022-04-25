using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private int life = 3;
    [SerializeField] GameObject[] _lifeUI;
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _fadePanel;

    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.CompareTag("obstacle"))
            {
                life--;
                _lifeUI[life].gameObject.SetActive(false);
                if (life == 0)
                {
                    _gameOver.SetActive(true);
                    _fadePanel.SetActive(true);
                    StartCoroutine(Fade());
                }
                
            }
            
        }
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.6f);
        Time.timeScale = 0;
    }

}
