using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSingletonIndex : MonoBehaviour
{
    private int index;

    public void SetIndex(int selection)
    {
        FindObjectOfType<StateController>().SetIndex(selection);
    }
}
