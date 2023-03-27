using UnityEngine;
public class RestartControl : MonoBehaviour
{
    private Vector3 startingPosition;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        startingPosition = transform.position;
    }

    public void RestartGame()
    {
        transform.position = startingPosition;
        enemyController.SetScore(0); 
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        
        
        
    }
}

