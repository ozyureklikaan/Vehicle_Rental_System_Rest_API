using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRentalSystemWebApi.Models
{
    public class ResponseContent<T> : IDisposable
    {
        public string Result { get; set; }
        public List<T> Data { get; set; }

        public ResponseContent(List<T> data)
        {
            Data = data;
            Result = CheckList(Data);
        }

        public ResponseContent()
        {

        }

        private string CheckList(List<T> list)
        {
            return list == null ? "0" : list.Count() != 0 ? "1" : "3";
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}