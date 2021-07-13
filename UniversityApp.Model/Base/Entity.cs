﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Model.Base {
    public abstract class Entity {

        public Guid ID { get; set; }

        public Entity() {
            ID = Guid.NewGuid();
        }

    }

}
