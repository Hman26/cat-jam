using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScoreCheck : MonoBehaviour
{
    [Header("Animation Variables")]
    public Animator catScoreAnimator;

    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //you got three star, and plays smug cat animation
        if (!gm._goldStarTwo.activeInHierarchy && !gm._goldStarOne.activeInHierarchy)
        {
            catScoreAnimator.SetBool("0Star", false);
            catScoreAnimator.SetBool("1Star", false);
            catScoreAnimator.SetBool("2Star", false);
            catScoreAnimator.SetBool("3Star", true);
        }
        //you got two star, and plays sleeping cat animation
        else if (!gm._goldStarThree.activeInHierarchy)
        {
            catScoreAnimator.SetBool("0Star", false);
            catScoreAnimator.SetBool("2Star", false);
            catScoreAnimator.SetBool("3Star", false);
            catScoreAnimator.SetBool("1Star", true);
        }
        //you got one star, and plays sad cat animation
        else
        {
            catScoreAnimator.SetBool("1Star", false);
            catScoreAnimator.SetBool("2Star", false);
            catScoreAnimator.SetBool("3Star", false);
            catScoreAnimator.SetBool("0Star", true);
            return;
        }
    }
}
