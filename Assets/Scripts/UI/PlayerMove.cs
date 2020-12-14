using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public int health = 0;

    public GameObject damageLight;
    public GameObject hull;
    public GameObject glass;

    public GameObject smokeOne;
    public GameObject smokeTwo;

    Material hullDamagedMat;
    Material screensDamageMat;
    Material glassDamage;


    private Material[] hullMaterials;
    private Material glassMaterial;
    MeshRenderer hullRenderer;
    MeshRenderer glassRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hullDamagedMat = Resources.Load<Material>("BrokenHull");
        screensDamageMat = Resources.Load<Material>("BrokenScreen");
        glassDamage = Resources.Load<Material>("BrokenGlass");

        damageLight.SetActive(false);

        hullRenderer = hull.GetComponent<MeshRenderer>();
        hullMaterials = hullRenderer.materials;

        glassRenderer = glass.GetComponent<MeshRenderer>();
        glassMaterial = glassRenderer.material;

    }

    void Update()
    {
        // Move();
        //TakeDamage();
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
            health++;
            TakeDamage();
            Debug.Log("Your fucked");
        }
    }

    private void TakeDamage()
    {
        if (health > 5)
        {
            Debug.Log("Health Low");
            StartCoroutine(LightFlash(0.08f));
            hullMaterials[0] = hullDamagedMat;
            hullMaterials[1] = screensDamageMat;
            hullRenderer.materials = hullMaterials;

            glassMaterial = glassDamage;
            glassRenderer.material = glassMaterial;

            smokeOne.gameObject.SetActive(true);
            smokeTwo.gameObject.SetActive(true);
        }
    }

    IEnumerator LightFlash(float delay)
    {
        damageLight.SetActive(true);
        yield return new WaitForSeconds(delay);
        damageLight.SetActive(false);
    }
}
