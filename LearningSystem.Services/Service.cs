using LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new LearningSystemContext();
        }
        protected LearningSystemContext Context { get; }
    }
}
