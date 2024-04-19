using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject myText;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private CharacterController CC;
    [SerializeField] private float moveSpeed;
    private float velocity_y;
    private float grav = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        CC = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Time survived: " + Time.time;
        if (!CC.isGrounded)
        {
            velocity_y += grav * Time.deltaTime;
        }
        else
        {
            velocity_y = 0;
        }

        Vector3 movement = Vector3.down * -velocity_y;

        // these three lines didn't fix it even when they were removed
        float ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float SideMovement = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        movement += (transform.forward * ForwardMovement) + (transform.right * SideMovement);

        CC.Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            myText.SetActive(true);
        }
    }
}
