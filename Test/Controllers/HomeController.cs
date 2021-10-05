using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IRepository repository;
        private Dictionary<char, char> symbolsFromDb;
        private List<Message> messagesFromDb;

        public HomeController(IRepository repo)
        {
            repository = repo;
            symbolsFromDb = repository.GetSymbolsfromDb();
            messagesFromDb = repository.Messages.ToList();
        }

        [HttpPost]
        public void EncryptAndSaveMessage(Message message)
        {
            if (message.OldMessage != null)
            {
                message.ReceptTime = DateTime.Now.ToString("F");

                string newMes = "";

                foreach (char symInMes in message.OldMessage)
                {
                    bool check = false;

                    foreach (char oldSymInDict in symbolsFromDb.Keys)
                    {
                        if (!check)
                        {
                            if (symInMes == oldSymInDict)
                            {
                                newMes += symbolsFromDb[oldSymInDict];
                                check = true;
                            }
                        }
                        else break;
                    }

                    if (!check)
                    {
                        newMes += symInMes;
                    }
                }

                message.NewMessage = newMes;
                repository.SaveMessage(message);
                messagesFromDb.Add(message);
            }
            else
            {
                Debug.WriteLine("Пустая строка");
            }
        }

        [HttpGet]
        public List<Message> GetMessages()
        {
            messagesFromDb.Reverse();
            return messagesFromDb;
        }

    }
}
