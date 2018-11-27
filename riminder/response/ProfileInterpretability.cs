using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class ProfileInterpretability : IResponse
    {
        public InterpretabilityProfile profile;
        public InterpretabilitySkills skills;
    }
}