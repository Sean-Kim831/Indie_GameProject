using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{

    public void Game_start_button_on()
    {
        SceneManager.LoadScene("Mygame");
    }
    
}
