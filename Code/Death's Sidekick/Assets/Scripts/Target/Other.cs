﻿using UnityEngine;

namespace Assets.Scripts.Target
{
    /// <summary>
    /// Class object Other which is linked to a Target by a Link
    /// </summary>
    public class Other
    {

        //Objects
        public Link link;

        //Constructor
        public Other(Target target, byte relation)
        {
            link = new Link(target, this, relation);
        }
    }
}