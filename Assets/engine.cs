using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class engine : MonoBehaviour
{
    public static bool use_axe;

    public static int wood_boards = 0;
    public static int gasts = 0;
    public static int water = 0;
    public int oldgasts;

    public Text info;

    public CharacterController characterController;

    public float speed = 6.0f;
    public float mouseSpeed = 100.0f;
    public Transform player;

    private float gravitiy = -9.81f;

    private Vector3 vorlocity;

    private float xRotation = 0.0f;

    public Transform ground;
    public LayerMask layerMask;
    public float groundDistance = 0.4f;

    private float jump = 1.0f;

    private bool isGrounded;

    public Transform axe;
    private float timer = 0.0f;
    private bool isFire;

    public GameObject light;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        info.text = "Woods: " + wood_boards + " Water: " + water + "\nGasts: " + gasts;
        use_axe = false;
        isFire = false;
        //power = 20;
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, layerMask);

        if (isGrounded && vorlocity.y < 0)
        {
            vorlocity.y = -2.0f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            vorlocity.y = Mathf.Sqrt(jump * -2.0f * gravitiy);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);

        bool nearGast = transform.parent.gameObject.GetComponent<ImageCanvas>().image.gameObject.activeSelf;

        float speedValue = speed;
        if (nearGast == true)
        {
            speedValue = Mathf.Sqrt(speed);
        }

        characterController.Move(player.right * Input.GetAxis("Horizontal") + player.forward * Input.GetAxis("Vertical") * speedValue * Time.deltaTime);

        vorlocity.y += gravitiy * Time.deltaTime;
        characterController.Move(vorlocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "box")
                {
                    Renderer rend = hitInfo.transform.gameObject.GetComponent<Renderer>();
                    rend.material.color = new Color32(30, 91, 4, 255);
                    //boxes++;
                    Application.Quit();
                }
                else
                if (hitInfo.transform.gameObject.name == "wood")
                {
                    Destroy(hitInfo.collider.gameObject);
                    wood_boards++;
                }
                else
                if (hitInfo.transform.gameObject.name == "bottle Variant")
                {
                    Destroy(hitInfo.collider.gameObject);
                    water++;
                }
                else
                if (hitInfo.transform.gameObject.name == "bridge_destroyed")
                {
                    if (wood_boards >= 10)
                    {
                        GameObject bridge2 = hitInfo.transform.parent.gameObject;
                        GameObject lvl2 = bridge2.transform.parent.gameObject;
                        Destroy(bridge2);
                        lvl2.GetComponent<bridge_generator>().MakeBridge();
                        Debug.Log(lvl2.name);
                        wood_boards = wood_boards - 10;
                    }
                    else
                    {

                    }
                }
                else
                if (hitInfo.transform.gameObject.name.Contains("Stair"))
                {
                    if (wood_boards >= 15)
                    {
                        GameObject stairs2= hitInfo.transform.parent.gameObject;
                        GameObject lvl2 = stairs2.transform.parent.gameObject;
                        Destroy(stairs2);
                        lvl2.GetComponent<bridge_generator>().MakeStairs();
                        Debug.Log(lvl2.name);
                        wood_boards = wood_boards - 15;
                    }
                    else
                    {

                    }
                }
                info.text = "Woods: " + wood_boards + " Water: " + water + "\nGasts: " + gasts;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !isFire/*power > 0*/)
        {
            if (light.activeSelf)
            {
                light.SetActive(false);
                axe.gameObject.SetActive(true);
            }
            else
            {
                light.SetActive(true);
                axe.gameObject.SetActive(false);
            }
            //Debug.Log("Wood boards: " + wood_boards);
        }
        /*if (Input.GetKeyDown(KeyCode.Q) && batteries > 0)
        {
            batteries--;
            power = 100;
        }*/
        if (Input.GetButtonDown("Fire1") && !isFire)
        {
            oldgasts = gasts;
            use_axe = true;
            axe.GetComponent<Animator>().Play("Use");
            timer = 5.0f;
            isFire = true;
        }

        if (!use_axe)
        {
            isFire = false;
            if (oldgasts != gasts)
            {
                info.text = "Woods: " + wood_boards + " Water: " + water + "\nGasts: " + gasts;
            }
        }

        timer -= Time.deltaTime;
        if (timer <= 0.0f && isFire)
        {
            Attack();
        }
    }

    void Attack()
    {
        //axe.localRotation = Quaternion.Euler(-45.0f, 0f, 0f);
        timer = 0.0f;
        isFire = false;
        use_axe = false;
    }

}