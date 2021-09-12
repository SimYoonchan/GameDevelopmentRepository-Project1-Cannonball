using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Sprite[] numberOfHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void ShowNextSpriteWhenLoseHealth() //TO-DO: Develop Health Code
    //{
    //    int healthIndex = timesHit - 1;
    //    if (numberOfHealth[healthIndex] != null)
    //    {
    //        GetComponent<SpriteRenderer>().sprite = numberOfHealth[healthIndex];
    //    }

    //    else
    //    {
    //        Debug.LogError("Block sprite is missing. The game object that is causing error is " + gameObject.name);
    //    }
    //}
}
