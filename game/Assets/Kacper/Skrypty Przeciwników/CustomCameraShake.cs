using UnityEngine;
using System.Collections;

public class CustomCameraShake : MonoBehaviour
{
    /// <summary>
    /// Trz�sie kamer� przez okre�lony czas z okre�lon� intensywno�ci�.
    /// </summary>
    /// <param name="duration">Czas trwania trz�sienia w sekundach.</param>
    /// <param name="magnitude">Si�a/intensywno�� trz�sienia.</param>
    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition; // Zapisz oryginaln� pozycj�
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null; // Poczekaj na nast�pny frame
        }

        transform.localPosition = originalPosition; // Przywr�� oryginaln� pozycj�
    }
}
