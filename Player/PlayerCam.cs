using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{

    public class PlayerCam : MonoBehaviour
    {


        public float sensX;
        public float sensY;
        public Camera mainCam;
        public Transform orientation;

        private float _xRotation;
        private float _yRotation;

        private bool _isTransformNull;
        private bool _isOrientationNull;

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isOrientationNull = orientation == null;
            _isTransformNull = transform == null;
            mainCam.fieldOfView = StateNameController.FovValue;
            sensX = StateNameController.SensitivityValue;
            sensY = StateNameController.SensitivityValue;
        }

        // Update is called once per frame
        private void Update()
        {
            //  Debug.Log(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;

                   SceneManager.LoadScene("Menu");

            }

            var mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            var mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            if (_isTransformNull || _isOrientationNull) return;
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}