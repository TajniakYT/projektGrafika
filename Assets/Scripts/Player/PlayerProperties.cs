using UnityEngine;

public class PlayerProperties : ObjectProperties
{
    public GameOverScript gameOverScript;

    protected override void Die()
    {
        // Pokazanie ekranu Game Over
        if (gameOverScript != null)
        {
            gameOverScript.ShowGameOverScreen();
        }

        // Ukrycie gracza zamiast niszczenia (opcjonalnie)
        gameObject.SetActive(false);
    }
}