using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    public int hp;
    public int currentLevel;

    public List<string> levels;
    public static GameManager instance;

    AudioSource source;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameOverSound;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            print("Found another singleton instance !!!! Die !!!!");
        }
    }

    public void Win()
    {
        source.PlayOneShot(winSound);
        currentLevel++;
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levels[currentLevel]);
    }

    public void Lose()
    {
        hp--;
        if (hp > 0)
        {
            // restart
            Invoke("LoadScene", 1f);
            source.PlayOneShot(loseSound);
        }
        else
        {
            // restart to level 0
            currentLevel = 0;
            Invoke("LoadScene", 1f);
            source.PlayOneShot(gameOverSound);
            hp = 3;
        }

    }
}
