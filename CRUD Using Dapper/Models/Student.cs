﻿using CRUD_Using_Dapper.Common;

namespace CRUD_Using_Dapper.Models
{
    public class Student
    {
        internal OperationType OperationType;

        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Roll { get; set; }

        public string? Message { get; set; }
    }
}
