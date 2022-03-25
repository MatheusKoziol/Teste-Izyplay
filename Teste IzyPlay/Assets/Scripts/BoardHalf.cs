using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHalf : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }
}
