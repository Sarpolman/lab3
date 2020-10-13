using System;
using System.Collections;
using System.Collections.Generic;

namespace lab3{

public class SimpleListItem<T>{
        public T data {get;set;}

        public SimpleListItem<T> next {get;set;}

        public SimpleListItem(T param){
            this.data=param;
        }


    }
}