using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3{

    public class SimpleStack<T>:SimpleList<T> where T: IComparable{
        public void push(T element)
        {
            this.Add(element);
        }
        
        public T pop(){
            T result =default(T);
            if(this.Count==0) return result;
            if(this.Count==1)
            {
                result=this.first.data;
                this.first=null;
                this.last=null;
            }
            else
            {
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                result = newLast.next.data;
                this.last=newLast;
                newLast.next=null;
            }
            this.Count--;
            return result;
        }
    }
}