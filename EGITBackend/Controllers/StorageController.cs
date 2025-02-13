﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;

namespace EGITBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        IEGITService EGITService;
        public StorageController(IEGITService EGITService)
        {
            this.EGITService = EGITService;
        }

        [Route("getAll")]
        [HttpGet]
        public List<StorageDto> GetAllStorages()
        {

            return EGITService.GetAllStorages();
        }

        [Route("getById")]
        [HttpGet]
        public StorageDto GetStorage(int id)
        {
            return EGITService.GetStorage(id);
        }

        [Route("addStorage")]
        [HttpPost]
        public GenerateErrorDto AddStorage(CreateStorageDto storage)
        {
            return EGITService.AddStorage(storage);
        }

        [Route("deleteById")]
        [HttpDelete]
        public GenerateErrorDto DeleteStorage(int id)
        {
            return EGITService.DeleteStorage(id);
        }

        [Route("updateStorage")]
        [HttpPut]
        public GenerateErrorDto UpdateStorage(CreateStorageDto storage, int StorageID)
        {
            return EGITService.UpdateStorage(storage, StorageID);
        }
        [Route("getStorageLuns")]
        [HttpGet]
        public List<LunDto> GetStorageLuns(int StorageID)
        {
            return EGITService.GetStorageLuns(StorageID);
        }

        [Route("getUpdatedStorages")]
        [HttpGet]
        public IEnumerable<StorageDto> GetUpdatedStorages()
        {
            return EGITService.GetUpdatedStorages();
        }

    }
}
