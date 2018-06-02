using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool AllowMovement
    {
        get;
        set;
    }

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float sprintMultiplier;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private Camera FOV;
    [SerializeField]
    private Text interactLabel;

    private IInteractable interactObject;
    private CharacterController m_PlayerController;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        m_PlayerController = GetComponent<CharacterController>();
        AllowMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        float strafe = Input.GetAxis("Strafe");
        float forward = Input.GetAxis("Forward");
        float speed = Input.GetAxis("Sprint") != 0 ? movementSpeed * sprintMultiplier : movementSpeed;
        float jump = 0;// Input.GetAxis("Jump") * jumpPower;

        if (!AllowMovement)
            speed = 0;

        Vector3 movJump = transform.up * jump * Time.deltaTime;
        Vector3 movForward = FOV.transform.forward * (speed * Time.deltaTime * forward);
        Vector3 movStrafe = FOV.transform.right * speed * Time.deltaTime * strafe;
        Vector3 movDirection = movForward + movStrafe;


        // Check if the player is walking off an edge
        Vector3 worldMove = new Vector3(movDirection.x, 0, movDirection.z);
        Vector3 playerPosition = transform.position;
        if (Physics.Raycast(playerPosition + worldMove * 0.25f, Vector3.down))
            m_PlayerController.SimpleMove(movForward + movStrafe);

        FOV.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0), Space.World);
        FOV.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
        int layer = LayerMask.GetMask("Interactable");
        RaycastHit info;
        Physics.Raycast(FOV.transform.position, FOV.transform.forward, out info, 2, layer);
        interactLabel.enabled = (info.collider != null);

        if (Input.GetButtonDown("Interact"))
        {
            IInteractable interactedObject = null;
            if(info.collider != null)
            {
                interactedObject = info.collider.GetComponent<IInteractable>();
            }

            if (interactObject != null)
            {
                if(interactedObject == null || interactObject != interactedObject)
                {
                    interactObject.Bye();
                    interactObject = null;
                }
            }

            if(interactedObject != null)
            {
                interactedObject.Interact();
                interactObject = interactedObject;
            }
        }
    }
}
