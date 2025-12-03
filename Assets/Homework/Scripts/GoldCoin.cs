using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() == null) return;

        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.CollectCoin();
        }

        gameObject.SetActive(false);
    }
}