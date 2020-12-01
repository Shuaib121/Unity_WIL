using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusSound : MonoBehaviour
{

    [SerializeField] AudioClip clink;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        source.PlayOneShot(clink);
    }
}
