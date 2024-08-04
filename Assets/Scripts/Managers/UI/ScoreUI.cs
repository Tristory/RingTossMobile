using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public GameData gameData;
    TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        textMesh.text = $"{gameData.score:0}";
    }
}
