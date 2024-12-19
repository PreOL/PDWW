using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;  // Pocz¹tkowa iloœæ punktów ¿ycia

    // Metoda do otrzymywania obra¿eñ
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Gracz otrzyma³ obra¿enia! Pozosta³e ¿ycie: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Metoda do obs³ugi œmierci gracza
    private void Die()
    {
        Debug.Log("Gracz zgin¹³!");
        // Dodaj tutaj logikê œmierci gracza (np. wczytanie poziomu)
        // Mo¿esz tak¿e zatrzymaæ grê lub zrestartowaæ poziom
    }
}
