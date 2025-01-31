using UnityEngine;

public abstract class PickUps : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();

}
