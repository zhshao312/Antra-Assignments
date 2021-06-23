using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        public ClientService(IClientsRepository clientsRepository, IEmployeesRepository employeeRepository)
        {
            _clientsRepository = clientsRepository;
            _employeesRepository = employeeRepository;
        }

        public async Task<ClientResponseModel> CreateClient(ClientRequestModel clientRequestModel)
        {
            var client = new Clients
            {
                Name = clientRequestModel.Name,
                Email = clientRequestModel.Email,
                Phones = clientRequestModel.Phones,
                Address = clientRequestModel.Address,
                AddedBy = clientRequestModel.AddedBy,
                AddedOn = clientRequestModel.AddedOn,
            };
            var createdClient = await _clientsRepository.AddAsync(client);
            var response = new ClientResponseModel
            {
                Id = createdClient.Id,
                Name = createdClient.Name,
                Email = createdClient.Email,
                Phones = createdClient.Phones,
                Address = createdClient.Address,
                AddedBy = createdClient.AddedBy,
                AddedOn = createdClient.AddedOn,
            };
            return response;
        }

        public async Task DeleteClient(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            await _clientsRepository.DeleteAsync(client);
        }

        public async Task<List<ClientResponseModel>> GetAllClients()
        {
            var clients = await _clientsRepository.GetAllClients();
            var clientList = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                clientList.Add(new ClientResponseModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Address = client.Address,
                    Phones = client.Phones,
                    AddedBy = client.AddedBy,
                    AddedOn = client.AddedOn,
                });
            }
            return clientList;
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            var response = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Address = client.Address,
                Phones = client.Phones,
                AddedBy = client.AddedBy,
                AddedOn = client.AddedOn,
            };
            return response;
        }

        public async Task<ClientResponseModel> UpdateClient(ClientUpdateRequestModel clientUpdateRequestModel, int id)
        {
            var dbClient = await _clientsRepository.GetByIdAsync(id);
            if (dbClient == null)
            {
                throw new Exception("No Client Exist");
            }
            var client = new Clients
            {
                Id = dbClient.Id,
                Name = clientUpdateRequestModel.Name == null ? dbClient.Name : clientUpdateRequestModel.Name,
                Email = clientUpdateRequestModel.Email == null ? dbClient.Email : clientUpdateRequestModel.Email,
                Address = clientUpdateRequestModel.Address == null? dbClient.Address:clientUpdateRequestModel.Address,
                Phones = clientUpdateRequestModel.Phones == null ? dbClient.Phones : clientUpdateRequestModel.Phones,
                AddedBy = clientUpdateRequestModel.AddedBy == null ? dbClient.AddedBy : clientUpdateRequestModel.AddedBy,
                AddedOn = dbClient.AddedOn,
            };
            var updatedClient = await _clientsRepository.UpdateAsync(client);
            var response = new ClientResponseModel
            {
                Id = updatedClient.Id,
                Name = updatedClient.Name,
                Email = updatedClient.Email,
                Address = updatedClient.Address,
                Phones = updatedClient.Phones,
                AddedBy = updatedClient.AddedBy,
                AddedOn = updatedClient.AddedOn,
            };
            return response;
        }
    }
}
