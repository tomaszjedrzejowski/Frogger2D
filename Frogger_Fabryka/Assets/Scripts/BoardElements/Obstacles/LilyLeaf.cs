using System;
using UnityEngine;

public class LilyLeaf : MonoBehaviour
{
    [SerializeField] private Sprite checkedLeaf;
    [SerializeField] private Sprite emptyLeaf;

   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = checkedLeaf;
        GetComponent<CircleCollider2D>().enabled = false;        
    }

    public void Reset()
    {
        GetComponent<SpriteRenderer>().sprite = emptyLeaf;
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
