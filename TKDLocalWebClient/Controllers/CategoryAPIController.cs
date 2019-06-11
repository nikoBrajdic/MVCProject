using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKDLocalWebClient.DAL;
using TKDLocalWebClient.Model;
using TKDLocalWebClient.Model.DTO;

namespace TKDLocalWebClient.Web.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryAPIController : Controller
    {

        private TKDManagerDbContext Context;

        public CategoryAPIController(TKDManagerDbContext context)
        {
            Context = context;
        }

        [Route("")]
        public ActionResult<List<CategoryDTO>> Get() => Context.Categories.Select(CategoryDTO.SelectorExpression).ToList();

        [Route("{id:int}")]
        public ActionResult<CategoryDTO> Get(int id) => Context.Categories.Where(c => c.ID == id).Select(CategoryDTO.SelectorExpression).FirstOrDefault();

        [Route("search/{str}")]
        public ActionResult<List<CategoryDTO>> Get(string str) => Context.Categories.Where(c => c.Name.Contains(str)).Select(CategoryDTO.SelectorExpression).ToList();

        [Route("")]
        [HttpPost]
        public ActionResult<CategoryDTO> Post(Category c)
        {
            if (ModelState.IsValid)
            {
                c.Poomsae11ID = c.Poomsae11ID ?? c.Poomsae11?.ID;
                c.Poomsae11 = null;
                c.Poomsae12ID = c.Poomsae12ID ?? c.Poomsae12?.ID;
                c.Poomsae12 = null;
                c.Poomsae21ID = c.Poomsae21ID ?? c.Poomsae21?.ID;
                c.Poomsae21 = null;
                c.Poomsae22ID = c.Poomsae22ID ?? c.Poomsae22?.ID;
                c.Poomsae22 = null;
                c.Poomsae31ID = c.Poomsae31ID ?? c.Poomsae31?.ID;
                c.Poomsae31 = null;
                c.Poomsae32ID = c.Poomsae32ID ?? c.Poomsae32?.ID;
                c.Poomsae32 = null;
                Context.Categories.Add(c);
                Context.SaveChanges();

                return Get(c.ID);
            }

            return BadRequest(ModelState);
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Put(int id, [FromBody] JObject model)
        {
            var valueProvider = new ObjectSourceValueProvider(model);

            var existing = Context.Categories.FirstOrDefault(p => p.ID == id);
            if (existing != null && ModelState.IsValid && await TryUpdateModelAsync(existing, "", valueProvider))
            {
                Context.SaveChanges();
                return Get(id);
            }

            if (existing == null)
            {
                ModelState.AddModelError("id", "Invalid category ID");
            }

            return BadRequest(ModelState);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existing = Context.Categories.FirstOrDefault(p => p.ID == id);
            if (existing != null)
            {
                Context.Entry(existing).State = EntityState.Deleted;
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(new { error = "Unable to locate category with provided ID", providedID = id });
            }
        }

        public class ObjectSourceValueProvider : IValueProvider
        {
            private JObject _x;

            public ObjectSourceValueProvider(JObject x)
            {
                this._x = x;
            }

            public bool ContainsPrefix(string prefix)
            {
                return _x.Properties().Any(p => p.Name == prefix);
            }

            public ValueProviderResult GetValue(string key)
            {
                var prop = _x.Properties().Where(p => p.Name.ToLower() == key?.ToLower()).FirstOrDefault();

                if (prop == null)
                {
                    return ValueProviderResult.None;
                }
                return new ValueProviderResult(prop.Value.ToString());
            }
        }
    }
}
