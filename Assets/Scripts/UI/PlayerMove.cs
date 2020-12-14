using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public int health = 0;

    public GameObject damageLight;
    public GameObject hull;
    public GameObject glass;

    //Resources
    public int score;
    public GameObject progressBar;

    //SceneTransition
    public Light flashLight;
    public float lightStep;
    public GameObject ray;
    public GameObject scene;


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
        Debug.Log("Score= " + score);

        if (score == 20)
        {
            Destroy(scene);
            ExitScene();
        }

        if (flashLight.intensity > 80)
        {
            SceneManager.LoadScene(2);
        }
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

        if (other.CompareTag("Resources"))
        {
            score += 2;
            progressBar.transform.localScale = new Vector3(score/100f, 1, 1);

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


    void ExitScene()
    {
        ShowRays();
        StartCoroutine(ExecuteAfterTime(1f));
    }

    void LightOn()
    {
        Debug.Log("FlashLight");
        flashLight.intensity += lightStep * Time.deltaTime;

    }

    void ShowRays()
    {
        Debug.Log("Rays");
        ray.SetActive(true);
    }

    IEnumerator LightFlash(float delay)
    {
        damageLight.SetActive(true);
        yield return new WaitForSeconds(delay);
        damageLight.SetActive(false);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        LightOn();
    }
}
