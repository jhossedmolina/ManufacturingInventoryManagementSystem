﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingInventory.Application.DTOs
{
    public class ApiResponseDto<T>
    {
        public ApiResponseDto(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
