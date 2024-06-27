using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class engine : MonoBehaviour
{
    public bool use_axe;
    public Animation axeAnim;

    public static int wood_boards = 0;
    public static int gasts = 0;
    public static int water = 0;
    public static int battery = 0;
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

    public Transform book;

    public GameObject light;

    private int item;

    public Camera cam;

    //dinamite
    public GameObject dinamite;
    public Transform dinamitePoint;

    public AudioSource hide_gost;
    public AudioSource walk;
    public AudioSource walk_wood;
    public AudioSource walk_concrete;

    // Start is called before the first frame update
    void Start()
    {
        
        info.text = "Woods: " + wood_boards + " Water: " + water + " Batteries: " + battery + "\nGasts: " + gasts;
        //power = 20;
        light.SetActive(false);
        //axe_rotate = axe.rotation;
        use_axe = false;
        item = 0;
        walkDelay = 1.0f;
        //before_move = characterController.transform;
    }

    //Transform before_move;

    private float walkDelay = 1.0f;

    public Collider[] hitColliders;

    public GameObject floor;

    void MovePlayer()
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

        if (isGrounded)
        {
            hitColliders = Physics.OverlapSphere(ground.position, groundDistance, layerMask);
            if (hitColliders.Length > 0)
            {
                floor = hitColliders.First().gameObject.transform.parent.gameObject;
            }
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

        characterController.Move(player.right * Input.GetAxis("Horizontal") * speedValue * Time.deltaTime + player.forward * Input.GetAxis("Vertical") * speedValue * Time.deltaTime);
    }

    void PlayerWalkSounds()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if ((!walk.isPlaying || walk_wood.isPlaying || walk_concrete.isPlaying) && walkDelay <= 0.0f)
            {
                if (floor.name.IndexOf("Stair") > -1 || floor.name.IndexOf("bridge") > -1)
                {
                    walk_wood.Play();
                }
                else
                if (floor.name.IndexOf("corridor") > -1 || floor.name.IndexOf("old") > -1)
                {
                    walk.Play();
                }
                else
                {
                    walk_concrete.Play();
                }
                walkDelay = 1.0f;
            }
            //before_move = characterController.transform;
        }
    }

    void PlayerSetLight()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit && hitInfo.distance < 1.75f)
        {
            Debug.Log("Tourch hit p: " + hitInfo.transform.parent.gameObject.name + " " + hitInfo.distance);
            if (hitInfo.transform.parent.gameObject.name == "candlle" || hitInfo.transform.parent.gameObject.name == "candlle (1)")
            {
                GameObject light = hitInfo.transform.parent.gameObject;
                light.GetComponent<OpenLight>().SetLight();
            }
        }
    }

    void HitRock(RaycastHit hit)
    {
        GameObject wall = hit.transform.gameObject;
        wall.GetComponent<wall_health>().health -= 2;
    }

    void HitGast(RaycastHit hit)
    {
        GameObject tmp_gost = hit.transform.gameObject;
        Debug.Log(tmp_gost.name);
        AxeGost axeGost = tmp_gost.transform.Find("AttackSphere").GetComponent<AxeGost>();
        axeGost.health -= 4;
        axeGost.UpdateGost(tmp_gost.transform.gameObject);
        /*hide_gost = tmp_gost.transform.parent.Find("AttackSphere").GetComponent<AudioSource>();
        Debug.Log(hide_gost.gameObject.name);
        hide_gost.Play();*/
    }

    void PlayerUseAxe()
    {
        axeAnim.Play();

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
        Debug.Log("Hit attack: " + hitInfo.transform.gameObject.name + " " + hitInfo.distance);
        if (hit && hitInfo.distance < 1.75f)
        {
            if (hitInfo.transform.parent.gameObject.name == "secret(Clone)")
            {
                HitRock(hitInfo);
            }
            else
            if (hitInfo.transform.gameObject.name == "gast" || hitInfo.transform.gameObject.name == "gast(Clone)")
            {
                HitGast(hitInfo);
            }
        }
    }

    void ChangeActiveItem()
    {
        item++;
        if (item < 3)
        {
            if (item == 1)
            {
                light.SetActive(true);
                book.gameObject.SetActive(false);
                axeAnim.gameObject.SetActive(false);
            }
            else
            if (item == 2)
            {
                light.SetActive(false);
                book.gameObject.SetActive(true);
                axeAnim.gameObject.SetActive(false);
            }
        }
        else
        {
            item = 0;
            light.SetActive(false);
            book.gameObject.SetActive(false);
            axeAnim.gameObject.SetActive(true);
        }
    }

    void SetDinamite()
    {
        if (wood_boards > 0 && water > 0)
        {
            Instantiate(dinamite, dinamitePoint.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            water--;
            wood_boards--;

            info.text = "Woods: " + wood_boards + " Water: " + water + " Batteries: " + battery + "\nGasts: " + gasts;
        }
    }

    void RepairDoor(RaycastHit doorItem)
    {
        if (wood_boards >= 5)
        {
            GameObject breakdoor = doorItem.transform.parent.gameObject;
            GameObject door = breakdoor.transform.parent.gameObject;
            door.GetComponent<DoorPlacer>().RepairDoor();
            Debug.Log(door.name);
            wood_boards = wood_boards - 5;
        }
        else
        {

        }
    }

    void OpenCloceDoor(RaycastHit doorItem)
    {
        GameObject door = doorItem.transform.parent.gameObject;
        if (door.GetComponent<DoorEngine>().isOpen == true)
        {
            door.GetComponent<DoorEngine>().closeDoor = true;
        }
        else
        {
            door.GetComponent<DoorEngine>().openDoor = true;
        }
    }

    void AddItemsFromChest(ChestEngine chestEngine)
    {
        ChestEngine.ChestItems chestItems = chestEngine.chestItems;
        wood_boards += chestItems.wood;
        chestItems.wood = 0;
        water += chestItems.water;
        chestItems.water = 0;
        chestEngine.isEmpty = true;
        //info.text = "Woods: " + wood_boards + " Water: " + water + " Batteries: " + battery + "\nGasts: " + gasts;
    }

    void OpenCloseChest(RaycastHit chestItem)
    {
        GameObject chest = chestItem.transform.gameObject;
        ChestEngine chestEngine = chest.GetComponent<ChestEngine>();
        if (chestEngine.isOpen == true)
        {
            chestEngine.closeChest = true;
        }
        else
        {
            if (!chestEngine.isEmpty)
            {
                AddItemsFromChest(chestEngine);
            }
            chestEngine.openChest = true;
        }
    }

    void InteractiveItems()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit && hitInfo.distance < 1.75f)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name + " " + hitInfo.distance);
            if (hitInfo.transform.gameObject.name == "BreakWoodDoor")
            {
                RepairDoor(hitInfo);
            }
            else
            if (hitInfo.transform.gameObject.name == "wood")
            {
                Destroy(hitInfo.collider.gameObject);
                wood_boards++;
            }
            else
            if (hitInfo.transform.gameObject.name == "Battery")
            {
                Destroy(hitInfo.collider.gameObject);
                battery++;
            }
            else
            if (hitInfo.transform.gameObject.name == "bottle")
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
                    GameObject stairs2 = hitInfo.transform.parent.gameObject;
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
            else
            if (hitInfo.transform.gameObject.name == "WoodDoor")
            {
                OpenCloceDoor(hitInfo);
            }
            else
            if (hitInfo.transform.gameObject.name == "chest(Clone)")
            {
                OpenCloseChest(hitInfo);
            }
            else
            if (hitInfo.transform.gameObject.name == "box_red")
            {

            }
            //info.text = "Woods: " + wood_boards + " Water: " + water + " Batteries: " + battery + "\nGasts: " + gasts;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        PlayerWalkSounds();

        vorlocity.y += gravitiy * Time.deltaTime;
        characterController.Move(vorlocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire2"))
        {
            InteractiveItems();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //set dinamite
            SetDinamite();
        }

        if (Input.GetKeyDown(KeyCode.E) && !use_axe)
        {
            ChangeActiveItem();
        }

        if (Input.GetButtonDown("Fire1") && use_axe == false && axeAnim.gameObject.activeSelf)
        {
            PlayerUseAxe();
        }
        if (Input.GetButtonDown("Fire1") && light.activeSelf)
        {
            PlayerSetLight();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }

        info.text = "Woods: " + wood_boards + " Water: " + water + " Batteries: " + battery + "\nGasts: " + gasts;

        walkDelay -= Time.deltaTime;

        //if (use_axe == true)
        //{
            /*Debug.Log(axeAnim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Blend Tree"));
            Debug.Log("Time normal axe: " + axeAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Debug.Log("Use axe: " + use_axe);*/

            if (!axeAnim.isPlaying)
            //if (!(axeAnim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Blend Tree") &&
            //    axeAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f))
            {
                use_axe = false;
            }
            else
            {
                use_axe = true;
            }
        //}
    }
}