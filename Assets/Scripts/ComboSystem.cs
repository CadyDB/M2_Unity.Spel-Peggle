using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();
    private int scoreMultiplier = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo; 
    }

    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;
    }

    private void CheckForCombo(string tag, int bumperValue)
    {
        //check of er meer dan 1 tag in de lijst zitten
        if (bumperTags.Count > 1)
        {
            //check of de op 1 na laatste tag gelijk is aan de laatste
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;
            }
            else
            {
                scoreMultiplier = 1;
                bumperTags.Clear();

            }
        }

        ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);
       
        Debug.Log($"Score: {ScoreManager.Instance.score} || Multiplier: {scoreMultiplier}X");
    }
}
