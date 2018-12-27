using System;
using System.Collections.Generic;
using System.Text;

namespace Status.DomainModel.Requests
{
    public class PagedRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
