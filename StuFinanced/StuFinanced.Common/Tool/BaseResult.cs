﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuFinanced.Common.Tool
{
    /// <summary>
    /// 结果处理类
    /// </summary>
    public class BaseResult
    {
        public BaseResult()
        {
            this.IsSuccess = true;
            this.Data = null;
            this.Message = null;
        }
        public BaseResult(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
            this.Data = null;
            this.Message = null;
        }
        public BaseResult(bool isSuccess, object data)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Message = null;
        }
        public BaseResult(bool isSuccess, object data, string message)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Message = message;
        }
        public BaseResult(bool isSuccess, object data, string message, int dataCount)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Message = message;
            this.DataCount = dataCount;
        }
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public int? DataCount { get; set; }
    }
}
