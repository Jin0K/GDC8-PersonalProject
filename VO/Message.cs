using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Message
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }

    public class Message<T>
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public T Instance { get; set; }
    }

    public class Messages<T>
    { 
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public List<T> Instances { get; set; }
    }

