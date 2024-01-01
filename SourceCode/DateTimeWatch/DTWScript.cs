using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace DateTimeWatch
{
    public class DTWScript : MonoBehaviour
    {
        public TextMeshPro Date = DateTimeWatch.datetext;
        public TextMeshPro Time = DateTimeWatch.timetext;
        string CurrentTime;
        string CurrentDate;

        public void Update()
        {
            DateTime currentTime = DateTime.Now;

            if (CurrentTime != currentTime.ToString("h:mm tt"))
            {
            CurrentTime = currentTime.ToString("h:mm tt");
            }

            if (CurrentDate != currentTime.ToString("M/d/yyyy"))
            {
            CurrentDate = currentTime.ToString("M/d/yyyy");
            }


            Date.text = CurrentDate;
            Time.text = CurrentTime;
        }
    }
}
