using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //We serialized this to see how many blocks we have for debugging purposes.

    // Start is called before the first frame update

    SceneLoader winLevelNextScene;

    void Start()
    {
        winLevelNextScene = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    IndicatorOfBlockBroken();
    //}

    public void CountNumberOfBlocks()
    {
        breakableBlocks++;
    }

    public void IndicatorOfBlockBroken()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            winLevelNextScene.LoadNextLevel();
        }
    }
}
