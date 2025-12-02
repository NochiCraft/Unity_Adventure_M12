using TMPro;
using UnityEngine;

public class ForceExample : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Rigidbody _rigidbody;

    [SerializeField] private float _yForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _text.text = "Mode: Forse";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _text.text = "Mode: Impulse";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _text.text = "Mode: Acceleration";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _text.text = "Mode: VelocityChange";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.VelocityChange);
        }
    }
}
