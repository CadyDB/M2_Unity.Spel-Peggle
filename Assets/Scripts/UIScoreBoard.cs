using TMPro;
using UnityEngine;

public class UIScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreField;
    [SerializeField] private TMP_Text multiplierField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComboSystem.OnScoreChange += HandleScoreChange;
    }

   private void OnDisable()
    {
        ComboSystem.OnScoreChange -= HandleScoreChange;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleScoreChange(int score, int multiplier)
    {
        scoreField.text = "Score: "+score;
        multiplierField.text = "Multiplier: "+multiplier+"X";
    }
}
