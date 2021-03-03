using GoldenDates.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldenDates
{
    class Api
    {
        const string apiPath = "";

        #region LOGIN
        public async Task<LoginResponse> Login(LoginRequest _loginRequest)
        {
            var json = new Dictionary<string, object>();

            json.Add("username", _loginRequest.username);
            json.Add("password", _loginRequest.password);
            var client = new RestClient(apiPath);
            var request = new RestRequest("Ususarios/LoginUsers", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<LoginResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new LoginResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region USERS

        //AGREGAR USUARIOS
        public async Task<UserResponse> AddUsers(UserRequest _usersRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("userid", _usersRequest.id_user);
            json.Add("username", _usersRequest.username);
            json.Add("password", _usersRequest.password);
            json.Add("nombre", _usersRequest.nombre);
            json.Add("apellido", _usersRequest.apellido);
            json.Add("birthday", _usersRequest.birthday);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Usuarios/AddUsers", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<UserResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new UserResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////EDITAR USUARIOS
        public async Task<UserResponse> EditUsers(UserRequest _usersRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("userid", _usersRequest.id_user);
            json.Add("username", _usersRequest.username);
            json.Add("password", _usersRequest.password);
            json.Add("nombre", _usersRequest.nombre);
            json.Add("apellido", _usersRequest.apellido);
            json.Add("birthday", _usersRequest.birthday);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Usuarios/EditUsers", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<UserResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new UserResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LISTAR USUARIOS
        public async Task<List<UserResponse>> ListUsers()
        {
            //var json = new Dictionary<string, object>();
            //json.Add("username", username);
            //json.Add("password", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Usuarios/ListUsers", Method.GET);
            //request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var responseUsers = JsonConvert.DeserializeObject<List<UserResponse>>(result.Content.ToString());
                    return responseUsers;
                }
                else
                {
                    return new List<UserResponse>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////CONSULTAR USUARIO
        public async Task<UserResponse> GetUsers(UserRequest _userRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("userid", _userRequest.id_user);
            //json.Add("password", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Usuarios/GetUsers", Method.GET);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var responseUsers = JsonConvert.DeserializeObject<UserResponse>(result.Content.ToString());
                    return responseUsers;
                }
                else
                {
                    return new UserResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ELIMINAR USUARIO
        public async Task<bool> DeleteUsers(UserRequest _usersRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("userid", _usersRequest.id_user);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Usuarios/DeleteUser", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));
            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<bool>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region ITEM
        //AGREGAR ITEMS
        public async Task<ProductoResponse> AddItem(ProductoRequest _productoRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("itemid", _productoRequest.id_prod);
            json.Add("description", _productoRequest.description);
            json.Add("cantidad", _productoRequest.cantidad);
            json.Add("stockmin", _productoRequest.stockmin);
            json.Add("stockmax", _productoRequest.stockmax);
          

            var client = new RestClient(apiPath);
            var request = new RestRequest("Productos/AddItems", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<ProductoResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new ProductoResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////EDITAR ITEMS
        public async Task<ProductoResponse> EditItems(ProductoRequest _productoRequest)
        {

            var json = new Dictionary<string, object>();
            json.Add("itemid", _productoRequest.id_prod);
            json.Add("description", _productoRequest.description);
            json.Add("cantidad", _productoRequest.cantidad);
            json.Add("stockmin", _productoRequest.stockmin);
            json.Add("stockmax", _productoRequest.stockmax);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Productos/EditItems", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<ProductoResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new ProductoResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //LISTAR ITEMS
        public async Task<List<ProductoResponse>> ListItems()
        {
            //var json = new Dictionary<string, object>();
            //json.Add("username", username);
            //json.Add("password", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Productos/ListItems", Method.GET);
            //request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<List<ProductoResponse>>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new List<ProductoResponse>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CONSULTAR ITEMS
        public async Task<ProductoResponse> GetItem(ProductoRequest _productoRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("id", _productoRequest.id_prod);
            //json.Add("paitemssword", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Productos/GetItem", Method.GET);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var responseUsers = JsonConvert.DeserializeObject<ProductoResponse>(result.Content.ToString());
                    return responseUsers;
                }
                else
                {
                    return new ProductoResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ELIMINAR ITEMS
        public async Task<bool> DeleteItem(ProductoRequest _productoRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("itemid", _productoRequest.id_prod);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Productos/DeleteItem", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));
            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<bool>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region CLIENTES
        //AGREGAR CLIENTES
        public async Task<ClientResponse> AddClient(ClientRequest _clientRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("id_cli", _clientRequest.id_cli);
            json.Add("nombre", _clientRequest.nombre);
            json.Add("apellido", _clientRequest.apellido);
            json.Add("telefono", _clientRequest.telefono);
            json.Add("direccion", _clientRequest.direccion);
            

            var client = new RestClient(apiPath);
            var request = new RestRequest("Clientes/AddClient", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<ClientResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new ClientResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////EDITAR USUARIOS
        public async Task<ClientResponse> EditClient(ClientRequest _clientRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("id_cli", _clientRequest.id_cli);
            json.Add("nombre", _clientRequest.nombre);
            json.Add("apellido", _clientRequest.apellido);
            json.Add("telefono", _clientRequest.telefono);
            json.Add("direccion", _clientRequest.direccion);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Clientes/EditClient", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<ClientResponse>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return new ClientResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //LISTAR USUARIOS
        public async Task<List<ClientResponse>> ListClient()
        {
            //var json = new Dictionary<string, object>();
            //json.Add("username", username);
            //json.Add("password", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Clientes/ListClient", Method.GET);
            //request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var responseUsers = JsonConvert.DeserializeObject<List<ClientResponse>>(result.Content.ToString());
                    return responseUsers;
                }
                else
                {
                    return new List<ClientResponse>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////CONSULTAR USUARIO
        public async Task<ClientResponse> GetClient(ClientRequest _clientRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("id_cli", _clientRequest.id_cli);
            //json.Add("password", password);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Clientes/GetClient", Method.GET);
            request.AddJsonBody(JsonConvert.SerializeObject(json));

            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var responseUsers = JsonConvert.DeserializeObject<ClientResponse>(result.Content.ToString());
                    return responseUsers;
                }
                else
                {
                    return new ClientResponse();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //ELIMINAR USUARIO
        public async Task<bool> DeleteClient(ClientRequest _clientRequest)
        {
            var json = new Dictionary<string, object>();
            json.Add("id_cli", _clientRequest.id_cli);

            var client = new RestClient(apiPath);
            var request = new RestRequest("Clientes/DeleteClient", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(json));
            try
            {
                var result = await client.ExecuteAsync(request);
                if (result.IsSuccessful)
                {
                    var response = JsonConvert.DeserializeObject<bool>(result.Content.ToString());
                    return response;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}