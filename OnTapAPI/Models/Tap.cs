﻿using System;
namespace OnTapAPI.Models
{
    public class Tap
    {
        public int tapId { get; set; }
        public int kegId { get; set; }
        public int position { get; set; }
        public string flowId { get; set; }

        public Tap()
        {
            
        }
    }
}
