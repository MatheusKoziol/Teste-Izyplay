using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    #region Hidden Variables
    BoxCollider boxCollider;
    MeshRenderer mesh;
    #endregion

    #region Exposed Variables
    public GameObject boardHalf1;
    public GameObject boardHalf2;
    #endregion

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            other.GetComponentInParent<Knife>().lockRotation = true;
            boxCollider.enabled = false;
            mesh.enabled = false;

            boardHalf1.SetActive(true);
            boardHalf1.transform.parent = null;
            boardHalf2.SetActive(true);
            boardHalf2.transform.parent = null;

            ScoreManager.Instance.score++;

            Destroy(gameObject, 3f);

        }
        else if (other.gameObject.CompareTag("Handle"))
        {
            other.GetComponentInParent<Knife>().BounceImpulse();
        }
    }
}
