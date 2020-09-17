using System;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; } // atributo criado para personalizar msg de erro

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}