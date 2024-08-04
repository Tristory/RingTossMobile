using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float duration;
    public GameData gameData;
    public Signal scoreSignal;
    private RingManager ringManager;

    void Awake()
    {
        ringManager = GetComponentInChildren<RingManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            duration += Time.deltaTime;
            TurnOffWall();
            ringManager.rb2D.velocity = Vector2.zero;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ringManager.duration = duration;
            ringManager.ThrowRing();
            StartCoroutine(ringManager.Duration());
        }
    }

    void TurnOffWall()
    {
        var walls = GetComponentsInChildren<WallManager>();

        foreach (var wall in walls)
        {
            wall.gameObject.SetActive(false);
        }
    }

    public void Scoring(int score)
    {
        gameData.score += score;
        //scoreSignal.Raise();        
    }
}
