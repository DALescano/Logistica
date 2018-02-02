using Med.Comun.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Logistica.Servicios.Host
{
    public class AppTest : IAppTest
    {
        public void DoWork()
        {
            
        }
    }

    public interface IAppTest
    {
        void DoWork();
    }


    [KnownType(typeof(string))]
    [KnownType(typeof(object))]
    public class Result<T> : StatusResponse
    {
        public T Data { get; set; }

        


    }

   
}