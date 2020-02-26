using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimationScript : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        AnimatorClipInfo[] animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);

        StartCoroutine(AnimationDestroy(animatorClipInfo[0].clip.length));
    }

    private IEnumerator AnimationDestroy(float sleep_am)
    {
        yield return new WaitForSeconds(sleep_am);
        Destroy(gameObject);
    }
}
