using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public static PlayerManagement singleton;
    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;
    public bool isDead = false;
    public int keyCount;


    private void Awake() {
        singleton = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    } 

    private void Update() {
        if(isDead){
            // STOP GAME
            ReloadLevel();
        }
        else if(currentHealth <= 0){
            Die();
        }
    }
    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        print("Health player: " + currentHealth);
    }

    private void Die(){
        isDead = true;
        print("GAME OVER : Player died!");
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
