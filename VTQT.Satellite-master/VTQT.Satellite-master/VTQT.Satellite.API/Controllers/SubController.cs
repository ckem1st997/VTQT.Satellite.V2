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

namespace VTQT.Satellite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDataConnection _appData;

        public SubController(IUnitOfWork unitOfWork, AppDataConnection appData)
        {
            _unitOfWork = unitOfWork;
            _appData = appData;
        }


        [HttpGet("GetPaginatedList")]
        public IActionResult GetPaginatedList(int start, int length, [FromQuery(Name = "search[value]")] string page)
        {
            if (string.IsNullOrEmpty(page))
                page = "";
            var list = _unitOfWork.SubscriberRepository.Get(x => x.CustomerName.Contains(page)).Select(x => new SubscriberViewModel
            {
                Id = x.Id,
                Status = x.Status,
                ContractNo = x.ContractNo,
                CustomerAddress = x.CustomerAddress,
                CustomerMobile = x.CustomerMobile,
                CustomerName = x.CustomerName,
                District = x.District,
                PaymentCycleRegisted = x.PaymentCycleRegisted,
                Province = x.Province,
                ShipPlateNo = x.ShipPlateNo
            });

            var l = (from a in _appData.Subscribers
                     where a.CustomerName.Contains(page)
                     select a).Skip(start).Take(length);
            var c = (from a in _appData.Subscribers
                     select a.Id).Count();

            return Ok(new { data = l, t = true, recordsTotal = c, recordsFiltered = c });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.SubscriberRepository.Get(x => x.Id > 0));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_unitOfWork.SubscriberRepository.GetFirst(x => x.Id.Equals(id)));
        }


        [HttpPut]
        public IActionResult Add(Subscriber SubscriberRepository)
        {
            var model = _unitOfWork.SubscriberRepository.GetFirst(x => x.Id.Equals(SubscriberRepository.Id));
            if (model == null)
            {
                return Ok(0);
            }
            if (ModelState.IsValid)
            {
                SubscriberRepository.ReferenceId = model.ReferenceId;
                SubscriberRepository.LastSync = model.LastSync;
                return Ok(_unitOfWork.SubscriberRepository.Insert(SubscriberRepository));
            }
            else
                return Ok(0);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return Ok(_unitOfWork.SubscriberRepository.Delete(x => x.Id.Equals(id)));
            else
                return Ok(0);

        }

        [HttpPatch]
        public IActionResult Update(Subscriber SubscriberRepository, string id)
        {
            if (!id.Equals(SubscriberRepository.Id))
                return Ok(0);
            return Ok(_unitOfWork.SubscriberRepository.Update(SubscriberRepository));
        }




    }
}
