using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int level = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Proximo level");

            level += 1;
            SceneManager.LoadScene(level);
        }
    }
}
