using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{
        // The target we are following
        private float uber;
        [SerializeField]
		private GameObject target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

		// Use this for initialization
		void Start()
        {
            uber = PlayerPrefs.GetFloat("Uber");
            if (this.name == "Main Camera P1")
            {
                if (uber==1)
                {
                    target = GameObject.FindGameObjectWithTag("Player");
                } else
                {
                    target = GameObject.FindGameObjectWithTag("Player2");
                }
            }
            if (this.name == "Main Camera P2")
            {
                if (uber == 1)
                {
                    target = GameObject.FindGameObjectWithTag("Player2");
                }
                else
                {
                    target = GameObject.FindGameObjectWithTag("Player");
                }
            }
            if (this.name == "MiniMap Camera P1")
            {
                if (uber == 1)
                {
                    target = GameObject.FindGameObjectWithTag("Player");
                }
                else
                {
                    target = GameObject.FindGameObjectWithTag("Player2");
                }
            }
            if (this.name == "MiniMap Camera P2")
            {
                if (uber == 1)
                {
                    target = GameObject.FindGameObjectWithTag("Player2");
                }
                else
                {
                    target = GameObject.FindGameObjectWithTag("Player");
                }
            }
        }

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngle = target.transform.eulerAngles.y;
			var wantedHeight = target.transform.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.transform.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target.transform);
		}
	}
}