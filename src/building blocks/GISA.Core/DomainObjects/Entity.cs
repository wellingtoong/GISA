﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GISA.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
