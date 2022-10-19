﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class7BreakOut
{
    
    public enum BlockState
    {
        Normal, Hit, Broken
    }
    
    public class Block
    {
        public BlockState BlockState { get; set; }

        int hitCount;

        public Block()
        {
            this.BlockState = BlockState.Normal;
        }

        public void Hit()
        {
            this.hitCount++;
            //TODO ASK Desinger
            //Assuming when its hit it updates blockstate
            this.UpdateBlockState();
        }

        public virtual void UpdateBlockState()
        {
            switch(this.hitCount)
            {
                case 0:
                    this.BlockState = BlockState.Normal;
                    break;
                case 1:
               
                    this.BlockState = BlockState.Hit;
                    break;
                case 2:
                    this.BlockState = BlockState.Broken;
                    break;
            }
        }

    }
}
