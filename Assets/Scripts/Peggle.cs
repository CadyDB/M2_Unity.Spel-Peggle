using UnityEngine;

public class Peggle : MonoBehaviour
{
    public int hitsToDestroy = 4;
    public int pointsPerHit = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // score toekennen
        ScoreManager.Instance.AddScore(pointsPerHit);

        // aftellen
        hitsToDestroy--;

        // check of de peg nu op is
        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject, 0.25f);
        }
        Destroy(this.gameObject, 0.25f);
    }
}
