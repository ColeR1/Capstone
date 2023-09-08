using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.InputManager
{


    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;

        private RaycastHit hit; //what we hit with our ray

        private List<Transform> selectedUnits = new List<Transform>();

        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
       private void Update()
        {
            
        }

        public void HandleUnitMovement()
        {
            if(Input.GetMouseButtonDown(0))
            {
                 //create a ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //check if we hit something
                if(Physics.Raycast(ray,out hit))
                {
                    //if we do, then do something with that data
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch(layerHit.value)
                    {
                        case 8: //Units Layer
                            //do smoething
                            SelectUnit(hit.transform);
                            break;
                        default: //if non of the above happens
                            //do something
                            DeselectUnits();
                            break;
                    }
                }
            }
           
        }

        private void SelectUnit(Transform unit)
        {

            DeselectUnits();
            selectedUnits.Add(unit);
            //lets set and obj on the unit called highlight
            unit.Find("Highlight").gameObject.SetActive(true);
        }

        private void DeselectUnits()
        {
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].Find("Highlight").gameObject.SetActive(false);
            }
            selectedUnits.Clear();
        }
    }
}
