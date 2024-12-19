using UnityEngine;
using System.Collections;

public class CustomCameraShake : MonoBehaviour
{
    /// <summary>
    /// Trzêsie kamer¹ przez okreœlony czas z okreœlon¹ intensywnoœci¹.
    /// </summary>
    /// <param name="duration">Czas trwania trzêsienia w sekundach.</param>
    /// <param name="magnitude">Si³a/intensywnoœæ trzêsienia.</param>
    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition; // Zapisz oryginaln¹ pozycjê
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null; // Poczekaj na nastêpny frame
        }

        transform.localPosition = originalPosition; // Przywróæ oryginaln¹ pozycjê
    }
}
