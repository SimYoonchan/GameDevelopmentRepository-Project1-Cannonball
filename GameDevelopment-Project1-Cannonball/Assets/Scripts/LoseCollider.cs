using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession gameSessionLoseHealth;

    //    if (startingNumberOfHealth > 0)
    //        {
    //            FindObjectOfType<Ball>();
    //        }

    //if (startingNumberOfHealth = 0)
    //{
    //    FindObjectOfType<LoseCollider>();

    private void OnTriggerEnter2D(Collider2D collision) //TO-DO: Develop Health Code
    {
        

        FindObjectOfType<SceneLoader>().GameOverSceneForEachLevel();
        //This is all you need to write to call other methods.
    }
}





    


