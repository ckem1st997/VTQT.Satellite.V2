using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.API.Models;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.DataContext;
using VTQT.Satellite.Service.SatelliteService.DIUnitOfWork;
using VTQT.Satellite.Service.SatelliteService.Repository;
using VTQT.Satellite.ShareMVC.Extensions;
using VTQT.Satellite.ShareMVC.Models;

namespace VTQT.Satellite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubscriberServer _subscriber;

        public SubController(ISubscriberServer unitOfWork,  IMapper mapper)
        {
            _subscriber = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("GetPaginatedList")]
        public IActionResult GetPaginatedList(int start, int length, [FromQuery(Name = "search[value]")] string page)
        {
            var list = _subscriber.GetTable(page, start, length);
            return Ok(new{ data=list.Data,recordsTotal=list.Count, recordsFiltered=list.Count});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _subscriber.GetByIdAsync(id));
        }


        [HttpPut]
        public async Task<IActionResult> Add([FromForm] SubModel subModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Subscriber>(subModel);
                return Ok(await _subscriber.InsertAsync(model));
            }
            else
                return Ok(0);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _subscriber.DeletesAsync(id));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromForm] SubModel subModel, int id)
        {
            var model = await _subscriber.GetByIdAsync(id);
            if (!id.Equals(subModel.Id) || model == null)
                return Ok(0);
            subModel.ReferenceId = model.ReferenceId;
            subModel.LastSync = model.LastSync;
            model = _mapper.Map<Subscriber>(subModel);
            return Ok(await _subscriber.UpdateAsync(model));
        }
    }
}
