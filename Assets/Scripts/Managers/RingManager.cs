using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingManager : MonoBehaviour
{
    public float force, duration;
    private bool moveR;
    public Rigidbody2D rb2D;
    private Collider2D c2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        c2D = GetComponent<Collider2D>();
    }

    void Start()
    {
        MoveAround();
    }

    void MoveAround()
    {
        if (moveR)
        {
            rb2D.AddForce(transform.right*5f, ForceMode2D.Impulse);
        } 
        else
        {
            rb2D.AddForce(-(transform.right*5f), ForceMode2D.Impulse);
        }
    }

    void ChangeDirection(string wallName)
    {
        if (wallName == "LeftWall")
        {
            moveR = true;
        }
        else if (wallName == "RightWall")
        {
            moveR = false;
        }

        rb2D.velocity = Vector2.zero;
        MoveAround();
    }

    public IEnumerator Duration()
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        
        c2D.enabled = true;
        rb2D.velocity = Vector3.zero;
        StartCoroutine(NextGame());
    }

    IEnumerator NextGame()
    {        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ThrowRing()
    {
        rb2D.AddForce(transform.up*force, ForceMode2D.Impulse);
        c2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PoleManager>(out var pole))
        {
            pole.UpdateScore();            
            return;
        }

        if (other.TryGetComponent<WallManager>(out var wall))
        {
            ChangeDirection(other.name);
            return;
        }
    }
}
