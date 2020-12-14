using System;
using UnityEngine;

public class FrogController : MonoBehaviour
{    

    Vector2 startingPos = new Vector2(0.5f, -5.5f);
    private Animator _animator;
    [SerializeField] string lakeColliderTag = "water"; //TO DO refactor
    
    [HideInInspector] public bool MoveForbidden;
    private bool collidePlatform = false;
    private bool collideWater = false;
    private float _frogYpos;
    private float _highestYPos;

    public Action OnLilyLeafReach;           
    public Action OnFrogKilled;    
    public Action OnHigherLaneReach;


    void Start()
    {
        PlaceAtStart();
        _animator = GetComponent<Animator>();
        _highestYPos = this.transform.position.y;
    }


    private void Update()
    {
        if (!MoveForbidden)
        {
            Move();        
        }
    }

    void FixedUpdate()
    {
        HandleWaterHazard();
    }

    public void SetupNewLevel()
    {
        PlaceAtStart();
        ResetHighestYPosition();
    }

    private void ResetHighestYPosition()
    {
        _highestYPos = this.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollisions(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var platfrm = collision.GetComponent<ObstacleController>();

        if (platfrm)
        {
            transform.parent = null;
            collidePlatform = false;
        }
        if (collision.gameObject.tag == lakeColliderTag)
        {
            collideWater = false;
        }
    }

    private void HandleCollisions(Collider2D collision)
    {           
        var leaf = collision.GetComponent<LilyLeaf>();
        var obstacle = collision.GetComponent<ObstacleController>();

        if (obstacle && obstacle.IsLeathal== false)
        {
            transform.parent = collision.transform;
            Debug.Log(collision.gameObject.name);
            Debug.Log(collision.GetComponent<ObstacleController>().IsLeathal);
            collidePlatform = true;
            return;
        }
        else if (leaf)
        {            
            collidePlatform = true;
            OnLilyLeafReach?.Invoke();
            ResetPlayer();
            ResetHighestYPosition();
        }
        else if (collision.gameObject.tag == lakeColliderTag)
        {
            collideWater = true;
        }
        else if (obstacle.IsLeathal)
        {
            KillFrog();
            return;
        }
    }

    public void CheckAbleToMove(bool pauseStatus)
    {
        MoveForbidden = pauseStatus;
    }

    public void RunsOutOfTime()
    {
        KillFrog();
    }

    private void HandleWaterHazard()
    {
        if (collideWater && !collidePlatform)
        {
            KillFrog();
            return;
        }
        else return;
    }

    public void ResetPlayer()
    {        
        PlaceAtStart();
    }

    private void PlaceAtStart()
    {
        transform.position = startingPos;
    }

    private void KillFrog()
    {
        OnFrogKilled?.Invoke();
        ResetPlayer();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetTrigger("up");
            transform.Translate(Vector2.up);
            TrackHighestYPos();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetTrigger("down");
            transform.Translate(Vector2.down);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("left");
            transform.Translate(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("right");
            transform.Translate(Vector2.right);
        }

        Vector2 clampedFrogPos = transform.position;
        clampedFrogPos.x = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        clampedFrogPos.y = Mathf.Clamp(transform.position.y, -5.5f, 6.5f);
        transform.position = clampedFrogPos;
    }

    private void TrackHighestYPos()
    {
        _frogYpos = transform.position.y;
        if (_frogYpos > _highestYPos && _highestYPos < 5.5f)
        {
            OnHigherLaneReach?.Invoke();
            _highestYPos = _frogYpos; 
        }
    }
}
