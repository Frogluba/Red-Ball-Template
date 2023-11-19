using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    public  List<string> levels;
    public static GameManager instance;
    public int curentLevel;
    public int hp;

     void Start()
    {
        if(instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }
    public  void Win()
    {
        curentLevel++;
        Invoke("LoadScene", 1f);
        SceneManager.LoadScene(levels[curentLevel]);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(levels[curentLevel]);
    }
    
    public  void Lose()
    {
        hp--;
        if(hp>0)
        {
            Invoke("LoadScene", 1f);//loads next scene
        }
        else
        {
            curentLevel = 0; //Restarts to level 1
            Invoke("LoadScene", 1f);
        }
    }
}
