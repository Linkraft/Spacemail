using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public GameObject damageLight;

    // Start is called before the first frame update
    void Start()
    {
        damageLight.SetActive(false);

    }

    void Update()
    {
       // Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            TakeDamage();
            Debug.Log("Got Hit");
        }
    }

    private void TakeDamage()
    {
        StartCoroutine(LightFlash(0.08f));
    }

    IEnumerator LightFlash(float delay)
    {
        damageLight.SetActive(true);
        yield return new WaitForSeconds(delay);
        damageLight.SetActive(false);
    }
}
