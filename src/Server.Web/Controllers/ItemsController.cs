using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Server.Web.Controllers
{
    public class ItemsController: Controller
    {
        private readonly DataBase _dataBase;

        public ItemsController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        [Route("api/create")]
        public async Task Create()
        {
            _dataBase.Items.Add(new DataLayer.Entities.Item() { Name = "Jeans", Price = 5000 });
            await _dataBase.SaveChangesAsync();
        }
    }
}
