using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hahmoOhjain : MonoBehaviour
{
    public float juoksuNopeus = 4;
    [Space]
    public float painovoima = 10;

    public float hiirenNopeus = 3f;
    [SerializeField]
    private float hyppyVoima = 100f;

    public float horisontaaliPyorinta = 0;

    public float vertikaalinenPyorinta = 0;

    public float maxKaannosAsteet = 60;

    private Vector3 liikesuunta = Vector3.zero;
    private CharacterController controller;

    public CursorLockMode hiiriMode;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        Cursor.lockState = hiiriMode;

        Cursor.visible = (CursorLockMode.Locked != hiiriMode);
    }

    // Update is called once per frame
    void Update()
    {
        horisontaaliPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        //Debug.Log($"asteet {horisontaaliPyorinta}");
        vertikaalinenPyorinta = Mathf.Clamp(vertikaalinenPyorinta,-maxKaannosAsteet, maxKaannosAsteet);
        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinenPyorinta,horisontaaliPyorinta,0);

        float nopeusEteen = Input.GetAxis("Vertical");

        float nopeusSivulle = Input.GetAxis("Horizontal");
        
        Vector3 nopeus = new Vector3(nopeusSivulle,0,nopeusEteen);

        nopeus = transform.rotation * nopeus;
        controller.SimpleMove(nopeus * juoksuNopeus);
    }
}
