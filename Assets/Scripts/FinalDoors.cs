using UnityEngine;

public class FinalDoors : MonoBehaviour
{
    [SerializeField] private GameObject finalMessage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            finalMessage.SetActive(true);
            Destroy(collider.gameObject);
        }
    }
}
