using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class TheCounts : MonoBehaviour
{
    public static bool isCandyCount;
    public static bool isSuprised;
    public static bool isBonusRoundStart;
    public static bool isBonusRoundEnd;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;
    public AudioClip ten;
    public AudioClip bonusRoundClip;
    public AudioClip oh;
    public AudioClip ohMyGod;
    public AudioClip endClip;
    private AudioSource audioSource;
    private static Animator animator;

     // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool("isReset", true);

    }

    // Update is called once per frame
    void Update()
    {   
        animator.SetBool("isBonusEnd", false);
        // Check if the Counts should count candy cookies
        // Bonus round script sets isCandyCount to true
        if (isCandyCount)
        {
            CandyCookieCount();

        }

        // Have The Counts react to the bonus candy cookie.
        // BonusRound script sets isSuprised to true
        if (isSuprised)
        {
            ReactToBonusCookie();

        }

        // Check if The Counts should announce the bonus round
        if (isBonusRoundStart) 
        {
            BonusRoundStartClip();
            isBonusRoundStart = false;

            // Set this animation bool to false after it may be true from a previous bonus round
            animator.SetBool("isBonusEnd", false);

        }

        // Check if The Counts should announce the end of the bonus round
        if (isBonusRoundEnd)
        {   
            animator.SetBool("isBonusEnd", true);
            audioSource.PlayOneShot(endClip);
            isBonusRoundEnd = false;

        }

    }

    /// <summary>
    /// Sets reset animation to play
    /// </summary>
    public void Reset()
    {   
        animator.SetBool("isReset", true);

    }

    /// <summary>
    /// Plays the bonus round clip
    /// </summary>
    public void BonusRoundStartClip()
    {
        audioSource.PlayOneShot(bonusRoundClip);

    }

    /// <summary>
    /// Plays the correct number audio clip when Cookie Hero gets a candy cookie
    /// </summary>
    public void CandyCookieCount()
    {
        switch(BonusRound.cookiesInBatch - 1)
        {
            case 0: 
                animator.SetBool("isOneCount", true);
                audioSource.PlayOneShot(one);
                break;
            case 1: 
                animator.SetBool("isTwoCount", true);
                audioSource.PlayOneShot(two);
                break;
            case 2: 
                animator.SetBool("isThreeCount", true);
                audioSource.PlayOneShot(three);
                break;
            case 3: 
                animator.SetBool("isFourCount", true);
                audioSource.PlayOneShot(four);
                break;
            case 4: 
                animator.SetBool("isFiveCount", true);
                audioSource.PlayOneShot(five);
                break;
            case 5: 
                animator.SetBool("isOneCount", true);
                audioSource.PlayOneShot(six);
                break;
            case 6: 
                animator.SetBool("isTwoCount", true);
                audioSource.PlayOneShot(seven);
                break;
            case 7: 
                animator.SetBool("isThreeCount", true);
                audioSource.PlayOneShot(eight);
                break;
            case 8: 
                animator.SetBool("isFourCount", true);
                audioSource.PlayOneShot(nine);
                break;
            case 9: 
                animator.SetBool("isFiveCount", true);
                audioSource.PlayOneShot(ten);
                break;
            default:
                // Play ohMyGod on unexpected value. The Counts would be suprised after all.
                audioSource.PlayOneShot(ohMyGod);
                break;
            
        }

        isCandyCount = false;

    }

    /// <summary>
    /// Plays an audio clip to have The Counts react to the bonus candy cookie
    /// </summary>
    public void ReactToBonusCookie()
    {       
        // React to a pretty big bonus candy cookie
        if (BonusRound.bonusRoundCookies >= 10 && BonusRound.bonusRoundCookies < 50)
        {
            audioSource.PlayOneShot(oh);
        }
        // React to a small bonus candy cookie
        else if (BonusRound.bonusRoundCookies < 10)
        {   
            animator.SetBool("isScratch", true);
        }
        // React to the max size bonus candy cookie
        else
        {
            audioSource.PlayOneShot(ohMyGod);

        }

        isSuprised = false;
    }

    /// <summary>
    /// Called when the count up ends
    /// </summary>
    public void OnCountEnd()
    {
        GameManager.Instance().endCount();
        animator.SetBool("isReset", false);

    }

    // Animation events
    // Called on the count of one
    public void OnOne()
    {   
        audioSource.PlayOneShot(one);
        GameManager.Instance().numberOne();

    }

    // Called on the count of two
    public void OnTwo()
    {   
        audioSource.PlayOneShot(two);
        GameManager.Instance().numberTwo();

    }

    // Called on the count of three
    public void OnThree()
    {
        audioSource.PlayOneShot(three);
        GameManager.Instance().numberThree();

    }

    // function to set any animation to true or false through animation events
    public void SetAnimation(string animationName)
    {
        animator.SetBool(animationName, !animator.GetBool(animationName));

    }

    public static void HeadScratch()
    {
        animator.SetBool("isScratch", true);

    }

    public static void Stare()
    {
        animator.SetBool("isStare", true);

    }

    public static void Cough()
    {
        animator.SetBool("isCoughing", true);
        
    }
    
}
