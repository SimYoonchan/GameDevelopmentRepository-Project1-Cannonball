using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params:
    [SerializeField] AudioClip blocksBreakingSoundEffects;
    [SerializeField] GameObject blockExplosionParticleEffects;
        //I got to drag over the particle effects game object.
    //[SerializeField] int maxHit;
        //This tells me what is the maximum number of times a block can get hit.
        //I guess it means I should manually write this in Unity.
    [SerializeField] Sprite [] blockAffordance;
        //I didn't know this but you use Sprite since we are having different sprites for the block affordances.

    //Cached referenes below:
    Level level;
        //Note: the type "level" works I THINK because it's in the same project.
    GameSession gameScore;

    //State variables:
    [SerializeField] int timesHit;
        //This tells me how many times a block got hit.
        //This SerializeField is for debugging purposes.


    private void Start()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountNumberOfBlocks();
        }
        
        gameScore = FindObjectOfType<GameSession>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++; //We put this in here because when the block collides, we want to increase the number of times the block got hit
            int maxHits = blockAffordance.Length + 1;
                //It is plus 1 because in our array, if we put 2 other sprites in to change image, then we need 1 more hit for it to destroy gameObject.
                //This is the smart way to write maxHits rather than type it in manually

            if (timesHit >= maxHits) //We will say this to be safe with making sure that we got all of our hits.
            {
                level.IndicatorOfBlockBroken();
                AudioSource.PlayClipAtPoint(blocksBreakingSoundEffects, Camera.main.transform.position);
                Destroy(gameObject);
                gameScore.AddToScore();
                ParticleEffect(); //Seems to work even with private void.
            }

            else
            {
                ShowNextHitSprite(); //This is to basically show the next in line sprite to make the block change into a more damaged looking block.
            }
            
        }
        
    }

    private void ParticleEffect()
    {
        GameObject particleEffects = Instantiate(blockExplosionParticleEffects, transform.position, transform.rotation);
        Destroy(particleEffects, 2.0f);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (blockAffordance[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = blockAffordance[spriteIndex];
        }

        else
        {
            Debug.LogError("Block sprite is missing. The game object that is causing error is " + gameObject.name);
        }
            
    }
}
