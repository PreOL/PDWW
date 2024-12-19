using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;  // Pocz�tkowa ilo�� punkt�w �ycia

    // Metoda do otrzymywania obra�e�
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Gracz otrzyma� obra�enia! Pozosta�e �ycie: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Metoda do obs�ugi �mierci gracza
    private void Die()
    {
        Debug.Log("Gracz zgin��!");
        // Dodaj tutaj logik� �mierci gracza (np. wczytanie poziomu)
        // Mo�esz tak�e zatrzyma� gr� lub zrestartowa� poziom
    }
}
