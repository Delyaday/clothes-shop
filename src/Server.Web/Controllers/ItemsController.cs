using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Web.Models.Items.Requests;
using System.Collections;

namespace Server.Web.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly DataBase _dataBase;

        public ItemsController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _dataBase.Items.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Item> GetById(int id)
        {
            return await _dataBase.Items.FirstOrDefaultAsync(f => f.Id == id);
        }

        [HttpPost]
        [Route("create")]
        public async Task Create(CreateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            _dataBase.Items.Add(new DataLayer.Entities.Item() { Name = request.Name, Price = request.Price });
            await _dataBase.SaveChangesAsync();
        }

        [HttpPost]
        [Route("update")]
        public async Task Update(UpdateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var item = await _dataBase.Items.FirstOrDefaultAsync(f => f.Id == request.Id);

            if (item != null)
            {
                item.Name= request.Name;
                item.Price= request.Price;

                await _dataBase.SaveChangesAsync();
            }

        }

        [HttpPost]
        [Route("delete")]
        public async Task Delete(DeleteRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var item = await _dataBase.Items.FirstOrDefaultAsync(f => f.Id == request.Id);

            if (item != null)
            {
                _dataBase.Items.Remove(item);

                await _dataBase.SaveChangesAsync();
            }
        }

    }
}
