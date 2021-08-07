using System;

namespace FluentApiTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DatabaseConnectionBuilder
                .CreateConnection()
                .WithPort(1433)
                .WithUser("andrebaltieri")
                .WithPassword("1234567")
                .Connect();
        }
    }

    public class DatabaseConnectionBuilder : IServerConnection, IPortConnection, IUserNameConnection,
        IPasswordConnection, IConnectConnection
    {
        private DatabaseConnectionBuilder()
        {
        }

        public static IServerConnection CreateConnection()
        {
            return new DatabaseConnectionBuilder();
        }

        public IPortConnection WithPort(int port)
        {
            return this;
        }

        public IUserNameConnection WithUser(string user)
        {
            return this;
        }

        public IPasswordConnection WithPassword(string password)
        {
            return this;
        }

        public IConnectConnection Connect()
        {
            return this;
        }
    }

    public interface IServerConnection
    {
        public IPortConnection WithPort(int port);
    }

    public interface IPortConnection
    {
        public IUserNameConnection WithUser(string user);
    }

    public interface IUserNameConnection
    {
        public IPasswordConnection WithPassword(string password);
    }

    public interface IPasswordConnection
    {
        public IConnectConnection Connect();
    }

    public interface IConnectConnection
    {
    }
}