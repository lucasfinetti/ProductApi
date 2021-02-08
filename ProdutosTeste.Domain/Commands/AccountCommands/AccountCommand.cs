using System;
using NetDevPack.Messaging;

namespace ProdutosTeste.Domain.Commands.AccountCommands
{
    public abstract class AccountCommand : Command
    {
        public string Username { get; protected set; }

        public string Password { get; protected set; }
    }
}