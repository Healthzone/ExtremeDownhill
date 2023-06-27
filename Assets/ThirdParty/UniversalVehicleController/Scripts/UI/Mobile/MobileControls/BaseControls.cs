using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PG.UI
{
    public class BaseControls :MonoBehaviour
    {
        public CarControllerInput UserInput { get; set; }
        public string RuName;
        public string EnName;
        public string TrName;

        public virtual void Init (CarControllerInput userInput)
        {
            UserInput = userInput;
        }
    }
}
