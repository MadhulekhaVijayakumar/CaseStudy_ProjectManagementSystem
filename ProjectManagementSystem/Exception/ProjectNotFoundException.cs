﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Exception
{
    public class ProjectNotFoundException :IOException
    {
        public ProjectNotFoundException(string message) : base(message)
        {
        }
    }
}
