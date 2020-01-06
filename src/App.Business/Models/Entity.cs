using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Models
{
    class Entity
    {
        public Guid Id { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
