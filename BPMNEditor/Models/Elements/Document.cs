﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Serialization;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    public class Document
    {
        public List<IBaseElement> BaseElements
        {
            get; set;
        }

        public List<PoolElement> Pools { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public PoolElement MainPoolElement { get; set; }
       

        public Guid Guid { get; set; }

        public Document()
        {
            BaseElements = new List<IBaseElement>();
            Pools = new List<PoolElement>();
            CreatedOn = DateTime.Now;
            Guid = Guid.NewGuid();
            MainPoolElement = new PoolElement()
            {
                Name = XpdlInfo.MainPoolName
            };
        }

    }
}
