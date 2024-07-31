using UnityEngine;

public class Tanker : MonoBehaviour
{
        
        public GameObject gasoline;
        [Range(0, 1)]
        public float fillAmount = 1.0f;
        private Vector3 initialScale;
       

        private void Start()
        {
            initialScale = gasoline.transform.localScale;
        }

        private void Update()
        {
            gasoline.transform.localScale = new Vector3(initialScale.x, initialScale.y , initialScale.z * fillAmount);
        }
    }


