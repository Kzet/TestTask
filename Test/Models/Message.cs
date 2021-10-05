using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Message
    {
        public Message()
        {

        }
        public Message(string oldMes, string receptTime)
        {
            OldMessage = oldMes;
            ReceptTime = receptTime;
        }
        public Message(string oldMes, string receptTime, string newMes)
        {
            OldMessage = oldMes;
            ReceptTime = receptTime;
            NewMessage = newMes;
        }
        public long Id { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string OldMessage { get; set; }
        public string ReceptTime { get; set; }
        public string NewMessage { get; set; }
    }
}
