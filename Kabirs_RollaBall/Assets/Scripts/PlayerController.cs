using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private GameObject[] pickupItems;
    private AudioSource[] audios;
    private AudioSource pop;

    public Transform respawnPoint;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audios = cam.GetComponents<AudioSource>();
        count = 0;
        pop = audios[1];
        SetCount();
        winTextObject.SetActive(false);
        if (pickupItems == null) {
            pickupItems = GameObject.FindGameObjectsWithTag("pickups");
        }
    }

    private void Update()
    {
        if (transform.position.y < -10) {
            Respawn();
            count = 0;
        }
    }

    void OnMove(InputValue movementValue)
    {
        if (this.gameObject) {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void FixedUpdate()
    {
        if (this.gameObject)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
        SetCount();
    }

    private void SetCount() {
        countText.text = "Player Score: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            //winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!...";
        }
    }

    //In this method the other is the object which is the reference to the object which our gameobject hits. (in this case its the other boxes)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickups")) {
            count++;
            //Turn the object off, they don't appear on screen but they're not destroyed
            other.gameObject.SetActive(false);
            pop.Play(0);
        }
    }

    public void Respawn() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
        winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!!... Restarting";
        winTextObject.SetActive(true);
        Invoke("resetGame", 3);
    }

    public void resetGame() {
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Won!!";
        winTextObject.SetActive(false);
        count = 0;
        foreach (GameObject pickupItem in pickupItems)
        {
            pickupItem.SetActive(true);
        }
    }

    //void Update()
    //{
    //    if (this.gameObject) {
    //        Vector3 explosionPos = transform.position;
    //        float radii = GetComponent<SphereCollider>().radius;

    //        if (Input.GetKeyDown(KeyCode.V))
    //        {
    //            Debug.Log("Keypress hit");
    //            rb.AddExplosionForce(500, explosionPos, radii, 3.0F);
    //            Destroy(this.gameObject, 4);
    //        }
    //    }
    //}

}