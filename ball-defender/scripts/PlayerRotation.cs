using UnityEngine;

public partial class PlayerRotation : MonoBehaviour
{
    [Header("Configurações")]
    public float rotationSpeed = 10f; 
    public LayerMask groundLayer;    

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RotateTowardsInput();
        }
    }

    void RotateTowardsInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 direction = hit.point - transform.position;

            direction.y = 0;

            if (direction.sqrMagnitude > 0.1f) 
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}