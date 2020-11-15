using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimator : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        anim.Play();
        yield return new WaitForSeconds(Random.Range(4,13));
        StartCoroutine(PlayAnimation());
    }
}
