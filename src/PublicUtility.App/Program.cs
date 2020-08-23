using EnumsNET;
using PublicUtility.App.Services;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Commands.Inputs;
using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicUtility.App
{
    class Program
    {
        private static EndpointService _service = new EndpointService();

        static void Main(string[] args)
        {
            BuildHeader();
            while (true)
            {
                char action = ChooseAction();
                DoAction(action);
            }
        }

        static void BuildHeader()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Public Utility");
            Console.WriteLine("===================================");
            Console.WriteLine("Endpoints");
            Console.WriteLine("-----------------------------------");
        }

        static char ChooseAction()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1 - INSERIR");
            Console.WriteLine("2 - ALTERAR");
            Console.WriteLine("3 - DELETAR");
            Console.WriteLine("4 - LISTAR TODOS");
            Console.WriteLine("5 - BUSCAR POR SERIAL");
            Console.WriteLine("6 - SAIR");
            Console.WriteLine();
            var action = Console.ReadKey();

            return action.KeyChar;
        }

        static void DoAction(char action)
        {
            Console.WriteLine();

            if (action == '1')
                Create();
            else if (action == '2')
                Update();
            else if (action == '3')
                Delete();
            else if (action == '4')
                List();
            else if (action == '5')
                Details();
            else if (action == '6')
                Environment.Exit(0);
            else
                Console.WriteLine("Opção inválida");

            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }

        static void List()
        {
            List<Endpoint> endpoints = _service.GetAll("v1/endpoints").ToList();

            if (endpoints.Count() == 0)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Nenhum Registro econtrado");
            }

            foreach (var endpoint in endpoints)
            {
                ShowEndpointDetails(endpoint);
            }
        }

        static void Details()
        {
            Console.WriteLine("Digite o Número Serial");
            var serialNumber = Console.ReadKey();
            Console.WriteLine();

            Endpoint endpoint = _service.GetBySerialNumber($"v1/endpoints/{serialNumber.KeyChar}");

            if (endpoint ==  null)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Nenhum Registro econtrado");
                return;
            }

            ShowEndpointDetails(endpoint);
        }

        static void ShowEndpointDetails(Endpoint endpoint)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Número Serial: {endpoint.SerialNumber}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"ID do Modelo do Medidor: {endpoint.MeterModelId}");
            Console.WriteLine($"Número do Modelo do Meididor: {endpoint.MeterNumber}");
            Console.WriteLine($"Versão do Firmware: {endpoint.MeterFirmwareVersion}");
            var value = (EEndpointState)Enum.GetValues(typeof(EEndpointState)).GetValue((int)endpoint.SwitchState);
            var state = value.AsString(EnumFormat.Description);
            Console.WriteLine($"Estado: {state}");
        }

        static void Create()
        {
            Console.WriteLine("Digite o Número Serial");
            var serialNumber = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o ID do Modelo do Medidor");
            var meterModelId = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Número do Modelo do Meididor");
            var meterNumber = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite a Versão do Firmware");
            var meterFirmwareVersion = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Estado");
            Console.WriteLine();
            Console.WriteLine("0 - Desconectado");
            Console.WriteLine("1 - Conectado");
            Console.WriteLine("2 - Armado");
            var switchState = Console.ReadLine();
            Console.WriteLine();

            RegisterEndpointCommand command = new RegisterEndpointCommand(
                serialNumber,
                int.Parse(meterModelId),
                int.Parse(meterNumber),
                meterFirmwareVersion,
                (EEndpointState)Enum.GetValues(typeof(EEndpointState)).GetValue(int.Parse(switchState.ToString())));

            GenericCommandResult result = _service.Post("v1/endpoints", command);
            Console.WriteLine(result.Message);
        }

        static void Update()
        {
            Console.WriteLine("Digite o Número Serial");
            var serialNumber = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Estado");
            Console.WriteLine();
            Console.WriteLine("0 - Desconectado");
            Console.WriteLine("1 - Conectado");
            Console.WriteLine("2 - Armado");
            var switchState = Console.ReadLine();
            Console.WriteLine();

            UpdateEndpointCommand command = new UpdateEndpointCommand(
                serialNumber,
                (EEndpointState)Enum.GetValues(typeof(EEndpointState)).GetValue(int.Parse(switchState.ToString())));

            GenericCommandResult result = _service.Put("v1/endpoints", command);
            Console.WriteLine(result.Message);
        }

        static void Delete()
        {
            Console.WriteLine("Digite o Número Serial");
            var serialNumber = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir esse registro?");
            Console.WriteLine();
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");
            Console.WriteLine();
            var confirmation = Console.ReadKey();
            Console.WriteLine();

            if (confirmation.KeyChar != '1')
                return;

            GenericCommandResult result = _service.Delete($"v1/endpoints/{serialNumber.KeyChar}");
            Console.WriteLine(result.Message);
        }
    }
}
