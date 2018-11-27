using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class ProfileReveal : IResponse
    {
        public RevealProfile profile;
        public RevealSkills skills;
    }
}