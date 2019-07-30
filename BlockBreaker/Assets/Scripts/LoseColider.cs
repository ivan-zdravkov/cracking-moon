using UnityEngine;

public class LoseColider : MonoBehaviour
{
    Level level;

    private void Start()
    {
        this.level = FindObjectOfType<Level>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            this.level.BallDroped();

            Destroy(collision.gameObject);
        }
    }
}
