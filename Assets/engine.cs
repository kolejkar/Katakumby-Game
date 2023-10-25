﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class engine : MonoBehaviour
{
    public bool use_axe;

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

    public Camera cam;

    //dinamite
    public GameObject dinamite;
    public Transform dinamitePoint;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        info.text = "Woods: " + wood_boards + " Water: " + water + "Batteries: " + battery + "\nGasts: " + gasts;
        //power = 20;
        light.SetActive(false);
        //axe_rotate = axe.rotation;
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
            if (hit && hitInfo.distance < 1.75f)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name + " " + hitInfo.distance);
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
                if (hitInfo.transform.gameObject.name == "Battery")
                {
                    Destroy(hitInfo.collider.gameObject);
                    battery++;
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
                else
                if (hitInfo.transform.gameObject.name == "WoodDoor")
                {
                    GameObject door = hitInfo.transform.parent.gameObject;
                    if (door.GetComponent<DoorEngine>().isOpen == true)
                    {
                        door.GetComponent<DoorEngine>().closeDoor = true;
                    }
                    else
                    {
                        door.GetComponent<DoorEngine>().openDoor = true;
                    }
                    
                }
                else
                if (hitInfo.transform.gameObject.name == "box_red")
                {
                    CheckLevel.corridors += 2;
                    CheckLevel.rooms += 1;
                    CheckLevel.treasures = CheckLevel.levelId / 7;
                    CheckLevel.levelId++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                //info.text = "Woods: " + wood_boards + " Water: " + water + "Batteries: " + battery + "\nGasts: " + gasts;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //set dinamite
            if (wood_boards > 0 && water > 0)
            {
                Instantiate(dinamite, dinamitePoint.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                water--;
                wood_boards--;

                info.text = "Woods: " + wood_boards + " Water: " + water + "Batteries: " + battery + "\nGasts: " + gasts;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (light.activeSelf)
            {
                light.SetActive(false);
                book.gameObject.SetActive(true);
                //axe.rotation = axe_rotate;
            }
            else
            {
                light.SetActive(true);
                /*light.GetComponent<Light>().enabled = true;
                object halo = light.GetComponent("Halo");
                var haloInfo = halo.GetType().GetProperty("enabled");
                haloInfo.SetValue(halo, true, null);*/
                book.gameObject.SetActive(false);
            }
            //Debug.Log("Wood boards: " + wood_boards);
        }

        info.text = "Woods: " + wood_boards + " Water: " + water + "Batteries: " + battery + "\nGasts: " + gasts;
    }
}