using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : ObstacleController
{
    [SerializeField] private float emergeTime = 2f;
    [SerializeField] private List<Animator> turtleAnimatorList;

    public float curTimer;
    private float sinkTimer;

    void Start()
    {
        sinkTimer = Random.Range(5f, 15f);
        curTimer = sinkTimer;
    }

    private void FixedUpdate()
    {
        curTimer -= Time.fixedDeltaTime;
        if (curTimer <= 0f)
        {
            StartCoroutine ("Submerge");
        }        
    }

    IEnumerator Submerge()
    {
        foreach (Animator animator in turtleAnimatorList)
        {
            animator.SetTrigger("submerge");
        }
        curTimer = sinkTimer;
        yield return new WaitForSeconds(0.6f);
        GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Emerge", emergeTime);
    }

    private void Emerge()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        foreach (Animator animator in turtleAnimatorList)
        {
            animator.SetTrigger("emerge");
        }
    }
}
